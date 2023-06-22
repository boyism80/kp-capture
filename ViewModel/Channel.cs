using KPCapture.Command;
using Microsoft.Scripting.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace KPCapture.ViewModel
{
    public class Channel : INotifyPropertyChanged
    {
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        public event PropertyChangedEventHandler PropertyChanged;

        public Model.Channel Model { get; private set; }

        public ObservableCollection<ViewModel.Packet> Packets { get; private set; } = new ObservableCollection<ViewModel.Packet>();
        public ObservableCollection<ViewModel.Packet> Filtered => new ObservableCollection<ViewModel.Packet>(Packets.Where(x => Filter.Pass(x)));

        public int Id => Model.Id;
        public string Name => Model.Name;
        public BitmapSource Icon { get; private set; }
        public ViewModel.Filter Filter { get; set; }
        public string RunIcon => Model.Packets.Enabled ? "/Image/play.png" : "/Image/pause.png";

        public ICommand RunCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }

        public Channel(Model.Channel channel)
        {
            Model = channel;
            Filter = new ViewModel.Filter(Model.Filter);
            Filter.PropertyChanged += Filter_PropertyChanged;
            Packets.CollectionChanged += Packets_CollectionChanged;
            RunCommand = new RelayCommand(OnRun);
            ClearCommand = new RelayCommand(Clear);

            try
            {
                var bitmap = System.Drawing.Icon.ExtractAssociatedIcon(Model.Process.MainModule.FileName).ToBitmap();
                var hBitmap = bitmap.GetHbitmap();
                var wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                if (!DeleteObject(hBitmap))
                    throw new Exception();

                Icon = wpfBitmap;
            }
            catch
            {
                Icon = null;
            }
        }

        private void Filter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filtered)));
        }

        private void Clear(object obj)
        {
            Packets.Clear();
        }

        private void OnRun(object obj)
        {
            Model.Packets.Enabled = !Model.Packets.Enabled;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RunIcon)));
        }

        private void Packets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Model.Packets.AddRange(e.NewItems.Select(x => (x as ViewModel.Packet).Model));
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var deleted in e.OldItems.Select(x => (x as ViewModel.Packet).Model))
                        Model.Packets.Remove(deleted);
                    break;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filtered)));
        }
    }
}
