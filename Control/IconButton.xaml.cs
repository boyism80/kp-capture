using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KPCapture.Control
{
    /// <summary>
    /// Interaction logic for IconButton.xaml
    /// </summary>
    public partial class IconButton : Button
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(IconButton));
        public ImageSource Icon
        {
            get { return GetValue(IconProperty) as ImageSource; }
            set { SetValue(IconProperty, value); }
        }


        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(int), typeof(IconButton), new FrameworkPropertyMetadata(16));
        public int IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(IconButton), new FrameworkPropertyMetadata(new Thickness(3)));
        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        public IconButton()
        {
            InitializeComponent();
        }
    }
}
