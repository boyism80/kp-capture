using KPCapture.Model.Protocol;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace KPCapture.Model
{
    public class PacketContainer : IList<Packet>
    {
        private List<Packet> _packets = new List<Packet>();

        public bool Enabled { get; set; } = true;

        public Packet this[int index] { get => this._packets[index]; set => this._packets[index] = value; }

        public int Count => this._packets.Count;

        public bool IsReadOnly => false;

        public void Add(Packet item)
        {
            if (this.Enabled)
                this._packets.Add(item);
        }

        public void Clear()
        {
            this._packets.Clear();
        }

        public bool Contains(Packet item)
        {
            return this._packets.Contains(item);
        }

        public void CopyTo(Packet[] array, int arrayIndex)
        {
            this._packets.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Packet> GetEnumerator()
        {
            return this._packets.GetEnumerator();
        }

        public int IndexOf(Packet item)
        {
            return this._packets.IndexOf(item);
        }

        public void Insert(int index, Packet item)
        {
            this._packets.Insert(index, item);
        }

        public bool Remove(Packet item)
        {
            return this._packets.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this._packets.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._packets.GetEnumerator();
        }
    }

    public partial class Channel
    {
        private Process _process;

        public int Id { get => this._process?.Id ?? -1; }
        public string Name { get => this._process?.ProcessName ?? string.Empty; }
        public PacketContainer Packets { get; private set; } = new PacketContainer();
        public Filter Filter { get; private set; } = new Filter();
        

        public Channel(Process process)
        {
            this._process = process;
        }
    }
}
