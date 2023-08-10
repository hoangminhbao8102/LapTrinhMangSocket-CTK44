using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Bai3_UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            string str;
            byte[] buff;
            int byteReceive;
            Console.WriteLine("Dang gui cau chao len Server...");
            Console.ReadLine();
            while (true)
            {
                str = "Hello Server";
                buff = Encoding.ASCII.GetBytes(str);
                serverSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, serverEndpoint);
                Console.WriteLine("Da gui cau chao len Server...");
                byteReceive = serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
            }
            Console.WriteLine("Da thoat chuong trinh Client");
            Console.ReadLine();
            serverSocket.Close();
        }
    }
}
