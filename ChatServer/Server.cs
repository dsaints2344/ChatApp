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
        private static string data = null;

        public Server(ISocketProxy socket)
        {
            _socket = socket;
        }

        public void RunSocket(IPAddress ip, int port)
        {
            byte[] bytes = new byte[1024];
            try
            {
                _socket.Bind(new IPEndPoint(ip, port));
                _socket.Listen(6);
                

                while (true)
                {
                    Console.WriteLine("Waiting for connection...");
                    var handler = _socket.Accept();
                    
                    data = null;

                    while (true)
                    {
                        int byteRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, byteRec);
                        if (data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Text received : {0}", data);

                }

//                while (true)
//                {
//                    bytes = new byte[1024];
//                    int bytesReceived = _socket.Receive(bytes);
//
//                    data += Encoding.ASCII.GetString(bytes, 0, bytesReceived);
//                    if (data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
//                    {
//                        break;
//                    }
//                }
//                Console.WriteLine("User connected: {0}", data);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void CloseSocket() {

            _socket.Close();

        }
    }
}
