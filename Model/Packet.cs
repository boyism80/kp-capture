using System;
using System.Net;

namespace KPCapture.Model
{
    public partial class Packet
    {
        public IProtocol Based { get; private set; }
        public IP IP { get; private set; }
        public byte[] Bytes => Based.Bytes;
        public IPAddress SourceAddress => IP.SourceAddress;
        public IPAddress DestinationAddress => IP.DestAddress;
        public uint SourcePort => Based.SourcePort;
        public uint DestinationPort => Based.DestinationPort;
        public int Checksum => Based.Checksum;
        public ProtocolType ProtocolType => IP.ProtocolType;
        public DateTime DateTime { get; private set; } = DateTime.Now;
        
        private Packet(IProtocol based, IP ip)
        {
            Based = based;
            IP = ip;
        }

        public static Packet Parse(byte[] bytes)
        {
            try
            {
                var ip = new IP(bytes);
                switch (ip.ProtocolType)
                {
                    case ProtocolType.TCP:
                        return new Packet(new TCP(ip.Bytes), ip);

                    case ProtocolType.UDP:
                        return new Packet(new UDP(ip.Bytes), ip);
                    
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
