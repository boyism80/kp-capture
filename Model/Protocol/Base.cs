using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace KPCapture.Model.Protocol.Header
{
    public enum Protocol : int
    {
        TCP = 6,
        UDP = 17,
        Unknown = -1
    };

    public abstract class Base
    {
        public abstract uint SourcePort { get; }

        public abstract uint DestinationPort { get; }

        public abstract int Checksum { get; }

        public byte[] Bytes { get; protected set; } = new byte[] { };

        protected Base(byte[] bytes)
        {
            this.Bytes = bytes;
        }
    }

    public class TCP : Base
    {
        private ushort UsSourcePort;
        public override uint SourcePort { get => this.UsSourcePort; }

        private ushort UsDestinationPort;
        public override uint DestinationPort { get => this.UsDestinationPort; }

        private uint UiSequenceNumber = 555;
        public uint SequenceNumber { get => this.UiSequenceNumber; }

        private byte ByHeaderLength;
        public int HeaderLength { get => this.ByHeaderLength; }

        private ushort UsWindow = 555;
        public uint WindowSize { get => this.UsWindow; }

        private short SChecksum = 555;
        public override int Checksum { get => this.SChecksum; }

        private ushort UsUrgentPointer;
        private ushort UsDataOffsetAndFlags = 555;
        private uint UiAcknowledgementNumber = 555;
        public int UrgentPointer
        {
            get
            {
                if ((this.UsDataOffsetAndFlags & 0x20) != 0)
                {
                    return this.UsUrgentPointer;
                }
                else
                {
                    return int.MaxValue;
                }
            }
        }

        
        public uint AcknowledgementNumber
        {
            get => (this.UsDataOffsetAndFlags & 0x10) != 0 ? this.UiAcknowledgementNumber : uint.MaxValue;
        }

        public int RawFlags { get => this.UsDataOffsetAndFlags & 0x3F; }

        public IEnumerable<string> Flags
        {
            get
            {
                if ((this.RawFlags & 0x01) != 0)
                    yield return "FIN";
                if ((this.RawFlags & 0x02) != 0)
                    yield return "SYN";
                if ((this.RawFlags & 0x04) != 0)
                    yield return "RST";
                if ((this.RawFlags & 0x08) != 0)
                    yield return "PSH";
                if ((this.RawFlags & 0x10) != 0)
                    yield return "ACK";
                if ((this.RawFlags & 0x20) != 0)
                    yield return "URG";
            }
        }

        public TCP(byte[] bytes) : base(bytes)
        {
            var stream = new MemoryStream(bytes);
            var reader = new BinaryReader(stream);

            this.UsSourcePort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.UsDestinationPort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.UiSequenceNumber = (uint)IPAddress.NetworkToHostOrder(reader.ReadInt32());
            this.UiAcknowledgementNumber = (uint)IPAddress.NetworkToHostOrder(reader.ReadInt32());
            this.UsDataOffsetAndFlags = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.UsWindow = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.SChecksum = (short)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.UsUrgentPointer = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.ByHeaderLength = (byte)(this.UsDataOffsetAndFlags >> 12);
            this.ByHeaderLength *= 4;
            var UsMessageLength = (ushort)(bytes.Length - this.ByHeaderLength);
            if (UsMessageLength > 0)
            {
                this.Bytes = new byte[UsMessageLength];
                Array.Copy(bytes, this.ByHeaderLength, this.Bytes, 0, UsMessageLength);
            }
        }
    }


    public class UDP : Base
    {
        private ushort UsSourcePort;
        public override uint SourcePort { get => this.UsSourcePort; }

        private ushort UsDestinationPort;
        public override uint DestinationPort { get => this.UsDestinationPort; }

        private short SChecksum;
        public override int Checksum { get => this.SChecksum; }

        public UDP(byte[] bytes) : base(bytes)
        {
            var stream = new MemoryStream(bytes);
            var reader = new BinaryReader(stream);
            
            
            this.UsSourcePort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.UsDestinationPort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.SChecksum = IPAddress.NetworkToHostOrder(reader.ReadInt16());

            var UsLength = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            if (UsLength > 0)
            {
                this.Bytes = new byte[UsLength];
                Array.Copy(bytes, 8, this.Bytes, 0, bytes.Length - 8);
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
                if ((this._versionAndHeaderSize >> 4) == 4)
                    return "IP v4";
                else if ((this._versionAndHeaderSize >> 4) == 6)
                    return "IP v6";
                else
                    return "Unknown";
            }
        }

        public byte DifferentialServices { get; private set; }
        public byte HeaderSize { get; private set; }
        public ushort TotalLength { get; private set; }
        public ushort Length { get => (ushort)(this.TotalLength - this.HeaderSize); }
        public ushort Identification { get; private set; }
        public byte TTL { get; private set; }
        public short CheckSum { get; private set; }
        public IPAddress SourceAddress { get; private set; }
        public IPAddress DestAddress { get; private set; }
        public byte[] Bytes { get; private set; } = new byte[4096];

        private byte _protocol;
        public Protocol ProtocolType
        {
            get
            {
                if (this._protocol == 6)
                    return Protocol.TCP;
                else if (this._protocol == 17)
                    return Protocol.UDP;
                else
                    return Protocol.Unknown;
            }
        }

        private ushort _flags_and_fragment_offset;
        public int FragmentationOffset
        {
            get
            {
                int offset = this._flags_and_fragment_offset << 3;
                offset >>= 3;

                return offset;
            }
        }

        public IP(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var reader = new BinaryReader(stream);

            this._versionAndHeaderSize = reader.ReadByte();
            this.DifferentialServices = reader.ReadByte();
            this.TotalLength = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.Identification = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this._flags_and_fragment_offset = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.TTL = reader.ReadByte();
            this._protocol = reader.ReadByte();
            this.CheckSum = IPAddress.NetworkToHostOrder(reader.ReadInt16());
            this.SourceAddress = new IPAddress((uint)reader.ReadInt32());
            this.DestAddress = new IPAddress((uint)reader.ReadInt32());
            this.HeaderSize = this._versionAndHeaderSize;
            this.HeaderSize <<= 4;
            this.HeaderSize >>= 4;
            this.HeaderSize *= 4;

            Array.Copy(bytes, this.HeaderSize, this.Bytes, 0, this.TotalLength - this.HeaderSize);
        }
    }
}
