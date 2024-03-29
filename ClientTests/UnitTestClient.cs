﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ChatClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocketProxy;

namespace ClientTests
{
    [TestClass]
    public class UnitTestClient
    {
        [TestMethod]
        public void Start_Client_And_Send_Connections()
        {
            var mockedClient = new MockSocketProxy();
            var testClient = new Client(mockedClient);

            IPAddress ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            testClient.StartClient(IPAddress.Parse("180.0.0.0"), 2100);
            mockedClient.VerifyConnect(IPAddress.Parse("180.0.0.0"),2100);
            byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
            mockedClient.VerifySend(msg);
        }


        [TestMethod]
        public void Exit_Chat()
        {
            var mockedClient = new MockSocketProxy();
            var testClient = new Client(mockedClient);

            testClient.ExitClient();
            mockedClient.VerifyClose();

        }
    }
}
