using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai4_UDP_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(serverEndpoint);
            Console.WriteLine("Dang cho client ket noi toi...");
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            byte[] buffer = new byte[1024];
            while (true)
            {
                Console.WriteLine("Da ket noi toi client: " + remote.ToString());
                serverSocket.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remote);
                string str = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(str);
            }
        }
    }
}
