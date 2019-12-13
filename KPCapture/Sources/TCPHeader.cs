using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace KPU.Sources
{
    public class TCPHeader : BaseHeader
    {
        // Sixteen bits for the source port number.
        private ushort          UsSourcePort;
        // Sixteen bits for the destination port number.
        private ushort          UsDestinationPort;
        // Thirty two bits for the sequence number.
        private uint            UiSequenceNumber = 555;
        // Thirty two bits for the acknowledgement number.
        private uint            UiAcknowledgementNumber = 555;
        // Sixteen bits for flags and data offset.
        private ushort          UsDataOffsetAndFlags = 555;
        // Sixteen bits for the window size.
        private ushort          UsWindow = 555;
        // Sixteen bits for the checksum, (checksum can be negative so taken as short).
        private short           SChecksum = 555;
        // Sixteen bits for the urgent pointer.  
        private ushort          UsUrgentPointer;
        // Header length.
        private byte            ByHeaderLength;
        // Length of the data being carried.
        //private ushort UsMessageLength;
        // Data carried by the TCP packet.

        public TCPHeader(byte[] bytes, int recvsize) : base(bytes, recvsize)
        {
            try
            {
                var stream                      = new MemoryStream(bytes, 0, recvsize);
                var reader                      = new BinaryReader(stream);

                // 1.
                this.UsSourcePort               = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 2. 
                this.UsDestinationPort          = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 3. 
                this.UiSequenceNumber           = (uint)IPAddress.NetworkToHostOrder(reader.ReadInt32());

                // 4. 
                this.UiAcknowledgementNumber    = (uint)IPAddress.NetworkToHostOrder(reader.ReadInt32());

                // 5. 
                this.UsDataOffsetAndFlags       = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 6. 
                this.UsWindow                   = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 7. 
                this.SChecksum                  = (short)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 8. 
                this.UsUrgentPointer            = (ushort)IPAddress.NetworkToHostOrder(reader.ReadInt16());

                // 9. 
                this.ByHeaderLength             = (byte)(this.UsDataOffsetAndFlags >> 12);
                this.ByHeaderLength             *= 4;

                // 10. 
                var UsMessageLength             = (ushort)(recvsize - this.ByHeaderLength);

                // 11. 
                if (UsMessageLength == 0)
                {
                    this.Bytes = null;
                }
                else
                {
                    this.Bytes                  = new byte[UsMessageLength];
                    Array.Copy(bytes, this.ByHeaderLength, this.Bytes, 0, UsMessageLength);
                }
            }
            catch (Exception e)
            {
            }
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

        public uint SequenceNumber
        {
            get
            {
                return this.UiSequenceNumber;
            }
        }

        public uint AcknowledgementNumber
        {
            get
            {
                if ((this.UsDataOffsetAndFlags & 0x10) != 0)
                    return this.UiAcknowledgementNumber;
                else
                    return uint.MaxValue;
            }
        }

        public int HeaderLength
        {
            get
            {
                return this.ByHeaderLength;
            }
        }

        public uint WindowSize
        {
            get
            {
                return this.UsWindow;
            }
        }

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

        public string Flags
        {
            get
            {
                // The last six bits of data offset and flags contain the control bits.
                // First we extract the flags.
                var flags                       = UsDataOffsetAndFlags & 0x3F;
                var str                         = string.Format("0x{0:x2} (", flags);
                
                // Now we start looking whether individual bits are set or not.
                if ((flags & 0x01) != 0)
                    str += "FIN, ";
                if ((flags & 0x02) != 0)
                    str += "SYN, ";
                if ((flags & 0x04) != 0)
                    str += "RST, ";
                if ((flags & 0x08) != 0)
                    str += "PSH, ";
                if ((flags & 0x10) != 0)
                    str += "ACK, ";
                if ((flags & 0x20) != 0)
                    str += "URG";
                str += ")";

                if (str.Contains("()"))
                    str                         = str.Remove(str.Length - 3);
                else if (str.Contains(", )"))
                    str                         = str.Remove(str.Length - 3, 2);

                return str;
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
