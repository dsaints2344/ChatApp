using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketProxy.SocketProxy s = new SocketProxy.SocketProxy();
            Server ChatServer = new Server(s);
            ChatServer.Run(IPAddress.Parse("127.0.0.1"), 8080);
        }
    }
}
