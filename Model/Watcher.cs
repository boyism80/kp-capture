using KPCapture.Model.Protocol;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace KPCapture.Model
{
    public class Watcher : IDisposable
    {
        public interface IListener
        {
            void OnReceive(Packet packet);
            void OnError(string message);
        }

        private static int BUFFER_SIZE = 8192;

        private Socket _socket;
        private byte[] _bytes = new byte[BUFFER_SIZE];
        private IListener _listener;

        
        public string Host { get; private set; }
        


        public bool Running { get; private set; }
        public bool Notificable { get => this.Running; }


        public Watcher(IListener listener = null)
        {
            this._listener = listener;
        }

        public bool Start(string host)
        {
            if (this.Running)
                return false;

            this.Host = host;

            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            this._socket.Bind(new IPEndPoint(IPAddress.Parse(this.Host), 0));
            this._socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            this._socket.IOControl(IOControlCode.ReceiveAll, new byte[4] { 1, 0, 0, 0 }, new byte[4] { 1, 0, 0, 0 });
            this._socket.BeginReceive(this._bytes, 0, this._bytes.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
            this.Running = true;
            return true;
        }

        public bool Stop()
        {
            if (this.Running == false)
                return false;

            this._socket?.Close();
            this._socket = null;

            this.Host = string.Empty;
            this.Running = false;
            return true;
        }

        private void OnReceive(IAsyncResult ar)
        {
            if (this._socket == null)
                return;

            try
            {
                var size = this._socket.EndReceive(ar);
                var packet = Packet.Parse(this._bytes.Take(size).ToArray());
                if (packet == null)
                    throw new Exception("Cannot parse byte array to packet.");

                if (this.Notificable)
                    this._listener?.OnReceive(packet);
            }
            catch (Exception e)
            {
                this._listener?.OnError(e.Message);
            }

            Array.Clear(this._bytes, 0, this._bytes.Length);
            this._socket.BeginReceive(this._bytes, 0, this._bytes.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
        }

        public void Dispose()
        {
            this._socket.Close();
        }
    }
}
