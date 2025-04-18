using System.Net;
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

            SendSocket sendSocket = new SendSocket();
            //아 그 뭐였지 보내기 하쇼
            Packet packet = new Packet(HeaderType.H_string, new object[] { "클라이언트 기모찌" });
            sendSocket.SendPacket(packet.PacketToArray(), null);
            while (true)
            {

            }
        }
    }
}
