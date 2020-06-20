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

        public ChannelControl()
        {
            InitializeComponent();
        }

        private void OnRemove(object sender, RoutedEventArgs e)
        {
            Remove?.Invoke(this.DataContext as Channel.ViewModel);
        }
    }
}
