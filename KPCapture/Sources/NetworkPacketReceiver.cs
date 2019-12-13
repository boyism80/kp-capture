using KPU.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Packet_Capturer.Sources
{
    public interface IReceiveEvent
    {
        void OnReceive(NetworkPacket network_packet);
        void OnError(string message);
    }

    public class NetworkPacketReceiver
    {
        // This variable is the size of the buffer used to get packet data.
        private static int          BUFFER_SIZE = 8192;

        // This variable is a socket for getting raw packets.
        // This is generated only once in the constructor.
        private Socket              _socket;

        // This variable is the buffer used to get data from the socket.
        private byte[]              _bytes = new byte[BUFFER_SIZE];

        // This value is the interface that will get the raw packet data and parse it and pass the result.
        private IReceiveEvent       _listener;

        // This value indicates whether the instance is in the process of being captured.
        private bool                _running = true;
        public bool Running { get { return this._running; } set { this._running = value; } }

        // This value indicates whether the listener is ready to pass packet data to the registered object.
        public bool Notificatable { get { return this._listener != null && this.Running == true; } }

        public NetworkPacketReceiver(string host, IReceiveEvent listener)
        {
            this._listener = listener;

            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            this._socket.Bind(new IPEndPoint(IPAddress.Parse(host), 0));
            this._socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            var inarr = new byte[4] { 1, 0, 0, 0 };
            var outarr = new byte[4] { 1, 0, 0, 0 };
            this._socket.IOControl(IOControlCode.ReceiveAll, inarr, outarr);
            this._socket.BeginReceive(this._bytes, 0, this._bytes.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
        }

        ~NetworkPacketReceiver()
        {
            this.close();
        }

        private NetworkPacket parse(byte[] bytes, int size)
        {
            var network_packet = new NetworkPacket(bytes, size);
            if (network_packet.IPHeader.Version == "Unknown")
                throw new Exception("Unknwon ip header version");

            return network_packet;
        }

        private void OnReceive(IAsyncResult asyncResult)
        {
            try
            {
                var network_packet = this.parse(this._bytes, this._socket.EndReceive(asyncResult));
                if(this.Notificatable)
                    this._listener.OnReceive(network_packet);
            }
            catch (ObjectDisposedException e)
            {
                return;
            }
            catch (Exception e)
            {
                if (this.Notificatable)
                    this._listener.OnError(e.Message);
            }

            try
            {
                this._bytes = new byte[BUFFER_SIZE];
                this._socket.BeginReceive(this._bytes, 0, this._bytes.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
            }
            catch (Exception e)
            { }
        }

        public void close()
        {
            if (this._socket != null)
                this._socket.Close();

            this.Running = false;
        }
    }
}
