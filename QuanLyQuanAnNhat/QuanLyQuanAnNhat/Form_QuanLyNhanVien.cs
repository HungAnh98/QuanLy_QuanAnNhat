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
            try
            {
                dt = pr.getEmployeeTable();
                dgvNhanVien.DataSource = dt;
            }
            catch (SqlException)
            {

                MessageBox.Show("Lỗi lấy dữ liệu");
            }
            
        }

        private void clear()
        {

            txtSDT.Text = txtTenNV.Text = txtMaNV.Text = txtLuong.Text = txtChucVu.Text = "";
            cbGioiTinh.Text = null;
            txtTenNV.Focus();
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
                gioiTinh = cbGioiTinh.Text;
                ngaySinh = dateTimePicker1.Value.Date;
                sdt = int.Parse(txtSDT.Text);
                chucVu = txtChucVu.Text;
                ten = txtTenNV.Text;
                luong = int.Parse(txtLuong.Text);
                diaChi = txtDiaChi.Text;

                NhanVien nv = new NhanVien(maNV, ten, gioiTinh, ngaySinh, chucVu, luong, sdt, diaChi);

            return nv;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(cbGioiTinh.Text) || string.IsNullOrWhiteSpace(txtChucVu.Text) || string.IsNullOrWhiteSpace(txtLuong.Text))
                {
                    MessageBox.Show("Ban phai nhap day du thong tin");
                    return;
                }
                else
                {
                    if((cbGioiTinh.Text.Trim() == "Nam" || cbGioiTinh.Text.Trim() == "Nữ") && (txtChucVu.Text.Trim() == "NV" || txtChucVu.Text.Trim() == "QL"))
                    {
                        flag = 1;
                        pr.AddEmp(getInfo(), dt);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Ban phai nhap thong tin cho chinh xac o mục Gioi tính hoặc mục Chức vụ!");
                        return;
                    }
                }
                
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

            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(cbGioiTinh.Text) || string.IsNullOrWhiteSpace(txtChucVu.Text) || string.IsNullOrWhiteSpace(txtLuong.Text))
                {
                    MessageBox.Show("Ban phai nhap day du thong tin");
                    return;
                }
                else
                {
                    if ((cbGioiTinh.Text.Trim() == "Nam" || cbGioiTinh.Text.Trim() == "Nữ") && (txtChucVu.Text.Trim() == "NV" || txtChucVu.Text.Trim() == "QL"))
                    {
                        flag = 0;
                        pr.editEm(getInfo(), dt, index);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Ban phai nhap thong tin cho chinh xac o mục Gioi tính hoặc mục Chức vụ!");
                        return;
                    }
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("sai nha"); ;
            }
            
          
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                pr.Save(dt, "NhanVien");
            }
            catch (SqlException)
            {

                MessageBox.Show("Không thể xóa nhân viên này vì có liên quan đến các bảng khác");
                dt = pr.getEmployeeTable();
                dgvNhanVien.DataSource = dt;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
