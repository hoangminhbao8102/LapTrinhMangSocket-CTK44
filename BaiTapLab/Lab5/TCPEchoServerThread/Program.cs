﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPEchoServerThread
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Parameter(s): <Port>");
            }
            int serverPort = Int32.Parse(args[0]);
            TcpListener listener = new TcpListener(IPAddress.Any, serverPort);
            ILogger logger = new ConsoleLogger();
            listener.Start();
            for (; ; )
            {
                try
                {
                    Socket client = listener.AcceptSocket();
                    EchoProtocol protocol = new EchoProtocol(client, logger);
                    Thread thread = new Thread(new ThreadStart(protocol.HandleClient));
                    thread.Start();
                    logger.WriteEntry("Created and started Thread = " + thread.GetHashCode());
                }
                catch (IOException e)
                {
                    logger.WriteEntry("Error: " + e.Message);
                    throw;
                }
            }
        }
    }
}
