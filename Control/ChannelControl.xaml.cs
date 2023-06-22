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
        public Action<ViewModel.Channel> Remove { get; set; }
        public Action<ViewModel.Channel> Detail { get; set; }
        public Action<ViewModel.Channel> Filter { get; set; }

        public ChannelControl()
        {
            InitializeComponent();
        }

        private void OnRemove(object sender, RoutedEventArgs e)
        {
            Remove?.Invoke(DataContext as ViewModel.Channel);
        }

        private void OnDetail(object sender, RoutedEventArgs e)
        {
            Detail?.Invoke(DataContext as ViewModel.Channel);
        }

        private void OnFilter(object sender, RoutedEventArgs e)
        {
            Filter?.Invoke(DataContext as ViewModel.Channel);
        }
    }
}
