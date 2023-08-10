using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Bai2_UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Console.WriteLine("Nhap cau chao ve phia Server: ");
            string str = Console.ReadLine();
            if (str.ToLower() == "exit" && str.ToUpper() == "EXIT")
            {
                server.Close();
                Console.WriteLine("Da thoat chuong trinh Client");
                Console.ReadLine();
                return;
            }
            if (str.ToLower() == "exit all" && str.ToUpper() == "EXIT ALL")
            {
                server.Close();
                Console.WriteLine("Da thoat chuong trinh Client va Server");
                Console.ReadKey();
                return;
            }
            byte[] buff = Encoding.ASCII.GetBytes(str);
            Console.WriteLine("Dang gui cau chao len Server...");
            server.SendTo(buff, buff.Length, SocketFlags.None, serverEndpoint);
            Console.WriteLine("Da gui cau chao len Server...");
            Console.ReadLine();
        }
    }
}
