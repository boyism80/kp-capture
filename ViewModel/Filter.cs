using KPCapture.ViewModel;
using Microsoft.Scripting.Utils;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace KPCapture.Model.Protocol
{
    public partial class Filter
    {
        public class ViewModel : BaseViewModel
        {
            private Filter _data;

            public IPAddress Source
            {
                get => this._data.Source;
                set => this._data.Source = value;
            }

            public int? SourcePort
            {
                get => this._data.SourcePort;
                set => this._data.SourcePort = value;
            }

            private string _sourceAddressText = string.Empty;
            public string SourceAddressText
            {
                get => this._sourceAddressText;
                set
                {
                    try
                    {
                        var splitted = value.Split(':');
                        if (splitted.Length == 0)
                            throw new Exception();

                        if (splitted.Length == 1)
                        {
                            this.Source = IPAddress.Parse(value);
                            this.SourcePort = null;
                        }
                        else
                        {
                            this.Source = IPAddress.Parse(splitted[0]);
                            this.SourcePort = int.Parse(splitted[1]);
                        }
                    }
                    catch
                    {
                        this.Source = null;
                        this.SourcePort = null;
                    }

                    this._sourceAddressText = value;
                }
            }

            private string _destAddressText = string.Empty;
            public string DestAddressText
            {
                get => this._destAddressText;
                set
                {
                    try
                    {
                        var splitted = value.Split(':');
                        if (splitted.Length == 0)
                            throw new Exception();

                        if (splitted.Length == 1)
                        {
                            this.Dest = IPAddress.Parse(value);
                            this.DestPort = null;
                        }
                        else
                        {
                            this.Dest = IPAddress.Parse(splitted[0]);
                            this.DestPort = int.Parse(splitted[1]);
                        }
                    }
                    catch
                    {
                        this.Dest = null;
                        this.DestPort = null;
                    }

                    this._destAddressText = value;
                }
            }

            public IPAddress Dest
            {
                get => this._data.Dest;
                set => this._data.Dest = value;
            }

            public int? DestPort
            {
                get => this._data.DestPort;
                set => this._data.DestPort = value;
            }

            public Header.Protocol? Protocol
            {
                get => this._data.Protocol;
                set => this._data.Protocol = value;
            }

            private string _hexBytes = string.Empty;
            public string HexBytes
            {
                get => this._hexBytes;
                set
                {
                    try
                    {
                        this._hexBytes = value;
                        if (string.IsNullOrEmpty(value))
                        {
                            this._data.Bytes = null;
                        }
                        else
                        {
                            this._data.Bytes = value.TrimEnd(' ').Split(' ')
                                .Where(x => x.Length == 2)
                                .Select(x => Convert.ToByte(x, 16))
                                .ToArray();
                        }
                    }
                    catch
                    {
                        this._data.Bytes = Encoding.UTF8.GetBytes(this._hexBytes);
                    }

                    this._hexBytes = value;
                }
            }

            public ViewModel(Filter data)
            {
                this._data = data;
            }

            public ViewModel(ViewModel vm) : this(new Filter(vm._data))
            { }

            public bool Pass(Packet.ViewModel vm)
            {
                return this._data.Pass(vm.Data);
            }
        }
    }
}
