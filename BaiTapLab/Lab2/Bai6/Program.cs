using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Dang ket noi voi server...");
            serverSocket.Connect(serverEndPoint);
            Socket clientSocket = serverSocket.Accept();
            byte[] buff = new byte[1024];
            string str;
            if (serverSocket.Connected)
            {
                Console.WriteLine("Ket noi thanh cong voi server...");
                int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
            }
            while (true)
            {
                buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                clientSocket.Send(buff, 0, byteReceive, SocketFlags.None);
            }
            Console.ReadKey();
        }
    }
}
