using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai5_UDP_Server
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
            byte[] buff = new byte[1024];
            string str;
            for (int i = 1; i <= 5; i++)
            {
                int byteReceive = serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
            }
            Console.WriteLine("Da ket noi toi client: " + remote.ToString());
            Console.WriteLine("Da dong ket noi toi client");
            Console.ReadLine();
            serverSocket.Close();
        }
    }
}
