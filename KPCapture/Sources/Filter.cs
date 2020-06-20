using System.Linq;
using System.Net;

namespace KPU.Sources
{
    public class Filter
    {
        public enum Accept
        {
            INCLUDE, EXCLUDE,
        }

        public IPAddress SourceAddress { get; set; }
        public IPAddress DestinationAddress { get; set; }
        public int SourcePort { get; set; }
        public int DestinationPort { get; set; }
        public byte[] SubBytes { get; set; }
        public int MininumLength { get; set; }
        public int MaximumLength { get; set; }
        public Protocol Protocol { get; set; }
        public bool OnlyValidChecksum { get; set; }
        public bool OnlyAcceptAllicationLevel { get; set; }

        public Filter()
        {
            this.Protocol                   = Protocol.Unknown;
            this.SourcePort                 = -1;
            this.DestinationPort            = -1;
            this.MininumLength              = -1;
            this.MaximumLength              = -1;
            this.OnlyValidChecksum          = true;
            this.OnlyAcceptAllicationLevel  = true;
        }

        private static bool match(byte[] haystack, byte[] needle, int start)
        {
            if (needle.Length + start > haystack.Length)
                return false;

            for (var i = 0; i < needle.Length; i++)
            {
                if (needle[i] != haystack[i + start])
                {
                    return false;
                }
            }
            return true;
        }


        private bool contains(byte[] haystack, byte[] needle)
        {
            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (match(haystack, needle, i))
                    return true;
            }

            return false;
        }

        public bool condition(Packet packet)
        {
            if (this.OnlyAcceptAllicationLevel && packet.BaseHeader.Length == 0)
                return false;

            // verify checksum

            if (this.SourceAddress != null && this.SourceAddress.Equals(packet.SourceAddress) == false)
                return false;

            if (this.DestinationAddress != null && this.DestinationAddress.Equals(packet.DestinationAddress) == false)
                return false;

            if (this.SourcePort != -1 && this.SourcePort != packet.SourcePort)
                return false;

            if (this.DestinationPort != -1 && this.DestinationPort != packet.DestinationPort)
                return false;

            if (this.MininumLength != -1 && this.MininumLength > packet.BaseHeader.Length)
                return false;

            if (this.MaximumLength != -1 && this.MaximumLength < packet.BaseHeader.Length)
                return false;

            if (this.Protocol != Protocol.Unknown && this.Protocol != packet.Protocol)
                return false;

            if (this.SubBytes != null && this.contains(packet.BaseHeader.Bytes, this.SubBytes) == false)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            var filter              = obj as Filter;
            if(filter == null)
                return base.Equals(obj);

            if ((this.SourceAddress != null && filter.SourceAddress == null) ||
                (this.SourceAddress == null && filter.SourceAddress != null) ||
                (this.SourceAddress != null && filter.SourceAddress != null && this.SourceAddress.Equals(filter.SourceAddress) == false))
                return false;

            if (this.SourcePort != filter.SourcePort)
                return false;

            if ((this.DestinationAddress != null && filter.DestinationAddress == null) ||
                (this.DestinationAddress == null && filter.DestinationAddress != null) ||
                (this.DestinationAddress != null && filter.DestinationAddress != null && this.DestinationAddress.Equals(filter.DestinationAddress) == false))
                return false;

            if (this.DestinationPort != filter.DestinationPort)
                return false;

            if ((this.SubBytes != null && filter.SubBytes == null) ||
                (this.SubBytes == null && filter.SubBytes != null) ||
                (this.SubBytes != null && filter.SubBytes != null && this.SubBytes.SequenceEqual(filter.SubBytes) == false))
                return false;

            if (this.MininumLength != filter.MininumLength)
                return false;

            if (this.MaximumLength != filter.MaximumLength)
                return false;

            if (this.Protocol != filter.Protocol)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
