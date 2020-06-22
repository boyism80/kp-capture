using KPCapture.Model;
using KPCapture.Model.Protocol;
using System;
using System.Windows;

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

        public FilterDialog(Channel.ViewModel vm)
        {
            this.Channel = vm;
            this.DataContext = this.Channel.Filter;
            InitializeComponent();
        }

        private void OnComplete(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Complete?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Cancel?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
