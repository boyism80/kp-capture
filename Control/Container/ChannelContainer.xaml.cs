using System.Windows;
using System.Windows.Controls;

namespace KPCapture.Control.Container
{
    /// <summary>
    /// Interaction logic for ChannelContainer.xaml
    /// </summary>
    public partial class ChannelContainer : ItemsSourceControl
    {
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
            };
        }
    }
}
