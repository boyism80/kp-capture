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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
