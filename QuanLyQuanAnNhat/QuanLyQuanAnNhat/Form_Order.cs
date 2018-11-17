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
namespace QuanLyQuanAnNhat
{
    public partial class Form_Order : Form
    {
        public Form_Order()
        {
            InitializeComponent();
        }
        
        
        HoaDon_BUS hdBus = new HoaDon_BUS();
        Ban_BUS banBus = new Ban_BUS();
        HoaDonChiTiet_BUS hdctBus = new HoaDonChiTiet_BUS();
        SanPham_BUS spBus = new SanPham_BUS();

        DataTable TableHoaDon = new HoaDon_BUS().GetThongTinHoaDon();
        DataTable TableHoaDonChiTiet = new HoaDonChiTiet_BUS().GetThongTinHoaDonChiTiet();
        DataTable daTable;
        DataRow daRow;

        int soBan = 0;
        int hoaDon = -1;
        int Tong;
        bool tinhTrangBan;

        private void Form_Order_Load(object sender, EventArgs e)
        {

            daTable = spBus.GetThongTinMenu();
            foreach (DataRow row in daTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["Ten"].ToString());
                item.SubItems.Add(row["DonVi"].ToString());
                item.SubItems.Add(row["GiaBan"].ToString());
                item.SubItems.Add(row["MaSP"].ToString());
                lstMenu.Items.Add(item);
            }
            foreach(Button bt in tabPage2.Controls)
            {
                int id = int.Parse(bt.Name.Substring(6));
                tinhTrangBan = Convert.ToBoolean(banBus.GetTinhTrangBanByIDBan(id)["TinhTrang"]);
                if (tinhTrangBan == false)
                    bt.BackColor = Color.Green;
                else
                    bt.BackColor = Color.Red;              
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            bool has = false;
            int sl;
            ListView.SelectedListViewItemCollection listItem = lstMenu.SelectedItems;
            if (listItem.Count != 0)
            {
                foreach (ListViewItem i in listItem)
                {
                    foreach (ListViewItem it in lsvBill.Items)
                    {
                        if (i.Text == it.Text)
                        {
                            has = true;
                            sl = int.Parse(it.SubItems[1].Text);
                            sl++;
                            it.SubItems[1].Text = sl.ToString();
                            break;
                        }
                        else
                            has = false;
                    }
                    if (!has)
                    {
                        sl = 1;
                        ListViewItem item_bill = new ListViewItem(i.Text);
                        item_bill.SubItems.Add(sl.ToString());
                        item_bill.SubItems.Add(i.SubItems[2].Text);
                        item_bill.SubItems.Add(i.SubItems[1].Text);
                        item_bill.SubItems.Add(i.SubItems[3].Text);
                        lsvBill.Items.Add(item_bill);
                    }
                    Tong += int.Parse(i.SubItems[2].Text);
                    lbTongTien.Text = Tong.ToString();
                }
            }
        }
        private void Ban_Click(object sender, EventArgs e)
        {
            lsvBill.Items.Clear();
            Button btn = (Button)sender;
            soBan = int.Parse(btn.Name.Substring(6));
            lbBan.Text = "Bàn " + soBan.ToString();
            int kq = hdBus.GetMaHoaDonLonNhat();
            bool tinhTrangBan = Convert.ToBoolean(banBus.GetTinhTrangBanByIDBan(soBan)["TinhTrang"]);
            if (tinhTrangBan == false)
            {
                btnThem.Enabled = true;
                btnInPhieu.Enabled = true;
                Tong = 0;
                daRow = TableHoaDon.NewRow();
                daRow["MaHD"] = kq + 1;
                hoaDon = kq + 1;
                daRow["MaNV"] = 2;
                daRow["MaBan"] = soBan;
                daRow["ThoiGian"] = DateTime.Now;
                daRow["TinhTrang"] = false;
            }
            else
            {
                btnThem.Enabled = false;
                btnInPhieu.Enabled = false;
                DataRow r = hdBus.GetThongTinHoaDonByIDBan(soBan);
                hoaDon = Convert.ToInt32(r["MaHD"]);
                Tong = Convert.ToInt32(r["TongTien"]);

                DataTable dataTable = new HoaDonChiTiet_BUS().GetThongTinHoaDonChiTietByMaHD(hoaDon);
                foreach (DataRow dr in dataTable.Rows)
                {
                    string MaSP = dr["MaSP"].ToString();
                    DataRow row = spBus.GetSanPhamByMaSP(MaSP);
                    ListViewItem item = new ListViewItem(row["Ten"].ToString());
                    item.SubItems.Add(dr["SoLuong"].ToString());
                    item.SubItems.Add(row["GiaBan"].ToString());
                    item.SubItems.Add(row["DonVi"].ToString());
                    item.SubItems.Add(row["MaSP"].ToString());
                    lsvBill.Items.Add(item);
                }
            }
            lbTongTien.Text = Tong.ToString();
        }
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            int count = lsvBill.Items.Count;
            if (daRow != null && count > 0)
            {
                daRow["TongTien"] = Tong;
                TableHoaDon.Rows.Add(daRow);
                hdBus.SaveHoaDon(TableHoaDon);
                foreach (ListViewItem item in lsvBill.Items)
                {
                    DataRow dataRow = TableHoaDonChiTiet.NewRow();
                    dataRow["MaHD"] = hoaDon;
                    dataRow["MaSP"] = item.SubItems[4].Text;
                    dataRow["SoLuong"] = int.Parse(item.SubItems[1].Text);
                    TableHoaDonChiTiet.Rows.Add(dataRow);
                }
                try
                {
                    hdctBus.SaveHoaDonChiTiet(TableHoaDonChiTiet);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                daRow = null;
            }
        }
        private void bntGiam_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Button bt in tabPage2.Controls)
            {
                int id = int.Parse(bt.Name.Substring(6));
                tinhTrangBan = Convert.ToBoolean(banBus.GetTinhTrangBanByIDBan(id)["TinhTrang"]);
                if (tinhTrangBan == false)
                    bt.BackColor = Color.Green;
                else
                    bt.BackColor = Color.Red;
            }
        }
    }
}
