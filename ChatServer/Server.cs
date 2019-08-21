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
        private List<string> _userList = new List<string>();

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
                    if (data.Length > 0)
                    {
                        break;
                    }
                }
                _userList.Add(data);

                foreach (var user in bytes)
                {
                    byte[] msg = Encoding.ASCII.GetBytes(user.ToString());
                    handler.Send(msg);
                }
                

                

            }
        }

        public void CloseSocket() {

            _socket.Close();

        }
    }
}
