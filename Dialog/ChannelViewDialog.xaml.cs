using Microsoft.Scripting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KPCapture.Dialog
{
    /// <summary>
    /// Interaction logic for ChannelViewDialog.xaml
    /// </summary>
    public partial class ChannelViewDialog : Window
    {
        public ViewModel.ChannelViewDialog vm { get; private set; }

        public List<ViewModel.Channel> Selected { get; private set; } = new List<ViewModel.Channel>();

        public event EventHandler Complete;

        public ChannelViewDialog(IEnumerable<ViewModel.Channel> attachedList)
        {
            InitializeComponent();

            vm = new ViewModel.ChannelViewDialog(attachedList);
            DataContext = vm;
        }

        private void OnComplete(object sender, RoutedEventArgs e)
        {
            if (Selected.Count == 0)
                return;

            Complete?.Invoke(this, EventArgs.Empty);

            foreach (var x in Selected)
                vm.Channels.Remove(x);

            //vm.OnPropertyChanged(nameof(vm.FilteredChannels));
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChannelListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Selected = ChannelListView.SelectedItems.Select(x => x as ViewModel.Channel).ToList();
        }
    }
}
