using System;
using System.Net;

namespace KPU.Sources
{
    public class Packet
    {
        public IPHeader IPHeader { get; private set; }

        public BaseHeader BaseHeader { get; private set; }

        public Protocol Protocol
        {
            get
            {
                return this.IPHeader.ProtocolType;
            }
        }

        public byte[] Bytes
        {
            get
            {
                return this.BaseHeader.Bytes;
            }
        }

        public IPAddress SourceAddress
        {
            get
            {
                return this.IPHeader.SourceAddress;
            }
        }

        public IPAddress DestinationAddress
        {
            get
            {
                return this.IPHeader.DestinationAddress;
            }
        }

        public uint SourcePort
        {
            get
            {
                return this.BaseHeader.SourcePort;
            }
        }

        public uint DestinationPort
        {
            get
            {
                return this.BaseHeader.DestinationPort;
            }
        }

        public int Checksum
        {
            get
            {
                return this.BaseHeader.Checksum;
            }
        }

        public DateTime Timestamp { get; private set; }

        public Packet(byte[] bytes, int recvsize)
        {
            this.Timestamp              = DateTime.Now;
            this.IPHeader               = new IPHeader(bytes, recvsize);

            switch (this.IPHeader.ProtocolType)
            {
                case Protocol.TCP:
                    this.BaseHeader     = new TCPHeader(this.IPHeader.Bytes, this.IPHeader.Length);
                    break;

                case Protocol.UDP:
                    this.BaseHeader     = new UDPHeader(this.IPHeader.Bytes, this.IPHeader.Length);
                    break;

                case Protocol.Unknown:
                    break;
            }
        }
    }
}