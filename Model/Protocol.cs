using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace KPCapture.Model
{
    public enum ProtocolType : int
    {
        TCP = 6,
        UDP = 17,
        NONE = -1
    };

    public interface IProtocol
    {
        uint SourcePort { get; }
        uint DestinationPort { get; }
        int Checksum { get; }
        byte[] Bytes { get; }
    }

    public class TCP : IProtocol
    {
        public uint SourcePort { get; private set; }
        public uint DestinationPort { get; private set; }
        public uint SequenceNumber { get; private set; } = 555;
        public int HeaderLength { get; private set; }
        public uint WindowSize { get; private set; } = 555;
        public int Checksum { get; private set; } = 555;
        public byte[] Bytes { get; private set; } = new byte[] { };
        public ushort UsUrgentPointer { get; private set; }
        public ushort UsDataOffsetAndFlags { get; private set; } = 555;
        public uint UiAcknowledgementNumber { get; private set; } = 555;
        public int UrgentPointer
        {
            get
            {
                if ((UsDataOffsetAndFlags & 0x20) != 0)
                {
                    return UsUrgentPointer;
                }
                else
                {
                    return int.MaxValue;
                }
            }
        }

        
        public uint AcknowledgementNumber
        {
            get => (UsDataOffsetAndFlags & 0x10) != 0 ? UiAcknowledgementNumber : uint.MaxValue;
        }

        public int RawFlags { get => UsDataOffsetAndFlags & 0x3F; }

        public IEnumerable<string> Flags
        {
            get
            {
                if ((RawFlags & 0x01) != 0)
                    yield return "FIN";
                if ((RawFlags & 0x02) != 0)
                    yield return "SYN";
                if ((RawFlags & 0x04) != 0)
                    yield return "RST";
                if ((RawFlags & 0x08) != 0)
                    yield return "PSH";
                if ((RawFlags & 0x10) != 0)
                    yield return "ACK";
                if ((RawFlags & 0x20) != 0)
                    yield return "URG";
            }
        }

        public TCP(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var reader = new BinaryReader(stream);

            SourcePort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            DestinationPort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            SequenceNumber = (uint)IPAddress.NetworkToHostOrder(reader.ReadInt32());
            UiAcknowledgementNumber = (uint)IPAddress.NetworkToHostOrder(reader.ReadInt32());
            UsDataOffsetAndFlags = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            WindowSize = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            Checksum = (short)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            UsUrgentPointer = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            HeaderLength = (byte)(UsDataOffsetAndFlags >> 12);
            HeaderLength *= 4;
            var UsMessageLength = (ushort)(bytes.Length - HeaderLength);
            if (UsMessageLength > 0)
            {
                Bytes = new byte[UsMessageLength];
                Array.Copy(bytes, HeaderLength, Bytes, 0, UsMessageLength);
            }
        }
    }


    public class UDP : IProtocol
    {
        public uint SourcePort { get; private set; }
        public uint DestinationPort { get; private set; }
        public int Checksum { get; private set; }
        public byte[] Bytes { get; private set; } = new byte[] { };

        public UDP(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var reader = new BinaryReader(stream);
            
            
            SourcePort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            DestinationPort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            Checksum = IPAddress.NetworkToHostOrder(reader.ReadInt16());

            var UsLength = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            if (UsLength > 0)
            {
                Bytes = new byte[UsLength];
                Array.Copy(bytes, 8, Bytes, 0, bytes.Length - 8);
            }
        }
    }

    public class IP
    {
        private byte _versionAndHeaderSize;
        public string Version
        {
            get
            {
                if ((_versionAndHeaderSize >> 4) == 4)
                    return "IP v4";
                else if ((_versionAndHeaderSize >> 4) == 6)
                    return "IP v6";
                else
                    return "Unknown";
            }
        }

        public byte DifferentialServices { get; private set; }
        public byte HeaderSize { get; private set; }
        public ushort TotalLength { get; private set; }
        public ushort Length { get => (ushort)(TotalLength - HeaderSize); }
        public ushort Identification { get; private set; }
        public byte TTL { get; private set; }
        public short CheckSum { get; private set; }
        public IPAddress SourceAddress { get; private set; }
        public IPAddress DestAddress { get; private set; }
        public byte[] Bytes { get; private set; }

        private byte _protocol;
        public ProtocolType ProtocolType
        {
            get
            {
                if (_protocol == 6)
                    return ProtocolType.TCP;
                else if (_protocol == 17)
                    return ProtocolType.UDP;
                else
                    return ProtocolType.NONE;
            }
        }

        private ushort _flags_and_fragment_offset;
        public int FragmentationOffset
        {
            get
            {
                int offset = _flags_and_fragment_offset << 3;
                offset >>= 3;

                return offset;
            }
        }

        public IP(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var reader = new BinaryReader(stream);

            _versionAndHeaderSize = reader.ReadByte();
            DifferentialServices = reader.ReadByte();
            TotalLength = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            Identification = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            _flags_and_fragment_offset = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            TTL = reader.ReadByte();
            _protocol = reader.ReadByte();
            CheckSum = IPAddress.NetworkToHostOrder(reader.ReadInt16());
            SourceAddress = new IPAddress((uint)reader.ReadInt32());
            DestAddress = new IPAddress((uint)reader.ReadInt32());
            HeaderSize = _versionAndHeaderSize;
            HeaderSize <<= 4;
            HeaderSize >>= 4;
            HeaderSize *= 4;

            Bytes = new byte[TotalLength - HeaderSize];
            Array.Copy(bytes, HeaderSize, Bytes, 0, Bytes.Length);
        }
    }
}
