using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai6_UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            string str;
            byte[] buff;
            Console.WriteLine("Dang gui cau chao len Server...");
            while (true)
            {
                str = Console.ReadLine();
                buff = Encoding.ASCII.GetBytes(str);
                server.SendTo(buff, 0, buff.Length, SocketFlags.None, serverEndpoint);
                buff = new byte[10];
                int byteReceive = server.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
            }
            Console.WriteLine("Da gui cau chao len Server...");
            Console.ReadLine();
        }
    }
}
