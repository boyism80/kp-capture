using System;
using System.ComponentModel;

namespace KPCapture.ViewModel
{
    public class Packet : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private byte[] _decryptedBytesCache;
        public byte[] DecryptedBytes
        {
            get
            {
                if (_decryptedBytesCache == null)
                    _decryptedBytesCache = Owner.Filter.Decrypt(Model);

                return _decryptedBytesCache;
            }
        }

        public Model.Packet Model { get; private set; }
        public Model.Channel Owner { get; private set; }
        public uint Index { get; private set; }
        public string Source { get => $"{Model.SourceAddress}:{Model.SourcePort}"; }
        public string Destination { get => $"{Model.DestinationAddress}:{Model.DestinationPort}"; }
        public string HexBytes { get => BitConverter.ToString(Model.Bytes).Replace('-', ' '); }
        public byte[] Bytes { get => Model.Bytes; }
        public string TimeStamp { get => Model.DateTime.ToString("yyyy/MM/dd HH:mm:ss"); }
        public string Protocol { get => Model.ProtocolType.ToString(); }

        public Packet(Model.Channel model, Model.Packet packet)
        {
            Owner = model;
            Index = (uint)Owner.Packets.Count + 1;
            Model = packet;
        }
    }
}
