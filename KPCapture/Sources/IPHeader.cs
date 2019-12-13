using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace KPU.Sources
{
    public enum Protocol
    {
        TCP = 6,
        UDP = 17,
        Unknown = -1
    };

    public class IPHeader
    {
        // Eight bits for version and header length.
        private byte            _version_and_header_size;
        // Eight bits for differentiated services (TOS).
        private byte            _service_type;
        // Sixteen bits for total length of the datagram (header + message).
        private ushort          _total_length;
        // Sixteen bits for identification.
        private ushort          _identification;
        // Eight bits for flags and fragmentation offset.
        private ushort          _flags_and_fragment_offset;
        // Eight bits for TTL (Time To Live).
        private byte            _time_to_live;
        // Eight bits for the underlying protocol.
        private byte            _protocol;
        // Sixteen bits containing the checksum of the header
        // (checksum can be negative so taken as short).
        private short           _checksum;
        // Thirty two bit source IP Address.
        private uint            _source_addr;
        // Thirty two bit destination IP Address.
        private uint            _dest_addr;
        // Header length.
        private byte            _header_size;
        // Data carried by the datagram
        private byte[]          _bytes = new byte[4096];

        public IPHeader(byte[] bytes, int recvsize)
        {
            try
            {
                var stream              = new MemoryStream(bytes, 0, recvsize);
                var reader              = new BinaryReader(stream);

                // 0. Ethernet header
                //reader.ReadBytes(14);

                // 1. Read version & header length (8 bits)
                this._version_and_header_size    = reader.ReadByte();

                // 2. Read service type (8 bits)
                this._service_type               = reader.ReadByte();

                // 3. Read total length (16 bits)
                this._total_length               = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 4. Read identification (16 bits)
                this._identification            = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 5. Read flags & fragment offset (16 bits)
                this._flags_and_fragment_offset    = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 6. Read TTL (8 bits)
                this._time_to_live                       = reader.ReadByte();

                // 7. Read protocol (8 bits)
                this._protocol                  = reader.ReadByte();

                // 8. Read header checksum (16 bits)
                this._checksum                  = IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 9. Read source ip address (32 bits)
                this._source_addr                = (uint)reader.ReadInt32();

                // 10. Read destination ip address (32 bits)
                this._dest_addr           = (uint)reader.ReadInt32();

                // 11. Calculate header length
                this._header_size              = this._version_and_header_size;
                this._header_size              <<= 4;
                this._header_size              >>= 4;
                this._header_size              *= 4;

                Array.Copy(bytes, this._header_size, this._bytes, 0, this._total_length - this._header_size);
            }
            catch (Exception e)
            {
            }
        }

        public string Version
        {
            get
            {
                if ((this._version_and_header_size >> 4) == 4)
                    return "IP v4";
                else if ((this._version_and_header_size >> 4) == 6)
                    return "IP v6";
                else
                    return "Unknown";
            }
        }

        public int HeaderLength
        {
            get
            {
                return this._header_size;
            }
        }

        public ushort Length
        {
            get
            {
                return (ushort)(this._total_length - this._header_size);
            }
        }

        public int DifferentialServices
        {
            get
            {
                return this._service_type;
            }
        }

        public int FragmentationOffset
        {
            get
            {
                int offset = this._flags_and_fragment_offset << 3;
                offset >>= 3;

                return offset;
            }
        }

        public int TTL
        {
            get
            {
                return this._time_to_live;
            }
        }

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

        public int Checksum
        {
            get
            {
                return this._checksum;
            }
        }

        public IPAddress SourceAddress
        {
            get
            {
                return new IPAddress(this._source_addr);
            }
        }

        public IPAddress DestinationAddress
        {
            get
            {
                return new IPAddress(this._dest_addr);
            }
        }

        public int TotalLength
        {
            get
            {
                return this._total_length;
            }
        }

        public int Identification
        {
            get
            {
                return this._identification;
            }
        }

        public byte[] Bytes
        {
            get
            {
                return this._bytes;
            }
        }
    }
}

