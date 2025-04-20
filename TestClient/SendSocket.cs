using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    internal class SendSocket
    {
        //패킷의 크기가 1024바이트 이상이면 세그먼트로 분리해서 보내야 하기 때문에 필요한 변수임
        const int MaxPacketLength = 1024;
        Socket socket;
        public SendSocket(Socket socket)
        {
            this.socket = socket;
        }
        //패킷을 세그먼트로 분리해 만들어주는 함수
        public async void SendPacket(byte[] data)
        {

            int segmentCount = data.Length / MaxPacketLength;
            int dataSize = data.Length;
            if (segmentCount == 0)
            {
                ArraySegment<byte> segment = new ArraySegment<byte>(data, 0, data.Length);
                await SendAsync(segment);
                return;
            }
            for (int i = 0; i < segmentCount; i++)
            {
                dataSize -= MaxPacketLength;
                ArraySegment<byte> segment;
                if (dataSize < MaxPacketLength)
                    segment = new ArraySegment<byte>(data, MaxPacketLength * i, dataSize);
                else
                    segment = new ArraySegment<byte>(data, MaxPacketLength * i, dataSize);

                await SendAsync(segment);                
            }
        }

        async Task SendAsync(ArraySegment<byte> packet)
        {
            await socket.SendAsync(packet);
        }
    }
}
