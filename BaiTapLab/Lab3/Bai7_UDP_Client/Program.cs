using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai7_UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string str = "Hello Server";
            byte[] buff = Encoding.ASCII.GetBytes(str);
            Console.WriteLine("Dang gui cau chao len Server...");
            server.SendTo(buff, buff.Length, SocketFlags.None, serverEndpoint);
            Console.WriteLine("Da gui cau chao len Server...");
            Console.ReadLine();
        }
    }
}
