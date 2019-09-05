using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    static class Program
    {
        static void Main(string[] args)
        {
            SocketProxy.SocketProxy s = new SocketProxy.SocketProxy();
            Server chatServer = new Server(s);

            int connectCounter = 0;
            Console.WriteLine("type one of the commands below:");
            Console.WriteLine("Connect");
            Console.WriteLine("Close");
            Console.WriteLine("* The command Connect starts the server");
            Console.WriteLine("* The command Close stops the server and frees the socket");

            chatServer.RunSocket(IPAddress.Parse("127.0.0.1"), 8080);
            connectCounter++;
            Console.WriteLine("Starting server at IPAddress: 127.0.0.1 on port 8080");
            chatServer.ReceiveConnections();
            

            while (true)
            {
                string command = Console.ReadLine();
                if (command == null)
                {
                    break;
                }
                //if (command.Equals("connect", StringComparison.OrdinalIgnoreCase) && connectCounter == 0)
                //{
                //    chatServer.RunSocket(IPAddress.Parse("127.0.0.1"), 8080);
                //    connectCounter++;
                //    Console.WriteLine("Starting server at IPAddress: 127.0.0.1 on port 8080");
                    
                //}

                //if (command.Equals("listen", StringComparison.OrdinalIgnoreCase) && connectCounter == 1)
                //{
                //    chatServer.ReceiveConnections();
                //}
                if (command.Equals("close", StringComparison.OrdinalIgnoreCase))
                {
                    chatServer.CloseSocket();
                    Console.WriteLine("Closing Socket...");
                    break;
                }
            }

        }
    }
}
