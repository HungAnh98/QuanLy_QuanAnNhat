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

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
