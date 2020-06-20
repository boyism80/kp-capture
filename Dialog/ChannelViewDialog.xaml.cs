using KPCapture.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace KPCapture.Dialog
{
    /// <summary>
    /// Interaction logic for ChannelViewDialog.xaml
    /// </summary>
    public partial class ChannelViewDialog : Window
    {
        public ViewModel vm { get; private set; }

        public Channel.ViewModel Selected { get; private set; }

        public event EventHandler Complete;

        public ChannelViewDialog(IEnumerable<Channel> attachedList)
        {
            InitializeComponent();

            this.vm = new ViewModel(attachedList);
            this.DataContext = this.vm;
        }

        private void OnComplete(object sender, RoutedEventArgs e)
        {
            this.Selected = this.ChannelListView.SelectedItem as Channel.ViewModel;
            this.vm.Channels.Remove(this.Selected);
            this.Complete?.Invoke(this, EventArgs.Empty);
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
