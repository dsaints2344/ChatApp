using System;
using System.Net;
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

            testServer.Run(IPAddress.Parse("180.0.0.0"), 2100);
            mockedServer.VerifyBind(new IPEndPoint(IPAddress.Parse("180.0.0.0"), 2100));
        }
    }
}
