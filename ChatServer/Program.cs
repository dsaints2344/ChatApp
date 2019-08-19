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

            string command = Console.ReadLine();

            switch (command)
            {
                case "connect":
                    ChatServer.Run(IPAddress.Parse("127.0.0.1"), 8080);
                    Console.WriteLine("Server Running...");
                    break;
                default:
                    break;
            }
        }
    }
}
