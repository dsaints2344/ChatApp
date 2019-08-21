﻿using System;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            mockedClient.VerifyConnect("180.0.0.0", 2100);
            //mockedClient.VerifyBind();
        }


        [TestMethod]
        public void Exit_Chat()
        {
            var mockedClient = new MockSocketProxy();
            var testClient = new Client(mockedClient);

            testClient.Exit_Chat();
            mockedClient.VerifyClose();

        }
    }
}
