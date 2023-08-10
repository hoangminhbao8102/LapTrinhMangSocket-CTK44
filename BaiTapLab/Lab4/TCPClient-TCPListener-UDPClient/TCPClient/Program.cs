using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
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
            try
            {
                TcpClient client = new TcpClient(server, port);
                string message = string.Empty;
                byte[] data;
                NetworkStream stream = client.GetStream();
                while (true)
                {
                    Console.Write("> Input: ");
                    message = Console.ReadLine();
                    if (message.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                        break;
                    data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    if (message.Equals("exit all", StringComparison.InvariantCultureIgnoreCase))
                        break;
                    data = new byte[1024];
                    string response = String.Empty;
                    int bytes = stream.Read(data, 0, data.Length);
                    response = Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine("Server: " + response);

                }
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}