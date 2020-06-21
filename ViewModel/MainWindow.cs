using KPCapture.Command;
using KPCapture.Dialog;
using KPCapture.Model;
using KPCapture.Model.Protocol;
using KPCapture.Module;
using KPCapture.ViewModel;
using Microsoft.Scripting.Utils;
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
            public Channel.ViewModel SelectedChannel { get; private set; }
            public bool IsSelected { get => this.SelectedChannel != null; }

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

            public bool Running { get => this._watcher.Running; }
            public string StateText { get => this._watcher.Running ? "중단" : "캡처"; }

            public ICommand AddChannelCommand { get; private set; }
            public ICommand CaptureCommand { get; private set; }
            public ICommand ChannelRemoved { get; private set; }
            public ICommand ChannelDetail { get; private set; }
            public ICommand SetMinimizeCommand { get; set; }
            public ICommand SetMaximizeCommand { get; set; }
            public ICommand CloseCommand { get; set; }

            public ViewModel(MainWindow Owner)
            {
                this._owner = Owner;
                this._watcher = new Watcher(this);

                this.AddChannelCommand = new RelayCommand(this.OnAddChannel);
                this.CaptureCommand = new RelayCommand(this.OnCapture);
                this.ChannelRemoved = new RelayCommand(this.OnChannelRemoved);
                this.ChannelDetail = new RelayCommand(this.OnChannelDetail);
                this.SetMinimizeCommand = new RelayCommand(this.OnSetMinimize);
                this.SetMaximizeCommand = new RelayCommand(this.OnSetMaximize);
                this.CloseCommand = new RelayCommand(this.OnClose);
            }

            private void OnChannelDetail(object obj)
            {
                var vm = obj as Channel.ViewModel;
                this.SelectedChannel = vm;

                this._owner.MainTab.SelectedIndex = 1;
            }

            private void OnChannelRemoved(object obj)
            {
                var vm = obj as Channel.ViewModel;
                this.Channels.Remove(vm);

                if (this.SelectedChannel == vm)
                    this.SelectedChannel = null;
            }

            private void OnCapture(object obj)
            {
                if (this._watcher.Running)
                    this._watcher.Stop();
                else
                    this._watcher.Start(this._owner.HostEntryBox.SelectedItem as string);

                this.OnPropertyChanged(nameof(this.StateText));
                this.OnPropertyChanged(nameof(this.Running));
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
                foreach (var vm in this._channelViewDialog.Selected)
                    this.Channels.Add(vm);
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

                this._owner.Dispatcher.BeginInvoke(new Action(() => 
                {
                    foreach (var channel in channels)
                        channel.Packets.Add(new Packet.ViewModel((uint)channel.Packets.Count + 1, packet));
                }));
            }

            public void OnSetMinimize(object parameter)
            {
                this._owner.WindowState = System.Windows.WindowState.Minimized;
            }

            public void OnSetMaximize(object parameter)
            {
                this._owner.WindowState ^= System.Windows.WindowState.Maximized;
            }

            public void OnClose(object parameter)
            {
                this._owner.Close();
            }
        }
    }
}
