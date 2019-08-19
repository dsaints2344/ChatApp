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

        public void RunSocket(IPAddress ip, int port)
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream
                , ProtocolType.Tcp);

            try
            {
                _socket.Bind(new IPEndPoint(ip, port));
                _socket.Listen(6);

                Console.WriteLine("Waiting for connection...");
                _socket.Accept();

                string data = null;
                byte[] bytes = null;

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesReceived = _socket.Receive(bytes);

                    data += Encoding.ASCII.GetString(bytes, 0, bytesReceived);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }
                Console.WriteLine("User connected: {0}", data);

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
