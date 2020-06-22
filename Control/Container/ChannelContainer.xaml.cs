using KPCapture.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KPCapture.Control.Container
{
    /// <summary>
    /// Interaction logic for ChannelContainer.xaml
    /// </summary>
    public partial class ChannelContainer : ItemsSourceControl
    {
        public static readonly DependencyProperty RemoveProperty = DependencyProperty.Register("Remove", typeof(ICommand), typeof(ChannelContainer));
        public ICommand Remove
        {
            get { return GetValue(RemoveProperty) as ICommand; }
            set { SetValue(RemoveProperty, value); }
        }

        public static readonly DependencyProperty DetailProperty = DependencyProperty.Register("Detail", typeof(ICommand), typeof(ChannelContainer));
        public ICommand Detail
        {
            get { return GetValue(DetailProperty) as ICommand; }
            set { SetValue(DetailProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(ICommand), typeof(ChannelContainer));
        public ICommand Filter
        {
            get { return GetValue(FilterProperty) as ICommand; }
            set { SetValue(FilterProperty, value); }
        }

        public ChannelContainer()
        {
            InitializeComponent();
        }

        public override Panel GetContainer()
        {
            return this.Container;
        }

        public override FrameworkElement OnCreate(object context)
        {
            return new ChannelControl
            {
                DataContext = context,
                Remove = this.OnRemove,
                Detail = this.OnDetail,
                Filter = this.OnFilter
            };
        }

        private void OnFilter(Channel.ViewModel obj)
        {
            this.Filter?.Execute(obj);
        }

        private void OnDetail(Channel.ViewModel obj)
        {
            this.Detail?.Execute(obj);
        }

        private void OnRemove(Channel.ViewModel obj)
        {
            this.Remove?.Execute(obj);
        }
    }
}
