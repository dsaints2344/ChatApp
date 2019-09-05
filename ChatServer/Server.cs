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
    /// <summary>
    /// Client State Class contains client name and state (connected)
    /// </summary>
    public class ClientState
    {
        public string Name { get; set; }
        public string State { get; private set; } = "connected";
    }
    public class Server
    {
        private readonly ISocketProxy _socket;
        public List<ISocketProxy> _clientSockets = new List<ISocketProxy>();
        private static string data = null;
        private static Dictionary<IPAddress, ClientState> _clients = new Dictionary<IPAddress,ClientState>();


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
            string clientName = string.Empty;
            byte[] bytes = new byte[1024];
            while (true)
            {
                Console.WriteLine("Waiting for connection...");
                var handler = _socket.Accept();
                _clientSockets.Add(handler);

                IPAddress clientAddress = handler.RemoteEndPoint();

                data = null;


                while (true)
                {
                    int byteRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, byteRec);

                    clientName = data.Replace("connect: ", "");
                    ClientState clientState = new ClientState() { Name = clientName };
                    _clients.Add(clientAddress, clientState);

                    if (data.Length > 0)
                    {
                        break;
                    }
                }

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
