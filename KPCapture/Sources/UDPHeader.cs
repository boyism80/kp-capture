using System;
using System.IO;
using System.Net;

namespace KPU.Sources
{
    public class UDPHeader : BaseHeader
    {
        // Sixteen bits for the source port number.
        private ushort UsSourcePort;
        // Sixteen bits for the destination port number.
        private ushort UsDestinationPort;
        // Length of the UDP header.
        //private ushort UsLength;
        // Sixteen bits for the checksum (checksum can be negative so taken as short).
        private short SChecksum;
        // Data carried by the UDP packet.

        public UDPHeader(byte[] bytes, int recvsize) : base(bytes, recvsize)
        {
            var stream = new MemoryStream(bytes, 0, recvsize);
            var reader = new BinaryReader(stream);

            // 1. 
            this.UsSourcePort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

            // 2. 
            this.UsDestinationPort = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

            // 3. 
            var UsLength = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

            // 4. 
            this.SChecksum = IPAddress.NetworkToHostOrder(reader.ReadInt16());

            // 5.
            if (UsLength == 0)
            {
                this.Bytes = null;
            }
            else
            {
                this.Bytes = new byte[UsLength];
                Array.Copy(bytes, 8, this.Bytes, 0, recvsize - 8);
            }
            //Array.Copy(bytes, 8, this._bytes, 0, recvsize - 8);
        }

        public override uint SourcePort
        {
            get
            {
                return this.UsSourcePort;
            }
        }

        public override uint DestinationPort
        {
            get
            {
                return this.UsDestinationPort;
            }
        }

        public override int Checksum
        {
            get
            {
                return this.SChecksum;
            }
        }
    }
}
