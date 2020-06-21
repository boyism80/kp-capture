using System;
using System.Windows;
using System.Linq;
using Microsoft.Scripting.Utils;
using KPCapture.Model.Protocol;
using Be.Windows.Forms;

namespace KPCapture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel MainFormViewModel { get; private set; }

        public MainWindow()
        {
            this.MainFormViewModel = new ViewModel(this);

            InitializeComponent();
            this.DataContext = this.MainFormViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void PacketsGridView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var item = e.AddedItems.Select(x => x as Packet.ViewModel).First();
                this.RawHexBox.ByteProvider = new DynamicByteProvider(item.Bytes);
                this.DecHexBox.ByteProvider = new DynamicByteProvider(item.Bytes);
            }
            catch
            {
                this.RawHexBox.ByteProvider = null;
                this.DecHexBox.ByteProvider = null;
            }
        }
    }
}
