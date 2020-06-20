﻿using KPCapture.Model.Protocol;
using KPCapture.ViewModel;
using Microsoft.Scripting.Utils;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
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

            public string Name { get => this.Data.Name; }

            public BitmapSource Icon { get; private set; }

            public ViewModel(Channel channel)
            {
                this.Data = channel;
                this.Packets.CollectionChanged += this.Packets_CollectionChanged;

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
            }
        }
    }
}