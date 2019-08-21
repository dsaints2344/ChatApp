using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace SocketProxy
{
    /// <summary>
    /// This class will be used as a wrapper class.
    /// It will be used during run time for the socket operations
    /// <see cref="Socket"/> 
    /// </summary>
    public class SocketProxy : ISocketProxy
    {
        private readonly Socket _tcpSocket;
        private readonly string UserPattern = @"^\w([.](?![.])|\w){6,10}\w";
        private List<string> _userList = new List<string>();

        public SocketProxy()
        {
            _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private SocketProxy(Socket tcpSocket)
        {
            _tcpSocket = tcpSocket;
        }

        #region SocketMethods

        public void Connect(IPAddress ip, int port)
        {
            _tcpSocket.Connect(ip, port);
        }

        public bool Connected()
        {
            return _tcpSocket.Connected;
        }

        public void Close()
        {
            _tcpSocket.Close();
            _tcpSocket.Dispose();
        }

        public void Send(byte[] buffer)
        {
            _tcpSocket.Send(buffer);
        }

        public void Bind(EndPoint localEndPoint)
        {
            _tcpSocket.Bind(localEndPoint);
        }

        public void Listen(int backlog)
        {
            _tcpSocket.Listen(backlog);
        }

        public int Receive(byte[] buffer)
        {
            return _tcpSocket.Receive(buffer);
        }

        public ISocketProxy Accept()
        {
            return new SocketProxy(_tcpSocket.Accept());
        }

        public int Login(string command = "")
        {
            if (!string.IsNullOrEmpty(command) && !string.IsNullOrWhiteSpace(command))
            {
                var commandAndParameter = this.GetFromCommand(command);

                if (commandAndParameter[0] != Commands.login || commandAndParameter.Length < 2) return (int)eResponses.NoConnected;

                var user = commandAndParameter[1];
                if (!ValidatorUser(user)) return (int)eResponses.NoConnected;

                _userList.Add(user);

                return (int)eResponses.Connected;
            }

            return (int)eResponses.NoConnected;
        }
        #endregion

        #region AuxiliarMethods
        private string[] GetFromCommand(string command, bool hasParameters = false)
        {
            string[] result = new string[2];

            if (!string.IsNullOrWhiteSpace(command) && !string.IsNullOrEmpty(command))
            {
                var commandAndParameters = command.Split(Symbols.CommandSeparator);

                if (commandAndParameters.Length < 2 && hasParameters) return default(string[]);
                else if (commandAndParameters.Length == 1)
                {
                    result = commandAndParameters;
                }
                else
                {
                    var parameters = GetFromParameters(result[1]);
                    int count = parameters.Length + 1;

                    result = new string[count];

                    for (int i = 0; i < count; i++)
                    {
                        result[i] = (i == 0) ? commandAndParameters[i] : parameters[i];
                    }
                }
            }

            return result;
        }

        private string[] GetFromParameters(string parameters)
        {
            var result = new string[0];
            if (!string.IsNullOrWhiteSpace(parameters) && !string.IsNullOrEmpty(parameters))
            {
                var tempParameters = parameters.Split(Symbols.ParameterSeparator);

                if (tempParameters.Length == 0) return default(string[]);
                result = tempParameters;
            }

            return result;
        }

        private bool ValidatorUser(string user = "")
        {
            return new Regex(UserPattern).IsMatch(user);
        }
        #endregion
    }
}
