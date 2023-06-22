using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace KPCapture.Model
{
    public class PacketContainer : IList<Packet>
    {
        private List<Packet> _packets = new List<Packet>();

        public bool Enabled { get; set; } = true;

        public Packet this[int index] { get => _packets[index]; set => _packets[index] = value; }

        public int Count => _packets.Count;

        public bool IsReadOnly => false;

        public void Add(Packet item)
        {
            if (Enabled)
                _packets.Add(item);
        }

        public void Clear()
        {
            _packets.Clear();
        }

        public bool Contains(Packet item)
        {
            return _packets.Contains(item);
        }

        public void CopyTo(Packet[] array, int arrayIndex)
        {
            _packets.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Packet> GetEnumerator()
        {
            return _packets.GetEnumerator();
        }

        public int IndexOf(Packet item)
        {
            return _packets.IndexOf(item);
        }

        public void Insert(int index, Packet item)
        {
            _packets.Insert(index, item);
        }

        public bool Remove(Packet item)
        {
            return _packets.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _packets.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _packets.GetEnumerator();
        }
    }

    public class Channel
    {
        public Process Process { get; private set; }
        public int Id => Process?.Id ?? -1;
        public string Name => Process?.ProcessName ?? string.Empty;
        public PacketContainer Packets { get; private set; } = new PacketContainer();
        public Filter Filter { get; private set; } = new Filter();
        

        public Channel(Process process)
        {
            Process = process;
        }
    }
}
