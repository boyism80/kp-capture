using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace KPU.Sources
{
    public class Channel
    {
        public enum TransmissionType
        {
            Send,
            Receive,
            Unknown,
        }

        // This variable is a list of packet data captured by the channel.
        private List<Packet>     _network_packets = new List<Packet>();
        public Packet[] NetworkPackets
        {
            get
            {
                return this._network_packets.ToArray();
            }
        }

        // This variable is a packet data list filtered by the filter of the packets captured by the channel.
        public Packet[] FilteredNetworkPacket
        {
            get
            {
                lock(this._network_packets)
                {
                    if (this.Filters.Length != 0)
                    {
                        var filtered = this._network_packets.Where(p => this.acceptable(p));
                        return filtered.ToArray();
                    }
                    else
                    {
                        return this.NetworkPackets;
                    }
                }
            }
        }

        // This variable is the channel-specific filter information you have registered.
        private List<Filter>            _filters = new List<Filter>();
        public Filter[] Filters
        {
            get
            {
                return this._filters.ToArray();
            }
        }

        // This variable is a variable used for decrypting using Python script.
        private ScriptScope             _scope;
        private ScriptScope Scope {get { return this._scope; } set { this._scope = value; } }


        // This variable indicates the status of whether the channel is capturing packets.
        private bool _running;
        public bool Running { get { return this._running; } set { this._running = value; } }

        // This variable is the information of the process corresponding to the channel.
        public Process Process { get; private set; }


        // This variable is the unique ID of the channel. 
        // It also means the pid of the actual corresponding process.
        public int Id
        {
            get
            {
                if(this.Process != null)
                    return this.Process.Id;

                return -1;
            }
        }


        // This variable is the actual path of the Python script to decode the channel.
        private string _python_script_path;
        public string PythonScriptPath
        {
            get
            {
                return this._python_script_path;
            }
            set
            {
                if (value != null)
                {
                    var engine          = Python.CreateEngine();
                    this._scope         = engine.CreateScope();
                    engine.ExecuteFile(value, this._scope);
                    this._scope.GetVariable("decrypt");
                }
                else
                {
                    this._scope         = null;
                }

                this._python_script_path        = value;
            }
        }


        public Channel(Process p)
        {
            this.Process                = p;
        }

        public bool add_packet(Packet packet)
        {
            if (this.Running == false)
                return false;

            lock(this._network_packets)
            {
                this._network_packets.Add(packet);
            }
            return true;
        }

        public bool add_filter(Filter filter)
        {
            if (this._filters.Exists(f => f.Equals(filter)))
                return false;

            this._filters.Add(filter);
            return true;
        }

        public void set_filter(Filter[] filters)
        {
            this._filters = filters.ToList();
        }

        public void remove_filter(Filter filter)
        {
            this._filters.Remove(filter);
        }

        public bool acceptable(Packet network_packet)
        {
            if (this.Filters.Length == 0)
            {
                return true;
            }
            else
            {
                foreach (var filter in this.Filters)
                {
                    if (filter.condition(network_packet))
                        return true;
                }
                return false;
            }
        }

        public Image image()
        {
            try
            {
                var icon                = Icon.ExtractAssociatedIcon(this.Process.MainModule.FileName);
                return icon.ToBitmap();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Image image(Size size)
        {
            try
            {
                var icon                = Icon.ExtractAssociatedIcon(this.Process.MainModule.FileName);
                return new Bitmap(icon.ToBitmap(), size);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public byte[] decrypted_bytes(Packet network_packet)
        {
            if (this._scope == null)
            {
                return network_packet.BaseHeader.Bytes;
            }
            else
            {
                var decrypt             = this._scope.GetVariable<Func<byte[], ByteArray>>("decrypt");
                if (decrypt == null)
                    throw new KeyNotFoundException("Cannot find decrypt function");

                if (network_packet.BaseHeader.Bytes.Length == 0)
                    return network_packet.BaseHeader.Bytes;

                return decrypt(network_packet.BaseHeader.Bytes).ToArray();
            }
        }
    }
}