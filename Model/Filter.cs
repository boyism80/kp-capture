using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace KPCapture.Model
{
    public class Filter
    {
        private static ScriptEngine SCRIPT_ENGINE = Python.CreateEngine();

        private ScriptScope _scriptScope;
        private string _script;

        public IPAddress Source { get; set; }
        public int? SourcePort { get; set; }
        public IPAddress Dest { get; set; }
        public int? DestPort { get; set; }
        public byte[] Bytes { get; set; }
        public ProtocolType? ProtocolType { get; set; }
        public string Script
        {
            get => _script;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _scriptScope = null;
                }
                else if (_script != value)
                {
                    if (File.Exists(value) == false)
                        return;

                    _scriptScope = SCRIPT_ENGINE.ExecuteFile(value);
                    _scriptScope.GetVariable("decrypt");
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
            Source = filter.Source;
            SourcePort = filter.SourcePort;
            Dest = filter.Dest;
            DestPort = filter.DestPort;
            Bytes = filter.Bytes;
            ProtocolType = filter.ProtocolType;
        }

        public bool Pass(Packet p)
        {
            if (Source != null && Source.Equals(p.SourceAddress) == false)
                return false;

            if (SourcePort != null && SourcePort.Value != p.SourcePort)
                return false;

            if (Dest != null && Dest.Equals(p.DestinationAddress) == false)
                return false;

            if (DestPort != null && DestPort.Value != p.DestinationPort)
                return false;

            if (ProtocolType != null && ProtocolType.Value != p.ProtocolType)
                return false;

            if (Bytes != null && Bytes.Length > 0 && p.Bytes.Contains(Bytes) == false)
                return false;

            return true;
        }

        public byte[] Decrypt(Packet p)
        {
            try
            {
                if (_scriptScope == null)
                    throw new FileNotFoundException();

                var decryptFunc = _scriptScope.GetVariable<Func<byte[], byte[]>>("decrypt");
                if (decryptFunc == null)
                    throw new Exception();

                return decryptFunc(p.Bytes);
            }
            catch
            {
                return p.Bytes;
            }
        }

        public byte[] ToBytes()
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(Source != null);
                    if(Source != null)
                        writer.Write(Source.ToString());

                    writer.Write(SourcePort.HasValue);
                    if (SourcePort.HasValue)
                        writer.Write(SourcePort.Value);

                    writer.Write(Dest != null);
                    if (Dest != null)
                        writer.Write(Dest.ToString());
                    
                    writer.Write(DestPort.HasValue);
                    if (DestPort.HasValue)
                        writer.Write(DestPort.Value);

                    writer.Write(Bytes != null);
                    if (Bytes != null)
                    {
                        writer.Write(Bytes.Length);
                        writer.Write(Bytes);
                    }
                    
                    writer.Write(ProtocolType.HasValue);
                    if (ProtocolType.HasValue)
                        writer.Write((int)ProtocolType.Value);

                    writer.Write(Script != null);
                    if (Script != null)
                        writer.Write(Script);
                }

                return stream.ToArray();
            }
        }

        public static Filter FromBytes(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var reader = new BinaryReader(stream))
                {
                    var filter = new Filter();
                    if(reader.ReadBoolean())
                        filter.Source = IPAddress.Parse(reader.ReadString());

                    if (reader.ReadBoolean())
                        filter.SourcePort = reader.ReadInt32();

                    if(reader.ReadBoolean())
                        filter.Dest = IPAddress.Parse(reader.ReadString());

                    if (reader.ReadBoolean())
                        filter.DestPort = reader.ReadInt32();

                    if (reader.ReadBoolean())
                    {
                        var bytesSize = reader.ReadInt32();
                        filter.Bytes = reader.ReadBytes(bytesSize);
                    }

                    if (reader.ReadBoolean())
                        filter.ProtocolType = (ProtocolType)reader.ReadInt32();

                    if (reader.ReadBoolean())
                        filter.Script = reader.ReadString();

                    return filter;
                }
            }
        }

        public Filter Clone()
        {
            return FromBytes(ToBytes());
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
