using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace SocketProxy
{
    /// <summary>
    /// This class will implement the mock that is going to be used for testing,
    /// the library f choice for that is Moq
    /// <see cref="Mock"/>
    /// </summary>
    public class MockSocketProxy: ISocketProxy
    {
        
        private readonly Mock<ISocketProxy> _mock;

        public MockSocketProxy()
        {
            _mock = new Mock<ISocketProxy>();
        }

        #region SocketMethods

        public void Connect(IPAddress ip, int port)
        {
            _mock.Object.Connect(ip, port);
        }

        public bool Connected()
        {
            return _mock.Object.Connected();
        }

        public void Close()
        {
            _mock.Object.Close();
        }

        public void SendTo(byte[] buffer, EndPoint endPoint)
        {
            _mock.Object.SendTo(buffer, endPoint);
        }

        public void Bind(EndPoint localEndPoint)
        {
            _mock.Object.Bind(localEndPoint);
        }

        public void Listen(int backlog)
        {
            _mock.Object.Listen(backlog);
        }

        public int Receive(byte[] buffer)
        {
            return _mock.Object.Receive(buffer);
        }

        public ISocketProxy Accept()
        {
            return _mock.Object.Accept();
        }

        #endregion

        #region TestMethods
        /// <summary>
        /// This method test the connection of a socket into an specific
        /// IPAddress and port
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void VerifyConnect(IPAddress ip, int port)
        {
            _mock.Verify(x => x.Connect(ip, port));
        }

        /// <summary>
        /// This method tests the connection status of the socket
        /// </summary>
        public void VerifyConnected()
        {
            _mock.Verify(x => x.Connected());
        }

        /// <summary>
        /// This methods verifies the binding of the socket connection
        /// </summary>
        /// <param name="localEndPoint"></param>
        public void VerifyBind(EndPoint localEndPoint)
        {
            _mock.Verify(x => x.Bind(localEndPoint));
        }

        /// <summary>
        /// This methods verifies the socket listening to a specific amount of connections
        /// </summary>
        /// <param name="backlog"></param>
        public void VerifyListen(int backlog)
        {
            _mock.Verify(x => x.Listen(backlog));
        }

        /// <summary>
        /// This method tests the sending of data to the socket to an EndPoint
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="endPoint"></param>
        public void VerifySend(byte[] buffer, EndPoint endPoint)
        {
            _mock.Verify(x => x.SendTo(buffer, endPoint));
        }

        /// <summary>
        /// This method tests the receiving of data from a remote Endpoint
        /// </summary>
        /// <param name="buffer"></param>
        public void VerifyReceive(byte[] buffer)
        {
            _mock.Verify(x => x.Receive(buffer));
        }

        /// <summary>
        /// This method tests the closure of the socket
        /// </summary>
        public void VerifyClose()
        {
            _mock.Verify(x => x.Close(), Times.Once);
        }

        /// <summary>
        /// This method tests the acceptance of connection through the socket
        /// </summary>
        public void VerifyAccept()
        {
            _mock.Verify(x => x.Close(), Times.Once);
        }

        #endregion

    }
}
