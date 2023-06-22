using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace KPCapture.Model
{
    public class Watcher : IDisposable
    {
        public delegate void ReceiveHandler(Packet packet);
        public delegate void ErrorHandler(Exception e);

        private static int BUFFER_SIZE = 8192;

        private Socket _socket;
        private byte[] _bytes = new byte[BUFFER_SIZE];
        
        public string Host { get; private set; }
        public bool Running { get; private set; }

        public event ReceiveHandler Received;
        public event ErrorHandler Error;


        public Watcher()
        {
        }

        public bool Start(string host)
        {
            if (Running)
                return false;

            Host = host;

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, System.Net.Sockets.ProtocolType.IP);
            _socket.Bind(new IPEndPoint(IPAddress.Parse(Host), 0));
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            _socket.IOControl(IOControlCode.ReceiveAll, new byte[4] { 1, 0, 0, 0 }, new byte[4] { 1, 0, 0, 0 });
            _socket.BeginReceive(_bytes, 0, _bytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            Running = true;
            return true;
        }

        public bool Stop()
        {
            if (Running == false)
                return false;

            _socket?.Close();
            _socket = null;

            Host = string.Empty;
            Running = false;
            return true;
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                var size = _socket.EndReceive(ar);
                var p = Packet.Parse(_bytes.Take(size).ToArray()) ??
                    throw new Exception("Cannot parse byte array to packet.");

                if (Running)
                    Received?.Invoke(p);
            }
            catch (Exception e)
            {
                Error?.Invoke(e);
            }

            Array.Clear(_bytes, 0, _bytes.Length);
            _socket?.BeginReceive(_bytes, 0, _bytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }

        public void Dispose()
        {
            _socket.Close();
        }
    }
}
