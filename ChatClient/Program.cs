using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketProxy.SocketProxy s = new SocketProxy.SocketProxy();
            Client chatClient = new Client(s);

            string command = Console.ReadLine();
            while (true)
            {
                if (command == "Connect")
                {
                    chatClient.StartClient(IPAddress.Parse("127.0.0.1"), 8080);

                }
            }
            
        }
    }
}
