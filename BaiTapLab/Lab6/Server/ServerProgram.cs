using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class ServerProgram
    {
        private IPAddress serverIP;
        public IPAddress ServerIP 
        { 
            get 
            { 
                return serverIP; 
            } 
            set 
            { 
                this.serverIP = value; 
            } 
        }
        private int port;
        public int Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction = null;
        public delegate void SetStatusControl(string Data);
        public SetStatusControl SetStatusFunction = null;
        Socket serverSocket = null;
        IPEndPoint serverEP = null;
        Socket clientSocket = null;
        byte[] buff = new byte[1024];
        int byteReceive = 0;
        string stringReceive = "";
        public ServerProgram(IPAddress ServerIP, int Port)
        {
            this.ServerIP = ServerIP;
            this.Port = Port;
        }
        public void Listen()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverEP = new IPEndPoint(ServerIP, Port);
            serverSocket.Bind(serverEP);
            serverSocket.Listen(-1);
            SetStatusFunction("Dang cho ket noi");
            serverSocket.BeginAccept(new AsyncCallback(AcceptSocket), serverSocket);
        }
        private void AcceptSocket(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            clientSocket = s.EndAccept(ia);
            string hello = "Hello Client!";
            buff = Encoding.ASCII.GetBytes(hello);
            SetStatusFunction("Client " + clientSocket.RemoteEndPoint.ToString() + " da ket noi den");
            clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), clientSocket);
        }
        private void SendData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            s.EndSend(ia);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveData), s);
        }
        public void Close()
        {
            clientSocket.Close();
            serverSocket.Close();
        }
        private void ReceiveData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            try
            {
                 byteReceive = s.EndReceive(ia);
            }
            catch
            {
                this.Close();
                SetStatusFunction("Client ngat ket noi");
                this.Listen();
                return;
            }
            if (byteReceive == 0)
            {
                Close();
                SetStatusFunction("Clien dong ket noi");
            }
            else
            {
                stringReceive = Encoding.ASCII.GetString(buff, 0, byteReceive);
                SetDataFunction(stringReceive);
                s.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), s);
            }
        }
    }
}
