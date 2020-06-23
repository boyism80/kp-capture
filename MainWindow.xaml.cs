using Be.Windows.Forms;
using KPCapture.Model.Protocol;
using Microsoft.Scripting.Utils;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;

namespace KPCapture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread _detectExitChannelThread;

        public ViewModel MainFormViewModel { get; private set; }

        public MainWindow()
        {
            this.MainFormViewModel = new ViewModel(this);
            this.DataContext = this.MainFormViewModel;
            InitializeComponent();

            this._detectExitChannelThread = new Thread(this.OnDetectExitChannel);
            this._detectExitChannelThread.Start();
        }

        private void OnDetectExitChannel()
        {
            while (true)
            {
                var runnings = Process.GetProcesses().Select(x => x.Id);
                var exits = this.MainFormViewModel.Channels.Where(x => runnings.Contains(x.Id) == false).ToList();

                this.Dispatcher.Invoke(() => 
                {
                    foreach (var exit in exits)
                        this.MainFormViewModel.Channels.Remove(exit);
                });
            }
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detectExitChannelThread.Abort();
        }
    }
}
