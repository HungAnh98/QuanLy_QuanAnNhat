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
        SanPham_BUS sp = new SanPham_BUS();
        public Form_QuanLyHangHoa()
        {
            InitializeComponent();
        }

        private void Form_QuanLyHangHoa_Load(object sender, EventArgs e)
        {
            dt = sp.GetThongTinMenu();
            dgvSanPham.DataSource = dt;

        }
    }
}
