using KPCapture.Model;
using Microsoft.Scripting.Utils;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace KPCapture.ViewModel
{
    public class Filter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private const string REGEX_IP_PATTERN = @"^(?<host>\d{1,3}(\.\d{1,3}){3})(|:(?<port>\d+))$";

        public Model.Filter Model { get; private set; }

        public IPAddress Source
        {
            get => Model.Source;
            set => Model.Source = value;
        }
        public int? SourcePort
        {
            get => Model.SourcePort;
            set => Model.SourcePort = value;
        }

        private string _sourceAddressText = string.Empty;
        public string SourceAddressText
        {
            get => _sourceAddressText;
            set
            {
                try
                {
                    var match = Regex.Match(value, REGEX_IP_PATTERN);
                    if (match.Success == false)
                        throw new Exception("Invalid IP address format.");

                    Source = IPAddress.Parse(match.Groups["host"].Value);
                    if (string.IsNullOrEmpty(match.Groups["port"].Value))
                        SourcePort = null;
                    else
                        SourcePort = int.Parse(match.Groups["port"].Value);
                    SourceException = string.Empty;
                }
                catch (Exception e)
                {
                    Source = null;
                    SourcePort = null;
                    SourceException = e.Message;
                }

                _sourceAddressText = value;
            }
        }
        public string SourceException { get; private set; }

        private string _destAddressText = string.Empty;
        public string DestAddressText
        {
            get => _destAddressText;
            set
            {
                try
                {
                    var match = Regex.Match(value, REGEX_IP_PATTERN);
                    if (match.Success == false)
                        throw new Exception("Invalid IP address format.");

                    Dest = IPAddress.Parse(match.Groups["host"].Value);
                    if (string.IsNullOrEmpty(match.Groups["port"].Value))
                        DestPort = null;
                    else
                        DestPort = int.Parse(match.Groups["port"].Value);
                    DestException = string.Empty;
                }
                catch (Exception e)
                {
                    Dest = null;
                    DestPort = null;
                    DestException = e.Message;
                }

                _destAddressText = value;
            }
        }
        public string DestException { get; private set; }

        public IPAddress Dest
        {
            get => Model.Dest;
            set => Model.Dest = value;
        }

        public int? DestPort
        {
            get => Model.DestPort;
            set => Model.DestPort = value;
        }

        public ProtocolType? ProtocolType
        {
            get => Model.ProtocolType;
            set => Model.ProtocolType = (value == KPCapture.Model.ProtocolType.NONE ? null : value);
        }

        private string _hexBytes = string.Empty;
        public string HexBytes
        {
            get => _hexBytes;
            set
            {
                try
                {
                    _hexBytes = value;
                    if (string.IsNullOrEmpty(value))
                    {
                        Model.Bytes = null;
                    }
                    else
                    {
                        Model.Bytes = value.TrimEnd(' ').Split(' ')
                            .Where(x => x.Length == 2)
                            .Select(x => Convert.ToByte(x, 16))
                            .ToArray();

                        if (Model.Bytes.Length == 0)
                            throw new Exception();
                    }
                }
                catch
                {
                    Model.Bytes = Encoding.UTF8.GetBytes(_hexBytes);
                }

                if (Model.Bytes != null)
                    PreviewHexText = BitConverter.ToString(Model.Bytes).Replace('-', ' ');
                else
                    PreviewHexText = string.Empty;
                _hexBytes = value;
            }
        }
        public string PreviewHexText { get; private set; }

        private string _script = string.Empty;

        public string Script
        {
            get => _script;
            set
            {
                try
                {
                    if (File.Exists(value) == false)
                        throw new Exception($"Not found script file : {value}");

                    Model.Script = value;
                }
                catch
                {
                    Model.Script = string.Empty;
                }

                _script = value;
            }
        }

        public Filter(Model.Filter model)
        {
            Model = model;
        }

        public bool Pass(ViewModel.Packet vm)
        {
            return Model.Pass(vm.Model);
        }

        public byte[] Decrypt(ViewModel.Packet vm)
        {
            return Model.Decrypt(vm.Model);
        }
    }
}
