using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmClient : Form
    {
        private IPAddress ServerIP;
        private int Port;
        Socket serverSocket;
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction = null;
        byte[] buff = new byte[1024];
        int byteReceive;
        string stringReceive;

        public frmClient()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPEndPoint serverEP = new IPEndPoint(ServerIP, Port);
            serverSocket.BeginConnect(serverEP, new AsyncCallback(ConnectCallback), serverSocket);
        }

        void ConnectCallback(IAsyncResult ar)
        {
            Socket s = (Socket)ar.AsyncState;
            try
            {
                SetDataFunction("Đang chờ kết nối");
                s.EndConnect(ar);
                SetDataFunction("Kết nối thành công");
            }
            catch
            {
                SetDataFunction("Kết nối thất bại");
                return;
            }
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), s);
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            Socket s = (Socket)ar.AsyncState;
            byteReceive = s.EndReceive(ar);
            stringReceive = Encoding.ASCII.GetString(buff, 0, byteReceive);
            SetDataFunction(stringReceive);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
        }

        void SendCallback(IAsyncResult ar)
        {
            Socket s = (Socket)ar.AsyncState;
            s.EndSend(ar);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), s);
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
            serverSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendToServer), serverSocket);
        }
        private void SendToServer(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            s.EndSend(ia);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new
            AsyncCallback(ReceiveCallback), s);
        }
    }
}