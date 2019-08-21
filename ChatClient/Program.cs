using SocketProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatClient
{
    static class Program
    {
        private const string Pattern = @"^\w([._](?![._])|\w){6,10}\w$";

        static bool CheckUser(string User)
        {
            Match match = Regex.Match(User, Pattern);

            if (match.Success) return true;

            return false;
        }
        static void Main(string[] args)
        {
            SocketProxy.SocketProxy s = new SocketProxy.SocketProxy();
            Client chatClient = new Client(s);
            int connectCounter = 0;
            
            
            while (true)
            {
                Console.WriteLine("Welcome to the ChatApp");
                Console.WriteLine("In order to continue you should include the following requirements:\n " +
                                   "1. Must contain between 6 and 10 characters\n" +
                                   "2. Must not contain special characters\n" +
                                   "3. Must be alphanumeric");
                string command = Console.ReadLine();
                var cmd = command.Split('?')[0];
                var user = command.Split('?')[1];

                if (cmd.Equals(Commands.login, StringComparison.OrdinalIgnoreCase))
                {
                    chatClient.StartClient(IPAddress.Parse("127.0.0.1"), 8080);
                    bool netStatus = s.Connected();

                    bool isValid = CheckUser(user);

                    if (isValid)
                    {
                        // If could connect with server will print 1, else 0
                        if (netStatus)
                        {
                            Console.WriteLine($"Connection established: {Convert.ToInt32(netStatus)}");
                            connectCounter++;
                        }else
                            Console.WriteLine($"Couldn't establish connection: {Convert.ToInt32(netStatus)}");
                    }
                    else
                    {
                        Console.WriteLine("Username doesn't meet the minimum requirements");
                        return;
                    }
                }
            }            
        }
    }
}
