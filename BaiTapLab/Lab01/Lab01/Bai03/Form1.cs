using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class frmPhanGiai : Form
    {
        public frmPhanGiai()
        {
            InitializeComponent();
            Init();
        }

        private void btnPhanGiai_Click(object sender, EventArgs e)
        {
            string mien = txtNhap.Text;
            string ip = GetHostInfo(mien);
            //IPAddress subnetMask = GetSubnetMask();
            //IPAddress defaultGateway = GetDefaultGateway();
            if (!string.IsNullOrWhiteSpace(ip))
            {
                txtIPv4.Text = ip;
                txtSubnetMask.Text = ip;
                txtDefaultGateway.Text = ip;
            }
        }

        public void Init()
        {
            IPAddress ip = GetLocalIPAddress();
            IPAddress subnetMask = GetSubnetMask(ip);
            IPAddress defaultGateway = GetDefaultGateway();

            txtIPv4.Text = ip.ToString();
            txtSubnetMask.Text = subnetMask.ToString();
            txtDefaultGateway.Text = defaultGateway.ToString();
        }

        string GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);
                StringBuilder result = new StringBuilder();
                foreach (IPAddress iPAddress in hostInfo.AddressList)
                {
                    result.AppendLine(iPAddress.ToString());
                }
                return result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Co loi xay ra trong qua trinh phan giai ten mien");
                return null;
            }
        }
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Khong co bo dieu hop mang co dia chi IPv4 trong he thong!");
        }

        public static IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Khong the tim thay mat na mang con cho dia chi IP '{0}'", address));
        }
        public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .FirstOrDefault();
        }
    }
}
