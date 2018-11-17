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
    public partial class Form_QuanLyNhanVien : Form
    {


        NhanVien_BUS pr = new NhanVien_BUS();
        DataTable dt = new DataTable();
        int index = 0;
        int flag;
        public Form_QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void Form_QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;

            dt = pr.getEmployeeTable();
            dgvNhanVien.DataSource = dt;
        }

        private void clear()
        {

            txtSDT.Text = txtTenNV.Text = txtMaNV.Text = txtLuong.Text = txtChucVu.Text = "";
            cbGioiTinh.Text = null;
            dateTimePicker1.Value = DateTime.Parse("1/1/1990");

        }

        private NhanVien getInfo()
        {
            int maNV;
            string ten, gioiTinh, chucVu, diaChi;
            DateTime ngaySinh;
            int sdt;
            int luong;
            if (flag == 0)
            {
                maNV = int.Parse(txtMaNV.Text);
            }
            else
                maNV = (int.Parse(dgvNhanVien.Rows[dgvNhanVien.Rows.Count - 1].Cells["MaNV"].Value.ToString())) + 1;
            ten = txtTenNV.Text;
            ngaySinh = dateTimePicker1.Value.Date;//DateTime.Now.Date;
            sdt = int.Parse(txtSDT.Text);
            chucVu = txtChucVu.Text;
            gioiTinh = cbGioiTinh.Text;
            luong = int.Parse(txtLuong.Text);
            diaChi = txtDiaChi.Text;

            NhanVien nv = new NhanVien(maNV, ten, gioiTinh, ngaySinh, chucVu, luong, sdt, diaChi);
            return nv;
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
