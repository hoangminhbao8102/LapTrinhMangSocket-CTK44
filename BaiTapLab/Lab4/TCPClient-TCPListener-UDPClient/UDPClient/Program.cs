using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UDPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Connect("127.0.0.1", 5000);
            Console.ReadKey();
        }
        static void Connect(string server, int port)
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect(server, port);
                string message = string.Empty;
                byte[] bytes;
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    Console.Write("> Input: ");
                    message = Console.ReadLine();
                    if (message.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                        break;
                    bytes = Encoding.ASCII.GetBytes(message);

                    udpClient.Send(bytes, bytes.Length);
                    bytes = udpClient.Receive(ref RemoteIpEndPoint);
                    message = Encoding.ASCII.GetString(bytes);
                    Console.WriteLine("Server: " + message);
                }
                udpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
        }
    }
}
