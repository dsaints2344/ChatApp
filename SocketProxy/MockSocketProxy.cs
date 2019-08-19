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

        public void VerifyConnect(IPAddress ip, int port)
        {
            _mock.Verify(x => x.Connect(ip, port));
        }

        public void VerifyConnected()
        {
            _mock.Verify(x => x.Connected());
        }

        public void VerifyBind(EndPoint locaEndPoint)
        {
            _mock.Verify(x => x.Bind(locaEndPoint));
        }

        public void VerifyListen(int backlog)
        {
            _mock.Verify(x => x.Listen(backlog));
        }

        public void VerifySend(byte[] buffer, EndPoint endPoint)
        {
            _mock.Verify(x => x.SendTo(buffer, endPoint));
        }

        public void VerifyReceive(byte[] buffer)
        {
            _mock.Verify(x => x.Receive(buffer));
        }

        public void VerifyClose()
        {
            _mock.Verify(x => x.Close(), Times.Once);
        }

        public void VerifyAccept()
        {
            _mock.Verify(x => x.Close(), Times.Once);
        }

        #endregion

    }
}
