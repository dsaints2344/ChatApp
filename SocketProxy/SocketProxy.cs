using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProxy
{
    public class SocketProxy: ISocketProxy
    {
        private readonly Socket _tcpSocket;

        public SocketProxy()
        {
            _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, 
                ProtocolType.Tcp);
        }

        public SocketProxy(Socket tcpSocket)
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
        }


        public void SendTo(byte[] buffer, EndPoint endPoint)
        {
            _tcpSocket.SendTo(buffer, endPoint);
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
