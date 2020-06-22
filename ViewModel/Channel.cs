using KPCapture.Command;
using KPCapture.Model.Protocol;
using KPCapture.ViewModel;
using Microsoft.Scripting.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace KPCapture.Model
{
    public partial class Channel
    {
        public class ViewModel : BaseViewModel
        {
            [DllImport("gdi32.dll", SetLastError = true)]
            private static extern bool DeleteObject(IntPtr hObject);

            public Channel Data { get; private set; }

            public ObservableCollection<Packet.ViewModel> Packets { get; private set; } = new ObservableCollection<Packet.ViewModel>();
            public ObservableCollection<Packet.ViewModel> Filtered
            {
                get
                {
                    return new ObservableCollection<Packet.ViewModel>(this.Packets.Where(x => this.Filter.Pass(x)));
                }
            }

            public int Id { get => this.Data.Id; }
            public string Name { get => this.Data.Name; }
            public BitmapSource Icon { get; private set; }
            public Filter.ViewModel Filter { get; set; }

            public ICommand RunCommand { get; private set; }
            public ICommand ClearCommand { get; private set; }

            public string RunIcon
            {
                get => this.Data.Packets.Enabled ? "/Image/play.png" : "/Image/pause.png";
            }

            public ViewModel(Channel channel)
            {
                this.Data = channel;
                this.Filter = new Filter.ViewModel(this.Data.Filter);
                this.Packets.CollectionChanged += this.Packets_CollectionChanged;
                this.RunCommand = new RelayCommand(this.OnRun);
                this.ClearCommand = new RelayCommand(this.Clear);

                try
                {
                    var bitmap = System.Drawing.Icon.ExtractAssociatedIcon(this.Data._process.MainModule.FileName).ToBitmap();
                    IntPtr hBitmap = bitmap.GetHbitmap();

                    var wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                        hBitmap,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());

                    if (!DeleteObject(hBitmap))
                        throw new Exception();

                    this.Icon = wpfBitmap;
                }
                catch
                {
                    this.Icon = null;
                }
            }

            private void Clear(object obj)
            {
                this.Packets.Clear();
            }

            private void OnRun(object obj)
            {
                this.Data.Packets.Enabled = !this.Data.Packets.Enabled;
                this.OnPropertyChanged(nameof(this.RunIcon));
            }

            private void Packets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        this.Data.Packets.AddRange(e.NewItems.Select(x => (x as Packet.ViewModel).Data));
                        break;

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (var deleted in e.OldItems.Select(x => (x as Packet.ViewModel).Data))
                            this.Data.Packets.Remove(deleted);
                        break;
                }

                this.OnPropertyChanged(nameof(this.Filtered));
            }
        }
    }
}
