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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                flag = 1;
                pr.AddEmp(getInfo(), dt);
                clear();






            }
            catch (SqlException)
            {

                MessageBox.Show("sai nha"); ;
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvNhanVien.Columns[col] is DataGridViewButtonColumn && dgvNhanVien.Columns[col].Name == "xoa")
            {
                if (row >= 0 && row < dgvNhanVien.Rows.Count)
                    pr.Del(row, dt);
                clear();
                dgvNhanVien.DataSource = dt;




            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // dt = pr.getEmployeeTable()
            flag = 0;
            pr.editEm(getInfo(), dt, index);
            // dgvNhanVien.DataSource = dt;
        }

        private void dgvNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int row = index = e.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[row].Cells["MaNV"].Value.ToString();

            txtTenNV.Text = dgvNhanVien.Rows[row].Cells["Ten"].Value.ToString();

            cbGioiTinh.Text = dgvNhanVien.Rows[row].Cells["GioiTinh"].Value.ToString();

            txtChucVu.Text = dgvNhanVien.Rows[row].Cells["ChucVu"].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dgvNhanVien.Rows[row].Cells["NgaySinh"].Value.ToString());

            txtLuong.Text = dgvNhanVien.Rows[row].Cells["Luong"].Value.ToString();

            txtSDT.Text = dgvNhanVien.Rows[row].Cells["SDT"].Value.ToString();
        }
    }
}
