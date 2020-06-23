using KPCapture.ViewModel;
using System;

namespace KPCapture.Model.Protocol
{
    public partial class Packet
    {
        public class ViewModel : BaseViewModel
        {
            private byte[] _decryptedBytesCache;
            public byte[] DecryptedBytes
            {
                get 
                {
                    if (this._decryptedBytesCache == null)
                        this._decryptedBytesCache = this.Owner.Filter.Decrypt(this);

                    return this._decryptedBytesCache;
                }
            }

            public Packet Data { get; private set; }
            public Channel.ViewModel Owner { get; private set; }
            public uint Index { get; private set; }
            public string Source { get => $"{this.Data.SourceAddress}:{this.Data.SourcePort}"; }
            public string Destination { get => $"{this.Data.DestinationAddress}:{this.Data.DestinationPort}"; }
            public string HexBytes { get => BitConverter.ToString(this.Data.Bytes).Replace('-', ' '); }
            public byte[] Bytes { get => this.Data.Bytes; }
            public string TimeStamp { get => this.Data.DateTime.ToString("yyyy/MM/dd HH:mm:ss"); }
            public string Protocol { get => this.Data.Protocol.ToString(); }

            public ViewModel(Channel.ViewModel owner, Packet packet)
            {
                this.Owner = owner;
                this.Index = (uint)this.Owner.Packets.Count + 1;
                this.Data = packet;
            }
        }
    }
}
