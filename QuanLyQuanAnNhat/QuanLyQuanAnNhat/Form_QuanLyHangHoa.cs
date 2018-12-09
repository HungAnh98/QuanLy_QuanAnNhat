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
        int index;
        DataTable dt = new DataTable();
        SanPham_BUS product = new SanPham_BUS();
        int flag;
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
            if (string.IsNullOrWhiteSpace(txtTenSP.Text) || string.IsNullOrWhiteSpace(txtDonVi.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text))
            {
                MessageBox.Show("Ban phai nhap day du thong tin");
                return;
            }
            else
            {
                flag = 1;
                product.AddProduct_Bus(getInfo(), dt);
                clear();
            }
            
        }

        private SanPham getInfo()
        {
            SanPham sp;
            string tenSP, donVi;
            int giaBan, maSP;
            try
            {
                if (flag == 0)
                {
                    maSP = int.Parse(txtMaSP.Text);
                }
                else
                    maSP = (int.Parse(dgvSanPham.Rows[dgvSanPham.Rows.Count - 1].Cells["MaSP"].Value.ToString())) + 1;
                tenSP = txtTenSP.Text;
                donVi = txtDonVi.Text;
                giaBan = int.Parse(txtGiaBan.Text);
                sp = new SanPham(maSP, tenSP, donVi, giaBan);
            }
            catch (FormatException)
            {
                sp = null;
            }
            return sp;
        }

        private void clear()
        {
            txtMaSP.Text = txtTenSP.Text = txtDonVi.Text = txtGiaBan.Text = "";
            txtTenSP.Focus();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvSanPham.Columns[col] is DataGridViewButtonColumn && dgvSanPham.Columns[col].Name == "xoa")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    try
                    {
                        int number = product.DelProduct_Bus(row, dt);
                        if (number > 0)
                        {
                            MessageBox.Show("Xóa thành công");
                            dt = product.GetThongTinMenu();
                        }
                        else
                            MessageBox.Show("Không xóa được");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thể xóa món ăn này vì món ăn này đã xuất hiện trong một số hóa đơn");
                    }
                    finally
                    {

                        dgvSanPham.ClearSelection();
                        clear();

                        dgvSanPham.DataSource = dt; 
                    }
                }
            }
            
        }

        private void dgvSanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = index = e.RowIndex;
            if (row >= 0)
            {
                if (dgvSanPham.Columns[col] is DataGridViewTextBoxColumn && dgvSanPham.Columns[col].Name != "xoa")
                {
                    txtMaSP.Text = dgvSanPham.Rows[row].Cells["MaSP"].Value.ToString();

                    txtTenSP.Text = dgvSanPham.Rows[row].Cells["Ten"].Value.ToString();

                    txtDonVi.Text = dgvSanPham.Rows[row].Cells["DonVi"].Value.ToString();

                    txtGiaBan.Text = dgvSanPham.Rows[row].Cells["GiaBan"].Value.ToString();
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTenSP.Text) || string.IsNullOrWhiteSpace(txtDonVi.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text))
            {
                MessageBox.Show("Ban phai nhap day du thong tin");
                return;
            }
            else
	        {
                flag = 0;
                product.Edit_Bus(getInfo(), dt, index);
                clear();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                product.Save_Bus(dt);
            }
            catch (SqlException)
            {

                MessageBox.Show("Không thể xóa món ăn này vì liên quan đến các bảng khác");
                dt = product.GetThongTinMenu();
                dgvSanPham.DataSource = dt;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
