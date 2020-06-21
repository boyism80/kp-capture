using KPCapture.Model;
using KPCapture.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace KPCapture.Dialog
{
    public partial class ChannelViewDialog
    {
        public class ViewModel : BaseViewModel
        {
            public ObservableCollection<Channel.ViewModel> Channels { get; private set; } = new ObservableCollection<Channel.ViewModel>();
            public ObservableCollection<Channel.ViewModel> FilteredChannels
            {
                get => new ObservableCollection<Channel.ViewModel>(this.Channels.Where(x => x.Name.IndexOf(this.FilterName, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            public string FilterName { get; set; } = string.Empty;
            
            public ViewModel(IEnumerable<Channel> attachedList)
            {
                foreach (var vm in Process.GetProcesses()
                                                .Where(x => attachedList.Select(c => c.Id).Contains(x.Id) == false)
                                                .Select(x => new Channel.ViewModel(new Channel(x)))
                                                .Where(x => x.Icon != null)
                                                .OrderBy(x => x.Name))
                {
                    try
                    {
                        this.Channels.Add(vm);
                    }
                    catch(Exception e)
                    {
#if DEBUG
                        Console.WriteLine(e.Message);
#endif
                    }
                }
            }
        }
    }
}
