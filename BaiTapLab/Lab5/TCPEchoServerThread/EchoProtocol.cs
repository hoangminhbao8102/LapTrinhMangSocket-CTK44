using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPEchoServerThread
{
    class EchoProtocol : IProtocol
    {
        public const int BUFSIZE = 32;
        private Socket clientSocket;
        private ILogger logger;
        public EchoProtocol(Socket clientSocket, ILogger logger)
        {
            this.clientSocket = clientSocket;
            this.logger = logger;
        }

        public void HandleClient()
        {
            ArrayList entry = new ArrayList();
            entry.Add("Client address and port = " + clientSocket.RemoteEndPoint);
            entry.Add("Thread = " + Thread.CurrentThread.GetHashCode());
            try
            {
                int ReceivedMessageSize;
                int TotalBytesEchoed = 0;
                byte[] ReceiveBuffer = new byte[BUFSIZE];
                try
                {
                    while ((ReceivedMessageSize = clientSocket.Receive(ReceiveBuffer, 0, ReceiveBuffer.Length, SocketFlags.None)) > 0)
                    {
                        clientSocket.Send(ReceiveBuffer, 0, ReceivedMessageSize, SocketFlags.None);
                        TotalBytesEchoed += ReceivedMessageSize;
                    }
                }
                catch (SocketException se)
                {
                    entry.Add(se.ErrorCode + ": " + se.Message);
                }
                entry.Add("Client finished; echoed " + TotalBytesEchoed + " bytes.");
            }
            catch (SocketException se)
            {
                entry.Add(se.ErrorCode + ": " + se.Message);
            }
            clientSocket.Close();
            logger.WriteEntry(entry);
        }
    }
}