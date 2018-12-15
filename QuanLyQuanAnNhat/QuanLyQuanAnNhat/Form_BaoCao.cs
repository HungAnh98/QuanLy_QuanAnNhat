using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BUS;
using DTO;

namespace QuanLyQuanAnNhat
{
    public partial class Form_BaoCao : Form
    {
        NhanVien_BUS nv = new NhanVien_BUS();
        HoaDon_BUS hd = new HoaDon_BUS();
        bool done = false;
        public Form_BaoCao()
        {
            InitializeComponent();
        }

        private void Form_BaoCao_Load(object sender, EventArgs e)
        {
            DataTable table = nv.getEmployeeTable();
            DataRow dr = table.NewRow();
            dr["MaNV"] = 0;
            dr["Ten"] = "*";
            dr["GioiTinh"] = "Nam";
            dr["NgaySinh"] = new DateTime(2000,1,1);
            dr["ChucVu"] = "QL";
            dr["Luong"] = 100000;
            dr["SDT"] = 0123456789;
            table.Rows.Add(dr);
            cbxNhanVien.DataSource = table;
            cbxNhanVien.DisplayMember = table.Columns["Ten"].ToString();
            cbxNhanVien.ValueMember = table.Columns["MaNV"].ToString();
            done = true;

        }
        private void cbxNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            if (done == true)
            {
                lsvBaoCao.Items.Clear();
                if (cbxNhanVien.SelectedValue.ToString() == "0")
                {
                    DataTable tb = hd.GetThongTinHoaDonTrongThang();
                    foreach (DataRow dr in tb.Rows)
                    {
                        ListViewItem listViewItem = new ListViewItem(dr["MaHD"].ToString());
                        listViewItem.SubItems.Add(dr["MaNV"].ToString());
                        listViewItem.SubItems.Add(dr["MaBan"].ToString());
                        listViewItem.SubItems.Add(dr["TongTien"].ToString());
                        listViewItem.SubItems.Add(dr["ThoiGian"].ToString());
                        lsvBaoCao.Items.Add(listViewItem);
                    }
                }
                else
                {
                    int id = int.Parse(cbxNhanVien.SelectedValue.ToString().Trim());
                    DataTable tb = hd.GetThongTinHoaDonByIDNhanVienTrongThang(id);
                    foreach (DataRow dr in tb.Rows)
                    {
                        ListViewItem listViewItem = new ListViewItem(dr["MaHD"].ToString());
                        listViewItem.SubItems.Add(dr["MaNV"].ToString());
                        listViewItem.SubItems.Add(dr["MaBan"].ToString());
                        listViewItem.SubItems.Add(dr["TongTien"].ToString());
                        listViewItem.SubItems.Add(dr["ThoiGian"].ToString());
                        lsvBaoCao.Items.Add(listViewItem);
                    }
                }
            }

        }

        private void cbxNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
