using System;
using System.Net;

namespace KPCapture.Model.Protocol
{
    public partial class Packet
    {
        public Header.Base Base { get; private set; }
        public Header.IP IP { get; private set; }

        public byte[] Bytes { get => this.Base.Bytes; }

        public IPAddress SourceAddress { get => this.IP.SourceAddress; }

        public IPAddress DestinationAddress { get => this.IP.DestAddress; }

        public uint SourcePort { get => this.Base.SourcePort; }

        public uint DestinationPort { get => this.Base.DestinationPort; }

        public int Checksum { get => this.Base.Checksum; }

        public Header.Protocol Protocol { get => IP.ProtocolType; }

        public DateTime DateTime { get; private set; } = DateTime.Now;

        private Packet(Header.Base b, Header.IP i)
        {
            this.Base = b;
            this.IP = i;
        }

        public static Packet Parse(byte[] bytes)
        {
            try
            {
                var ip = new Header.IP(bytes);
                switch (ip.ProtocolType)
                {
                    case Header.Protocol.TCP:
                        return new Packet(new Header.TCP(ip.Bytes), ip);

                    case Header.Protocol.UDP:
                        return new Packet(new Header.UDP(ip.Bytes), ip);
                    
                    default:
                        throw new Exception();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
