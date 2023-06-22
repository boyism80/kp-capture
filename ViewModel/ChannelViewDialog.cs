using KPCapture.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace KPCapture.ViewModel
{
    public class ChannelViewDialog : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ViewModel.Channel> Channels { get; private set; } = new ObservableCollection<ViewModel.Channel>();
        public ObservableCollection<ViewModel.Channel> FilteredChannels
        {
            get => new ObservableCollection<ViewModel.Channel>(Channels.Where(x => x.Name.IndexOf(FilterName, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        public string FilterName { get; set; } = string.Empty;

        public ChannelViewDialog(IEnumerable<ViewModel.Channel> attachedList)
        {
            var channels = Process.GetProcesses()
                                  .Where(x => attachedList.Select(c => c.Id).Contains(x.Id) == false)
                                  .Select(x => new ViewModel.Channel(new Model.Channel(x)))
                                  .Where(x => x.Icon != null)
                                  .OrderBy(x => x.Name);
            foreach (var ch in channels)
            {
                try
                {
                    Channels.Add(ch);
                }
                catch (Exception e)
                {
#if DEBUG
                    Console.WriteLine(e.Message);
#endif
                }
            }
        }
    }
}
