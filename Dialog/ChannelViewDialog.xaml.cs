using KPCapture.Model;
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

        public ChannelViewDialog(IEnumerable<Channel> attachedList)
        {
            InitializeComponent();

            this.vm = new ViewModel(attachedList);
            this.DataContext = this.vm;
        }
    }
}
