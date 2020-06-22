using KPCapture.Model;
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
        public ViewModel vm { get; private set; }

        public List<Channel.ViewModel> Selected { get; private set; } = new List<Channel.ViewModel>();

        public event EventHandler Complete;

        public ChannelViewDialog(IEnumerable<Channel> attachedList)
        {
            InitializeComponent();

            this.vm = new ViewModel(attachedList);
            this.DataContext = this.vm;
        }

        private void OnComplete(object sender, RoutedEventArgs e)
        {
            if (this.Selected.Count == 0)
                return;

            this.Complete?.Invoke(this, EventArgs.Empty);

            foreach (var x in this.Selected)
                this.vm.Channels.Remove(x);

            this.vm.OnPropertyChanged(nameof(this.vm.FilteredChannels));
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChannelListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.Selected = this.ChannelListView.SelectedItems.Select(x => x as Channel.ViewModel).ToList();
        }
    }
}
