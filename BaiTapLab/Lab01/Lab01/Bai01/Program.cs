using System;
using System.Net;

namespace Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (String arg in args)
            {
                Console.WriteLine("Phan giai ten mien:" + arg);
                GetHostInfo(arg);
            }
            Console.ReadKey();
        }

        static void GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);
                Console.WriteLine("Ten mien: " + hostInfo.HostName);
                Console.Write("Dia chi IP:");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                {
                    Console.Write(ipaddr.ToString() + " ");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Khong phan giai duoc ten mien:" + host + "\n");
            }
        }
    }
}
