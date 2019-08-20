using SocketProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Client
    {
        private readonly ISocketProxy _socket;
        public Client(ISocketProxy socket)
        {
            _socket = socket;
        }
        public void StartClient(IPAddress ip, int port) {

            byte[] bytes = new byte[1024];

            try
            {
                _socket.Connect(ip, port);
                bool c = _socket.Connected();
                Console.WriteLine(c);
                byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                // Send the data through the socket.    
                _socket.Send(msg);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
