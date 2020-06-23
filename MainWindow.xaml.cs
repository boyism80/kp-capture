using Be.Windows.Forms;
using KPCapture.Dialog;
using KPCapture.Model.Protocol;
using Microsoft.Scripting.Utils;
using System.Linq;
using System.Windows;

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

        private void PacketsGridView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var item = e.AddedItems.Select(x => x as Packet.ViewModel).First();
                this.RawHexBox.ByteProvider = new DynamicByteProvider(item.Bytes);
                this.DecHexBox.ByteProvider = new DynamicByteProvider(item.DecryptedBytes);
            }
            catch
            {
                this.RawHexBox.ByteProvider = null;
                this.DecHexBox.ByteProvider = null;
            }
        }
    }
}
