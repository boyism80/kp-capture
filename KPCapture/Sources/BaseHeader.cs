using System.Collections.Generic;

namespace KPU.Sources
{
    public abstract class BaseHeader
    {
        private byte[] _bytes;

        protected BaseHeader(byte[] bytes, int recvsize)
        { }

        public abstract uint SourcePort { get; }

        public abstract uint DestinationPort { get; }

        public abstract int Checksum { get; }

        public byte[] Bytes
        {

            get
            {
                if (this._bytes == null)
                    return new List<byte>().ToArray();
                else
                    return this._bytes;
            }

            protected set
            {
                this._bytes         = value;
            }
        }

        public int Length
        {
            get
            {
                return this.Bytes.Length;
            }
        }
    }
}