using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai5_UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            string str = "Hello Server";
            byte[] buff;
            Console.WriteLine("Dang gui cau chao len Server...");
            for (int i = 1; i <= 5; i++)
            {
                buff = Encoding.ASCII.GetBytes("Thong Diep " + i.ToString());
                server.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);
            }
            Console.WriteLine("Da gui cau chao len Server...");
            Console.ReadLine();
        }
    }
}
