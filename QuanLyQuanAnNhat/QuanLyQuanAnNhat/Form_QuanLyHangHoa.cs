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
using BUS;
using DTO;
namespace QuanLyQuanAnNhat
{
    public partial class Form_QuanLyHangHoa : Form
    {
        DataTable dt = new DataTable();
        SanPham_BUS product = new SanPham_BUS();
        public Form_QuanLyHangHoa()
        {
            InitializeComponent();
        }

        private void Form_QuanLyHangHoa_Load(object sender, EventArgs e)
        {
            dt = product.GetThongTinMenu();
            dgvSanPham.DataSource = dt;

        } 

        private void btnAdd_Click(object sender, EventArgs e)
        {
            product.addProduct_Bus(getInfo(), dt);
        }

        private SanPham getInfo()
        {
            string maSP, tenSP, donVi;
            int giaBan;
            maSP = txtMaSP.Text;
            tenSP = txtTenSP.Text;
            donVi = txtDonVi.Text;
            giaBan = int.Parse(txtGiaBan.Text);
            SanPham sp = new SanPham(maSP, tenSP, donVi, giaBan);
            return sp;
        }
    }
}
