using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace QuanLyQuanAnNhat
{
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        Account_BUS account_BUS;
        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            account_BUS = new Account_BUS();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.UserName = txtName.Text;
            acc.Password = txtPass.Text;

            if (acc.UserName == "" || acc.Password == "")
            {
                MessageBox.Show("Khong duoc de rong ten dang nhap hoac mat khau", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (account_BUS.login(acc))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Ten dang nhap hoac mat khau sai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
