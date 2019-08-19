using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProxy
{
    public interface ISocketProxy
    {

        void Connect(IPAddress ip, int port);
        bool Connected();
        void Close();
        void Shutdown(SocketShutdown how);
        void Send(byte[] buffer);
        void Bind(EndPoint localEndPoint);
        void Listen(int backlog);
        int Receive(byte[] buffer);
        ISocketProxy Accept();

    }
}
