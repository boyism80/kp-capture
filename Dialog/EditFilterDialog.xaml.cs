using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace KPCapture.Dialog
{
    /// <summary>
    /// Interaction logic for FilterDialog.xaml
    /// </summary>
    public partial class EditFilterDialog : Window
    {
        private Model.Filter _origin;
        public ViewModel.Filter Origin => new ViewModel.Filter(_origin);

        private ViewModel.Channel _channel;
        public ViewModel.Channel Channel
        {
            get => _channel;
            set 
            {
                if (_channel != null)
                {
                    _channel.Filter = new ViewModel.Filter(_origin);
                }

                _channel = value;
                _origin = _channel.Filter.Model.Clone();
            }
        }

        public event EventHandler Complete;
        public event EventHandler Cancel;
        public event EventHandler<string> ScriptChanged;

        public EditFilterDialog(ViewModel.Channel vm)
        {
            Channel = vm;
            DataContext = Channel.Filter;
            InitializeComponent();
        }

        private void OnComplete(object sender, RoutedEventArgs e)
        {
            Complete?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Cancel?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void OnFindScript(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Title = "Python script",
                Multiselect = false,
                DefaultExt = "py",
                Filter = "Python script file (*.py)|*.py"
            };

            if (dialog.ShowDialog(Owner) == true)
            {
                Contents.Text = File.ReadAllText(dialog.FileName);
                ScriptChanged?.Invoke(this, dialog.FileName);
            }
        }

        private void OnScriptChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Contents == null)
                return;

            try
            {
                var path = (sender as TextBox).Text;
                Contents.Text = File.ReadAllText(path);
            }
            catch
            {
                Contents.Text = string.Empty;
            }
        }
    }
}
