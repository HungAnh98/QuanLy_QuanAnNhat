using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAnNhat
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            Form_DangNhap frmDN = new Form_DangNhap();
            frmDN.ShowDialog();
            DialogResult result = frmDN.DialogResult;
            if (result == DialogResult.OK)
            {
                this.Visible = true;
            }
        }

        private void tlblOrder_Click(object sender, EventArgs e)
        {
            Form_Order frmOrder = new Form_Order();
            frmOrder.ShowDialog();
        }

        private void tlblNhanVien_Click(object sender, EventArgs e)
        {
            Form_QuanLyNhanVien frmOrder = new Form_QuanLyNhanVien();
            frmOrder.ShowDialog();
        }

        private void tlblHangHoa_Click(object sender, EventArgs e)
        {
            Form_QuanLyHangHoa frmOrder = new Form_QuanLyHangHoa();
            frmOrder.ShowDialog();
        }
    }
}
