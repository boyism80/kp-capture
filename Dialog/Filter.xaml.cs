using KPCapture.Model;
using KPCapture.Model.Protocol;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace KPCapture.Dialog
{
    /// <summary>
    /// Interaction logic for FilterDialog.xaml
    /// </summary>
    public partial class FilterDialog : Window
    {
        private Channel.ViewModel _channel;
        public Channel.ViewModel Channel
        {
            get => this._channel;
            set 
            {
                this._channel = value;
                this.Before = new Filter.ViewModel(this._channel.Filter);
            }
        }
        public Filter.ViewModel Before { get; private set; }

        public event EventHandler Complete;
        public event EventHandler Cancel;
        public event EventHandler<string> ScriptChanged;

        public FilterDialog(Channel.ViewModel vm)
        {
            this.Channel = vm;
            this.DataContext = this.Channel.Filter;
            InitializeComponent();
        }

        private void OnComplete(object sender, RoutedEventArgs e)
        {
            this.Complete?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.Cancel?.Invoke(this, EventArgs.Empty);
            this.Close();
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

            if (dialog.ShowDialog(this.Owner) == true)
            {
                this.Contents.Text = File.ReadAllText(dialog.FileName);
                this.ScriptChanged?.Invoke(this, dialog.FileName);
            }
        }

        private void OnScriptChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (this.Contents == null)
                return;

            try
            {
                var path = (sender as TextBox).Text;
                this.Contents.Text = File.ReadAllText(path);
            }
            catch
            {
                this.Contents.Text = string.Empty;
            }
        }
    }
}
