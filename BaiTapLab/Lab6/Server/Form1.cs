using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class frmServer : Form
    {
        private IPAddress ServerIP;
        private int Port;
        public delegate void SetStatusControl(string Data);
        public SetStatusControl SetStatusFunction = null;
        byte[] buff = new byte[1024];
        Socket clientSocket = null;
        int byteReceive;
        string stringReceive;
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction = null;

        public frmServer()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            Listen();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Listen();
        }

        void Listen()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(ServerIP, Port);
            serverSocket.Bind(serverEP);
            serverSocket.Listen(-1);
            SetStatusFunction("Dang cho ket noi");
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
        }

        void AcceptCallback(IAsyncResult ar)
        {
            Socket s = (Socket)ar.AsyncState;
            clientSocket = s.EndAccept(ar);
            string hello = "Hello Client!";
            buff = Encoding.ASCII.GetBytes(hello);
            SetStatusFunction("Client " + clientSocket.RemoteEndPoint.ToString() + " da ket noi den");
            clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);
        }

        void SendCallback(IAsyncResult ar)
        {
            Socket s = (Socket)ar.AsyncState;
            s.EndSend(ar);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), s);
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            Socket s = (Socket)ar.AsyncState;
            try
            {
                byteReceive = s.EndReceive(ar);
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
                s.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendCallback), s);
            }
        }
    }
}