using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class frmClient : Form
    {
        public bool exit = true; 
        public event EventHandler DangXuat;

        public frmClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        public void SetText(string s)
        {
            this.lblUsername.Text = s;
        }

        public Account GetAccount()
        {
            Account account = new Account();
            ListAccount listAccount = new ListAccount();
            account.Username = this.lblUsername.Text;
            this.lblNumber.Text = listAccount.AccountCount(account.Username).ToString();
            return account;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(tbMessage.Text);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (exit) Application.Exit();
        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                if (MessageBox.Show("Bạn muốn thoát chương trình", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        IPEndPoint IP;
        Socket client;

        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread thread = new Thread(Receive);
            thread.IsBackground = true;
            thread.Start();
        }

        void Close()
        {
            client.Close();
        }

        void Send()
        {
            if (tbMessage.Text != string.Empty)
                client.Send(Serialize(tbMessage.Text));
        }

        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }
        }

        void AddMessage(string m)
        {
            lbMessage.Items.Add(new ListViewItem() { Text = m });
            tbMessage.Clear();
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

    }
}
