using KPCapture.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KPCapture.Control
{
    /// <summary>
    /// Interaction logic for ChannelControl.xaml
    /// </summary>
    public partial class ChannelControl : UserControl
    {
        public Action<Channel.ViewModel> Remove { get; set; }
        public Action<Channel.ViewModel> Detail { get; set; }

        public ChannelControl()
        {
            InitializeComponent();
        }

        private void OnRemove(object sender, RoutedEventArgs e)
        {
            this.Remove?.Invoke(this.DataContext as Channel.ViewModel);
        }

        private void OnDetail(object sender, RoutedEventArgs e)
        {
            this.Detail?.Invoke(this.DataContext as Channel.ViewModel);
        }
    }
}
