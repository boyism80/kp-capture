using KPCapture.Command;
using KPCapture.Dialog;
using KPCapture.Model;
using KPCapture.Module;
using Microsoft.Scripting.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace KPCapture.ViewModel
{
    public class MainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private KPCapture.MainWindow _owner; // TODO: Model.MainWindow
        private Watcher _watcher = new Watcher();
        private KPCapture.Dialog.ChannelViewDialog _channelViewDialog;
        private EditFilterDialog _filterDialog;

        public ObservableCollection<ViewModel.Channel> Channels { get; private set; } = new ObservableCollection<ViewModel.Channel>();
        public ObservableCollection<ViewModel.Channel> FilteredChannels
        {
            get
            {
                return new ObservableCollection<ViewModel.Channel>(Channels.Where(x =>
                {
                    if (string.IsNullOrEmpty(ChannelFilterText))
                        return true;

                    return $"{x.Id}".IndexOf(ChannelFilterText, StringComparison.OrdinalIgnoreCase) >= 0 || x.Name.IndexOf(ChannelFilterText, StringComparison.OrdinalIgnoreCase) >= 0;
                }));
            }
        }
        public ViewModel.Channel SelectedChannel { get; private set; }
        public bool IsSelected => SelectedChannel != null;
        public Visibility SelectedVisibility => IsSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility NotSelectedVisibility => IsSelected ? Visibility.Collapsed : Visibility.Visible;
        public bool IsChannelEmpty => Channels.Count == 0;
        public Visibility EmptyScreenVisiblity => IsChannelEmpty ? Visibility.Visible : Visibility.Collapsed;
        public string ChannelFilterText { get; set; }

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

        public bool Running => _watcher.Running;
        public bool Disabled => !Running;
        public string StateText => _watcher.Running ? "중단" : "캡처";

        public ICommand AddChannelCommand { get; private set; }
        public ICommand CaptureCommand { get; private set; }
        public ICommand ChannelRemoved { get; private set; }
        public ICommand ChannelDetail { get; private set; }
        public ICommand ChannelFilter { get; private set; }
        public ICommand SetMinimizeCommand { get; private set; }
        public ICommand SetMaximizeCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }

        public MainWindow(KPCapture.MainWindow owner)
        {
            _owner = owner;
            _watcher.Received += OnReceive;
            _watcher.Error += OnError;
            Channels.CollectionChanged += Channels_CollectionChanged;

            AddChannelCommand = new RelayCommand(OnAddChannel);
            CaptureCommand = new RelayCommand(OnCapture);
            ChannelRemoved = new RelayCommand(OnChannelRemoved);
            ChannelDetail = new RelayCommand(OnChannelDetail);
            ChannelFilter = new RelayCommand(OnChannelFilter);
            SetMinimizeCommand = new RelayCommand(OnSetMinimize);
            SetMaximizeCommand = new RelayCommand(OnSetMaximize);
            CloseCommand = new RelayCommand(OnClose);
            FilterCommand = new RelayCommand(OnFilterButtonClicked);
        }

        private void Channels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilteredChannels)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChannelEmpty)));
        }

        private void OnChannelFilter(object obj)
        {
            SelectedChannel = obj as ViewModel.Channel;
            OnFilterButtonClicked(obj);
        }

        private void OnFilterButtonClicked(object obj)
        {
            if (IsSelected == false)
                return;

            if (_filterDialog == null)
            {
                _filterDialog = new EditFilterDialog(SelectedChannel)
                {
                    Owner = _owner,
                };
                _filterDialog.Cancel += (sender, e) => 
                {
                    SelectedChannel.Filter = _filterDialog.Origin;
                };
                _filterDialog.Closed += (sender, e) => 
                {
                    _filterDialog = null;
                };
                _filterDialog.Show();
            }
            else if (_filterDialog.Channel != SelectedChannel)
            {
                _filterDialog.Channel = SelectedChannel;
            }
            else
            {
                return;
            }
        }

        private void OnChannelDetail(object obj)
        {
            var vm = obj as ViewModel.Channel;
            SelectedChannel = vm;

            _owner.MainTab.SelectedIndex = 1;
        }

        private void OnChannelRemoved(object obj)
        {
            var vm = obj as ViewModel.Channel;
            Channels.Remove(vm);

            if (SelectedChannel == vm)
                SelectedChannel = null;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChannelEmpty)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmptyScreenVisiblity)));
        }

        private void OnCapture(object obj)
        {
            if (_watcher.Running)
                _watcher.Stop();
            else
                _watcher.Start(_owner.HostEntryBox.SelectedItem as string);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StateText)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Running)));
        }

        private void OnAddChannel(object obj)
        {
            if (_channelViewDialog != null)
                return;

            _channelViewDialog = new KPCapture.Dialog.ChannelViewDialog(Channels)
            {
                Owner = _owner,
            };
            _channelViewDialog.Closed += _channelViewDialog_Closed;
            _channelViewDialog.Complete += _channelViewDialog_Complete;
            _channelViewDialog.Show();
        }

        private void _channelViewDialog_Complete(object sender, EventArgs e)
        {
            foreach (var vm in _channelViewDialog.Selected)
            {
                Channels.Add(vm);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChannelEmpty)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmptyScreenVisiblity)));
        }

        private void _channelViewDialog_Closed(object sender, EventArgs e)
        {
            _channelViewDialog = null;
        }

        public void OnError(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public void OnReceive(Model.Packet packet)
        {
            IEnumerable<ViewModel.Channel> channels;

            switch (packet.ProtocolType)
            {
                case ProtocolType.TCP:
                    {
                        channels = TCPTable.FindProcessId(packet)
                            .Select(x => Channels.FirstOrDefault(c => c.Model.Id == x))
                            .Where(x => x != null);
                    }
                    break;

                case ProtocolType.UDP:
                    {
                        channels = UDPTable.FindProcessId(packet)
                            .Select(x => Channels.FirstOrDefault(c => c.Model.Id == x))
                            .Where(x => x != null);
                    }
                    break;

                default:
                    return;
            }

            _owner.Dispatcher.BeginInvoke(new Action(() =>
            {
                foreach (var channel in channels)
                    channel.Packets.Add(new ViewModel.Packet(channel.Model, packet));
            }));
        }

        public void OnSetMinimize(object parameter)
        {
            _owner.WindowState = System.Windows.WindowState.Minimized;
        }

        public void OnSetMaximize(object parameter)
        {
            _owner.WindowState ^= System.Windows.WindowState.Maximized;
        }

        public void OnClose(object parameter)
        {
            _owner.Close();
        }
    }
}
