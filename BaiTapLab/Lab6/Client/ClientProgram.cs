using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Client
{
    class ClientProgram
    {
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction = null;
        byte[] buff = new byte[1024];
        int byteReceive = 0;
        string stringReceive = "";
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint serverEP = null;
        public void Connect(IPAddress serverIP, int Port)
        {
            serverEP = new IPEndPoint(serverIP, Port);
            serverSocket.BeginConnect(serverEP, new AsyncCallback(ConnectCallback), serverSocket);
        }
        private void ConnectCallback(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            try
            {
                SetDataFunction("Đang chờ kết nối");
                s.EndConnect(ia);
                SetDataFunction("Kết nối thành công");
            }
            catch
            {
                SetDataFunction("Kết nối thất bại");
                return;
            }
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveData), s);
        }
        private void ReceiveData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            byteReceive = s.EndReceive(ia);
            stringReceive = Encoding.ASCII.GetString(buff, 0, byteReceive);
            SetDataFunction(stringReceive);
        }
        private void SendData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            s.EndSend(ia);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new
            AsyncCallback(ReceiveData), s);
        }
        public bool Disconnect()
        {
            try
            {
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void SendData(string Data)
        {
            buff = Encoding.ASCII.GetBytes(Data);
            serverSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new
            AsyncCallback(SendToServer), serverSocket);
        }
        private void SendToServer(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            s.EndSend(ia);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new
            AsyncCallback(ReceiveData), s);
        }
    }
}
