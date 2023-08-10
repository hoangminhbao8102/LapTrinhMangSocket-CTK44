using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Bai3_UDP_Server
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
            byte[] buff;
            int byteReceive;
            string str;
            while (true)
            {
                buff = new byte[1024];
                byteReceive = serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                Console.WriteLine("Da ket noi toi client: " + remote.ToString());
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                serverSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);
                Console.WriteLine("Da dong ket noi toi client");
            }
            serverSocket.Close();
        }
    }
}
