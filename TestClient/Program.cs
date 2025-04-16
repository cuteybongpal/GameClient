﻿using System.Net;
using System.Net.Sockets;

namespace TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 0);

            IPEndPoint connectAddr = new IPEndPoint(ipAddr, 7777);
            Socket socket =  new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Connect(connectAddr);
            //아 그 뭐였지 보내기 하쇼
            while (true)
            {

            }
        }
    }
}
