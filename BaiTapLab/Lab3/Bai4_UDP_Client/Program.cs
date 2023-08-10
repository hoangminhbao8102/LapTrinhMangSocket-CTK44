using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai4_UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Connect(serverEndpoint);
            Console.WriteLine("Dang gui cau chao len Server...");
            if (!server.Connected)
            {
                Console.WriteLine("Co loi trong qua trinh ket noi");
                return;
            }
            while (true)
            {
                string str = Console.ReadLine();
                Console.WriteLine(str);
                if (str == "exit") break;
                byte[] data = Encoding.UTF8.GetBytes(str);
                server.Send(data);
                Console.WriteLine("Da gui cau chao len Server...");
            }
            Console.WriteLine("Da thoat chuong trinh client");
            Console.ReadLine();
            server.Close();
        }
    }
}
