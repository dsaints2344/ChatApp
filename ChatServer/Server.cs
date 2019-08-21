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
            try
            {
                _socket.Bind(new IPEndPoint(ip, port));
                _socket.Listen(6);


            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void ReceiveConnections()
        {
            byte[] bytes = new byte[1024];
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

                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);

            }
        }

        public void CloseSocket() {

            _socket.Close();

        }
    }
}
