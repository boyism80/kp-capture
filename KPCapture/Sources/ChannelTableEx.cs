using KPU.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KPU.Sources
{
    public class ChannelPool : IEnumerable
    {
        private Dictionary<int, ChannelItem>     _dictionary;

        public ChannelPool()
        {
            this._dictionary        = new Dictionary<int, ChannelItem>();
        }

        public static implicit operator Channel[](ChannelPool table)
        {
            return table._dictionary.Select(pair => pair.Value).Select(item => item.Channel).ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            lock (this._dictionary)
            {
                return this._dictionary.Values.Select(item => item.Channel).GetEnumerator();
            }
        }

        public Channel this[int i]
        {
            get
            {
                return this._dictionary[i].Channel;
            }
        }

        public ChannelItem Add(Channel channel, ChannelItem.ChannelButtonClickEvent buttonClickEvent)
        {
            var item                = new ChannelItem(channel);
            item.Dock               = DockStyle.Top;
            item.ButtonClickEvent   = buttonClickEvent;

            lock (this._dictionary)
            {
                this._dictionary.Add(channel.Id, item);
            }
            return item;
        }

        public ChannelItem GetItem(int pid)
        {
            return this._dictionary[pid];
        }

        public bool Contains(int pid)
        {
            return this._dictionary.ContainsKey(pid);
        }

        public void Remove(int pid)
        {
            var item                 = this.GetItem(pid);
            item.Invoke(new MethodInvoker(delegate()
                                          {
                                              // 1. Remove control
                                              item.Parent.Controls.Remove(item);

                                              // 2. Remove control
                                              this._dictionary.Remove(pid);
                                          }));
        }
    }
}