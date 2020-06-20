using KPCapture.Command;
using KPCapture.Dialog;
using KPCapture.Model;
using KPCapture.Model.Protocol;
using KPCapture.Module;
using KPCapture.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Input;

namespace KPCapture
{
    public partial class MainWindow
    {
        public class ViewModel : BaseViewModel, Watcher.IListener
        {
            private MainWindow _owner;
            private Watcher _watcher;

            public ObservableCollection<Channel.ViewModel> Channels { get; private set; } = new ObservableCollection<Channel.ViewModel>();

            public List<string> HostEntries 
            {
                get 
                {
                    return Dns.GetHostEntry(Dns.GetHostName())
                        .AddressList.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        .Select(x => x.ToString())
                        .ToList();
                } 
            }

            public ICommand AddChannelCommand { get; set; }

            public ViewModel(MainWindow Owner)
            {
                this._owner = Owner;
                this._watcher = new Watcher(this);

                this.AddChannelCommand = new RelayCommand(this.OnAddChannel);
            }

            private void OnAddChannel(object obj)
            {
                var dialog = new ChannelViewDialog(this.Channels.Select(x => x.Data))
                {
                    Owner = this._owner,
                };
                dialog.Show();
            }

            public void OnError(string message)
            {
                Console.WriteLine(message);
            }

            public void OnReceive(Packet packet)
            {
                IEnumerable<Channel.ViewModel> channels;

                switch (packet.Protocol)
                {
                    case Model.Protocol.Header.Protocol.TCP:
                        {
                            channels = TCPTable.FindProcessId(packet)
                                .Select(x => this.Channels.FirstOrDefault(c => c.Data.Id == x))
                                .Where(x => x != null);
                        }
                        break;

                    case Model.Protocol.Header.Protocol.UDP:
                        {
                            channels = UDPTable.FindProcessId(packet)
                                .Select(x => this.Channels.FirstOrDefault(c => c.Data.Id == x))
                                .Where(x => x != null);
                        }
                        break;

                    default:
                        return;
                }

                foreach (var channel in channels)
                    channel.Packets.Add(new Packet.ViewModel(packet));
            }
        }
    }
}
