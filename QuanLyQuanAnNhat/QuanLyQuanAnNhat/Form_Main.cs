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
        int MaNV;
        string ChucVu;
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
                MaNV = frmDN.MaNV;
                ChucVu = frmDN.ChucVu.Trim();
                this.Visible = true;
            }
            
        }
        private void tlblOrder_Click(object sender, EventArgs e)
        {
            if (ChucVu == "NV")
            {
                Form_Order frmOrder = new Form_Order(MaNV);
                frmOrder.ShowDialog();
            }
            else
                MessageBox.Show("Phần này chỉ dành cho nhân viên", "Thông Báo");
        }

        private void tlblNhanVien_Click(object sender, EventArgs e)
        {
            if (ChucVu == "QL")
            {
                Form_QuanLyNhanVien frmOrder = new Form_QuanLyNhanVien();
                frmOrder.ShowDialog();
            }
            else
                MessageBox.Show("Phần này chỉ dành cho quản lý , nhân viên thì ra chỗ khác chơi", "Thông Báo");
        }

        private void tlblHangHoa_Click(object sender, EventArgs e)
        {
            if (ChucVu == "QL")
            {
                Form_QuanLyHangHoa frmOrder = new Form_QuanLyHangHoa();
                frmOrder.ShowDialog();
            }
            else
                MessageBox.Show("Phần này chỉ dành cho quản lý , nhân viên thì ra chỗ khác chơi", "Thông Báo");
        }

        private void tlblSignOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form_DangNhap frmDN = new Form_DangNhap();
            frmDN.ShowDialog();
            DialogResult result = frmDN.DialogResult;
            if (result == DialogResult.OK)
            {
                MaNV = frmDN.MaNV;
                ChucVu = frmDN.ChucVu.Trim();
                this.Visible = true;
            }
            
        }

        private void tlblBaoCao_Click(object sender, EventArgs e)
        {

        }
    }
}
