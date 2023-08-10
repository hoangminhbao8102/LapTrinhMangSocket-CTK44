using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TCPListener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunWithOnlyClient();
            Console.ReadKey();
        }
        private static void RunWithOnlyClient()
        {
            TcpListener server = null;
            string data = string.Empty;
            byte[] bytes;
            try
            {
                int port = 5000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();
                bytes = new byte[1024];
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected successfully");
                Console.WriteLine("Found client at {0}", client.Client.RemoteEndPoint.ToString());
                NetworkStream stream = client.GetStream();
                while (true)
                {
                    data = null;
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) // Loop to receive all the data sent by the client
                    {
                        data = Encoding.UTF8.GetString(bytes, 0, i); // Translate data bytes to a UTF8 string
                        if (data.Equals("exit all", StringComparison.InvariantCultureIgnoreCase))
                            break;
                        Console.WriteLine("Client: " + data);
                        Console.Write("> Input: ");
                        data = Console.ReadLine();
                        byte[] msg = Encoding.UTF8.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                    }
                }
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: " + e);
            }
            finally
            {
                server.Stop();
            }
        }
    }
}
