using System;
using System.Net;
using System.Net.Sockets;
using ChatServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocketProxy;

namespace ServerTests
{
    [TestClass]
    public class UnitTestServer
    {
        [TestMethod]
        public void StartServer()
        {
            var mockedServer = new MockSocketProxy();
            var testServer = new Server(mockedServer);

            testServer.RunSocket(IPAddress.Parse("180.0.0.0"), 2100);
            mockedServer.VerifyBind(new IPEndPoint(IPAddress.Parse("180.0.0.0"), 2100));
        }

        [TestMethod]
        public void ShutDown_And_Close_Socket()
        {
            var mockedServer = new MockSocketProxy();
            var testServer = new Server(mockedServer);

            testServer.CloseSocket();
            mockedServer.VerifyShutdown(SocketShutdown.Both);
            mockedServer.VerifyClose();
            
        }
    }
}
