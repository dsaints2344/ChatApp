using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SocketProxy;

namespace ChatServer
{
    public class Server
    {
        private readonly ISocketProxy _socket;

        public Server(ISocketProxy socket)
        {
            _socket = socket;
        }

        public void Run()
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream
                , ProtocolType.Tcp);
            
        }
    }
}
