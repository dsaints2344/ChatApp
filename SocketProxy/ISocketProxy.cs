﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProxy
{
    /// <summary>
    /// This is interface contains the methods that will used inside the mockup
    /// matching te Socket Class methods
    /// <see cref="Socket"/>
    /// </summary>
    public interface ISocketProxy
    {

        void Connect(IPAddress ip, int port);
        bool Connected();
        void Close();
        void Send(byte[] buffer);
        void Bind(EndPoint localEndPoint);
        void Listen(int backlog);
        int Receive(byte[] buffer);
        ISocketProxy Accept();
        int Login(string command);
        IPAddress RemoteEndPoint();
    }
}
