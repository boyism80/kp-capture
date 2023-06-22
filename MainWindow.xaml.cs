using Be.Windows.Forms;
using Microsoft.Scripting.Utils;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KPCapture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _exitFlag = false;
        public ViewModel.MainWindow MainFormViewModel { get; private set; }

        public MainWindow()
        {
            MainFormViewModel = new ViewModel.MainWindow(this);
            DataContext = MainFormViewModel;
            InitializeComponent();

            new Task(OnDetectExitChannel).Start();
        }

        private void OnDetectExitChannel()
        {
            while (!_exitFlag)
            {
                try
                {
                    var runnings = Process.GetProcesses().Select(x => x.Id);
                    var exits = MainFormViewModel.Channels.Where(x => runnings.Contains(x.Id) == false).ToList();

                    Dispatcher.Invoke(() =>
                    {
                        foreach (var exit in exits)
                            MainFormViewModel.Channels.Remove(exit);
                    });
                }
                catch
                {
                    Thread.Sleep(500);
                }
            }
        }

        private void PacketsGridView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var item = e.AddedItems.Select(x => x as ViewModel.Packet).First();
                RawHexBox.ByteProvider = new DynamicByteProvider(item.Bytes);
                DecHexBox.ByteProvider = new DynamicByteProvider(item.DecryptedBytes);
            }
            catch
            {
                RawHexBox.ByteProvider = null;
                DecHexBox.ByteProvider = null;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _exitFlag = true;
        }
    }
}
