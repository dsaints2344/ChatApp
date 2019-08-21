using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProxy
{
    /// <summary>
    /// This class will be used as a wrapper class.
    /// It will be used during run time for the socket operations
    /// <see cref="Socket"/> 
    /// </summary>
    public class SocketProxy: ISocketProxy
    {
        private readonly Socket _tcpSocket;

        public SocketProxy()
        {
            _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, 
                ProtocolType.Tcp);
        }

        private SocketProxy(Socket tcpSocket)
        {
            _tcpSocket = tcpSocket;
        }

        #region SocketMethods

        public void Connect(IPAddress ip, int port)
        {
            _tcpSocket.Connect(ip, port);
        }

        public bool Connected()
        {
            return _tcpSocket.Connected;
        }

        public void Close()
        {
            _tcpSocket.Close();
            _tcpSocket.Dispose();
        }


        public void Send(byte[] buffer)
        {
            _tcpSocket.Send(buffer);
        }

        public void Bind(EndPoint localEndPoint)
        {
            _tcpSocket.Bind(localEndPoint);
        }

        public void Listen(int backlog)
        {
            _tcpSocket.Listen(backlog);
        }

        public int Receive(byte[] buffer)
        {
            return _tcpSocket.Receive(buffer);
        }

        public ISocketProxy Accept()
        {
            return new SocketProxy(_tcpSocket.Accept());
        }

        #endregion
    }
}
