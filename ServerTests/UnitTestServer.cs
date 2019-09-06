using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using ChatServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocketProxy;

namespace ServerTests
{
    [TestClass]
    public class UnitTestServer
    {
        [TestMethod]
        public void Start_Server_And_Listen_Connections()
        {
            var mockedServer = new MockSocketProxy();
            var testServer = new Server(mockedServer);

            testServer.RunSocket(IPAddress.Parse("180.0.0.0"), 2100);
            mockedServer.VerifyBind(new IPEndPoint(IPAddress.Parse("180.0.0.0"), 2100));
            mockedServer.VerifyListen(6);
        }


        [TestMethod]
        public void Close_Socket()
        {
            var mockedServer = new MockSocketProxy();
            var testServer = new Server(mockedServer);

            testServer.CloseSocket();
            mockedServer.VerifyClose();
            
        }

        [TestMethod]
        public void Get_Client_IP_Address()
        {
            var mockedServer = new MockSocketProxy();
            var testServer = new Server(mockedServer);

            testServer.RunSocket(IPAddress.Parse("180.0.0.0"), 2100);
            mockedServer.VerifyBind(new IPEndPoint(IPAddress.Parse("180.0.0.0"), 2100));
            mockedServer.VerifyListen(6);
            testServer.ReceiveConnections();
            mockedServer.VerifyRemoteEndPoint();

        }
    }
}
