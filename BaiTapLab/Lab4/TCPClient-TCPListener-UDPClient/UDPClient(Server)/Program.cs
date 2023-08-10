using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UDPClient_Server_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Connect(5000);
            Console.ReadKey();
        }
        static void Connect(int port)
        {
            UdpClient udpClient = new UdpClient(port);
            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Waiting for a connection...");
            while (true)
            {
                byte[] bytes = udpClient.Receive(ref remote);
                string message = Encoding.UTF8.GetString(bytes);
                if (message.Equals("exit all", StringComparison.InvariantCultureIgnoreCase))
                    break;
                Console.WriteLine("Client: " + message);
                Console.Write("> Input: ");
                message = Console.ReadLine();
                bytes = Encoding.UTF8.GetBytes(message);
                udpClient.Send(bytes, bytes.Length, remote);
            }
            udpClient.Close();
        }
    }
}
