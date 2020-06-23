using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace KPCapture.Model.Protocol
{
    public partial class Filter
    {
        private static ScriptEngine SCRIPT_ENGINE = Python.CreateEngine();

        private ScriptScope _scriptScope;
        private string _script;

        public IPAddress Source { get; set; }
        public int? SourcePort { get; set; }
        public IPAddress Dest { get; set; }
        public int? DestPort { get; set; }
        public byte[] Bytes { get; set; }
        public Header.Protocol? Protocol { get; set; }
        public string Script
        {
            get => this._script;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this._scriptScope = null;
                }
                else if (this._script != value)
                {
                    if (File.Exists(value) == false)
                        return;

                    this._scriptScope = SCRIPT_ENGINE.ExecuteFile(value);
                    this._scriptScope.GetVariable("decrypt");
                }
                else
                {
                    return;
                }
            }
        }

        public Filter()
        {
            
        }

        public Filter(Filter filter) : this()
        {
            this.Source = filter.Source;
            this.SourcePort = filter.SourcePort;
            this.Dest = filter.Dest;
            this.DestPort = filter.DestPort;
            this.Bytes = filter.Bytes;
            this.Protocol = filter.Protocol;
        }

        public bool Pass(Packet packet)
        {
            if (this.Source != null && this.Source.Equals(packet.SourceAddress) == false)
                return false;

            if (this.SourcePort != null && this.SourcePort.Value != packet.SourcePort)
                return false;

            if (this.Dest != null && this.Dest.Equals(packet.DestinationAddress) == false)
                return false;

            if (this.DestPort != null && this.DestPort.Value != packet.DestinationPort)
                return false;

            if (this.Protocol != null && this.Protocol.Value != packet.Protocol)
                return false;

            if (this.Bytes != null && this.Bytes.Length > 0 && packet.Bytes.Contains(this.Bytes) == false)
                return false;

            return true;
        }

        public byte[] Decrypt(Packet packet)
        {
            try
            {
                if (this._scriptScope == null)
                    throw new FileNotFoundException();

                var decryptFunc = this._scriptScope.GetVariable<Func<byte[], byte[]>>("decrypt");
                if (decryptFunc == null)
                    throw new Exception();

                return decryptFunc(packet.Bytes);
            }
            catch
            {
                return null;
            }
        }
    }

    public static class FilterExtension
    {
        public static bool Contains(this byte[] source, byte[] pattern)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source.Skip(i).Take(pattern.Length).SequenceEqual(pattern))
                    return true;
            }

            return false;
        }
    }
}
