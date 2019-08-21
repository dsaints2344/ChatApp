using SocketProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    static class Program
    {
        static void Main(string[] args)
        {
            SocketProxy.SocketProxy s = new SocketProxy.SocketProxy();
            Client chatClient = new Client(s);
            int connectCounter = 0;
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("connect", StringComparison.OrdinalIgnoreCase) && connectCounter == 0)
                {
                    chatClient.StartClient(IPAddress.Parse("127.0.0.1"), 8080);
                    connectCounter++;
                }
                else if (command.Equals("exit", StringComparison.OrdinalIgnoreCase) && connectCounter > 0)
                    chatClient.ExitClient();  // Other commands
            }            
        }
    }
}
