using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmDangNhap : Form
    {
        List<Account> accountList = ListAccount.Instance.AccountList;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy f = new frmDangKy();
            f.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraTaiKhoan(tbDangNhap.Text, tbMatKhau.Text))
            {
                frmClient f = new frmClient();
                f.SetText(tbDangNhap.Text);
                f.ShowDialog();
                this.Hide();
                f.DangXuat += F_DangXuat;
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu! Vui lòng nhập lại.", "Lỗi");
                tbDangNhap.Focus();
            }
        }

        public void SetText(string s)
        {
            this.tbDangNhap.Text = s;
        }

        private void F_DangXuat(object sender, EventArgs e)
        {
            (sender as frmClient).exit = false;
            (sender as frmClient).Close();
            this.Show();
        }

        bool KiemTraTaiKhoan(string username, string password)
        {
            for (int i = 0; i < accountList.Count; i++)
            {
                if (username == accountList[i].Username && password == accountList[i].Password) return true;
            }
            return false;
        }
    }
}
