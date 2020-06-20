using KPCapture.Command;
using KPCapture.Dialog;
using KPCapture.Model;
using KPCapture.Model.Protocol;
using KPCapture.Module;
using KPCapture.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            private ChannelViewDialog _channelViewDialog;

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

            public string StateText { get => this._watcher.Running ? "중단" : "캡처"; }

            public ICommand AddChannelCommand { get; private set; }
            public ICommand CaptureCommand { get; private set; }

            public ViewModel(MainWindow Owner)
            {
                this._owner = Owner;
                this._watcher = new Watcher(this);

                this.AddChannelCommand = new RelayCommand(this.OnAddChannel);
                this.CaptureCommand = new RelayCommand(this.OnCapture);
            }

            private void OnCapture(object obj)
            {
                if (this._watcher.Running)
                    this._watcher.Stop();
                else
                    this._watcher.Start(this._owner.HostEntryBox.SelectedItem as string);

                this.OnPropertyChanged(nameof(this.StateText));
            }

            private void OnAddChannel(object obj)
            {
                if (this._channelViewDialog != null)
                    return;

                this._channelViewDialog = new ChannelViewDialog(this.Channels.Select(x => x.Data))
                {
                    Owner = this._owner,
                };
                this._channelViewDialog.Closed += this._channelViewDialog_Closed;
                this._channelViewDialog.Complete += this._channelViewDialog_Complete;
                this._channelViewDialog.Show();
            }

            private void _channelViewDialog_Complete(object sender, EventArgs e)
            {
                if(this._channelViewDialog.Selected != null)
                    this.Channels.Add(this._channelViewDialog.Selected);
            }

            private void _channelViewDialog_Closed(object sender, EventArgs e)
            {
                this._channelViewDialog = null;
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
