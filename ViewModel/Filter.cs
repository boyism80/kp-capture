using KPCapture.ViewModel;
using Microsoft.Scripting.Utils;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace KPCapture.Model.Protocol
{
    public partial class Filter
    {
        public class ViewModel : BaseViewModel
        {
            private const string REGEX_IP_PATTERN = @"^(?<host>\d{1,3}(\.\d{1,3}){3})(|:(?<port>\d+))$";

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
                        var match = Regex.Match(value, REGEX_IP_PATTERN);
                        if (match.Success == false)
                            throw new Exception("Invalid IP address format.");

                        this.Source = IPAddress.Parse(match.Groups["host"].Value);
                        if (string.IsNullOrEmpty(match.Groups["port"].Value))
                            this.SourcePort = null;
                        else
                            this.SourcePort = int.Parse(match.Groups["port"].Value);
                        this.SourceException = string.Empty;
                    }
                    catch(Exception e)
                    {
                        this.Source = null;
                        this.SourcePort = null;
                        this.SourceException = e.Message;
                    }

                    this._sourceAddressText = value;
                }
            }
            public string SourceException { get; private set; }

            private string _destAddressText = string.Empty;
            public string DestAddressText
            {
                get => this._destAddressText;
                set
                {
                    try
                    {
                        var match = Regex.Match(value, REGEX_IP_PATTERN);
                        if (match.Success == false)
                            throw new Exception("Invalid IP address format.");

                        this.Dest = IPAddress.Parse(match.Groups["host"].Value);
                        if (string.IsNullOrEmpty(match.Groups["port"].Value))
                            this.DestPort = null;
                        else
                            this.DestPort = int.Parse(match.Groups["port"].Value);
                        this.DestException = string.Empty;
                    }
                    catch (Exception e)
                    {
                        this.Dest = null;
                        this.DestPort = null;
                        this.DestException = e.Message;
                    }

                    this._destAddressText = value;
                }
            }
            public string DestException { get; private set; }

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
                set => this._data.Protocol = (value == Header.Protocol.NONE ? null : value);
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

                            if (this._data.Bytes.Length == 0)
                                throw new Exception();
                        }
                    }
                    catch
                    {
                        this._data.Bytes = Encoding.UTF8.GetBytes(this._hexBytes);
                    }

                    if (this._data.Bytes != null)
                        this.PreviewHexText = BitConverter.ToString(this._data.Bytes).Replace('-', ' ');
                    else
                        this.PreviewHexText = string.Empty;
                    this._hexBytes = value;
                }
            }
            public string PreviewHexText { get; private set; }

            private string _script = string.Empty;
            public string Script
            {
                get => this._script;
                set
                {
                    try
                    {
                        if (File.Exists(value) == false)
                            throw new Exception($"Not found script file : {value}");

                        this._data.Script = value;
                    }
                    catch
                    {
                        this._data.Script = string.Empty;
                    }
                    
                    this._script = value;
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

            public byte[] Decrypt(Packet.ViewModel vm)
            {
                return this._data.Decrypt(vm.Data);
            }
        }
    }
}
