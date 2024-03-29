﻿using SocketProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatClient
{
    static class Program
    {
        private const string Pattern = @"^\w([._](?![._])|\w){6,10}\w$";
        static bool CheckUser(string User){
            Match match = Regex.Match(User, Pattern);

            if (match.Success) return true;

            return false;
        }
        static void Main(string[] args)
        {
            SocketProxy.SocketProxy s = new SocketProxy.SocketProxy();
            Client chatClient = new Client(s);
            int connectCounter = 0;

            Console.Clear();
            Thread.Sleep(2000);
            chatClient.StartClient(IPAddress.Parse("127.0.0.1"), 8080);
            bool netStatus = s.Connected();


            //Verify server connection
            if (netStatus){
                // If could connect with server will print 1
                Console.WriteLine($"Connection established: {Convert.ToInt32(netStatus)}");
                connectCounter++;

                Thread.Sleep(3000);
                Console.Clear();
            } else
                //If couldn't connect with server will print 0
                Console.WriteLine($"Couldn't establish connection: {Convert.ToInt32(netStatus)}");

            while (true){
                Console.Clear();
                Console.WriteLine("In order to continue you should include the following requirements:\n " +
                                       "1. Must contain between 6 and 10 characters\n" +
                                       "2. Must not contain special characters\n" +
                                       "3. Must be alphanumeric");
                Console.Write("> ");
                string command = Console.ReadLine();
                var cmd = command.Split(Symbols.ParamSeparator)[0];
                var user = command.Split(Symbols.ParamSeparator)[1];

                if (cmd.Equals(Commands.login, StringComparison.OrdinalIgnoreCase)){
                    bool isValid = CheckUser(user);

                    if (isValid){
                        //ChatApp(chatClient);
                        while (true)
                        {
                            byte[] receivedBytes = new byte[1024];
                            Console.WriteLine("Welcome to the ChatApp\n\n\n");
                            command = Console.ReadLine();



                            if (command.Equals(Commands.user_list, StringComparison.OrdinalIgnoreCase))
                            {
                                receivedBytes = Encoding.Default.GetBytes(command);
                                int totalReceivedBytes = s.Receive(receivedBytes);
                                Console.WriteLine($"User lists\n {Encoding.ASCII.GetString(receivedBytes, 0, totalReceivedBytes)}");
                            }

                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }

                    } else {
                        Console.WriteLine("Username doesn't meet the minimum requirements");
                        Console.ReadKey();
                        continue;
                    }
                }
            }            
        }

    }
}
