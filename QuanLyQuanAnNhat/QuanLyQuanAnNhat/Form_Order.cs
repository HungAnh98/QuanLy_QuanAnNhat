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
    public partial class Form_Order : Form
    {

        HoaDon_BUS hdBus = new HoaDon_BUS();
        Ban_BUS banBus = new Ban_BUS();
        HoaDonChiTiet_BUS hdctBus = new HoaDonChiTiet_BUS();
        SanPham_BUS spBus = new SanPham_BUS();

        DataTable TableHoaDon = new HoaDon_BUS().GetThongTinHoaDon();
        DataTable TableHoaDonChiTiet = new HoaDonChiTiet_BUS().GetThongTinHoaDonChiTiet();
        DataTable TableBan = new Ban_BUS().GetTableBan();
        DataTable daTableMenu;

        HoaDon E_hoaDon;
        HoaDonChiTiet E_hoaDonChiTiet;
        Ban E_Ban;


        int soBan = 0;
        int hoaDon = -1;
        int MaNV;
        int Tong;
        bool tinhTrangBan;
        bool alow = false;


        public Form_Order(int maNV)
        {
            InitializeComponent();
            MaNV = maNV;
        }
        private void Form_Order_Load(object sender, EventArgs e)
        {
            
            daTableMenu = spBus.GetThongTinMenu();
            foreach (DataRow row in daTableMenu.Rows)
            {
                ListViewItem item = new ListViewItem(row["Ten"].ToString());
                item.SubItems.Add(row["DonVi"].ToString());
                item.SubItems.Add(row["GiaBan"].ToString());
                item.SubItems.Add(row["MaSP"].ToString());
                lstMenu.Items.Add(item);
            }
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
        private void btnGiam_Click(object sender, EventArgs e)
        { 
            foreach (ListViewItem it in lsvBill.Items)
            {
                if(it.Selected == true)
                {
                    int tien = int.Parse(it.SubItems[2].Text);
                    int soLuong = int.Parse(it.SubItems[1].Text);
                    if (soLuong > 1)
                    {
                        soLuong--;                      
                        it.SubItems[1].Text = soLuong.ToString();
                    }
                    else
                    {
                        lsvBill.Items.Remove(it);
                    }
                    Tong -= tien;
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
            tinhTrangBan = Convert.ToBoolean(banBus.GetTinhTrangBanByIDBan(soBan)["TinhTrang"]);
            if (tinhTrangBan == false)
            {
                btnThem.Enabled = true;
                btnInPhieu.Enabled = true;
                btnGiam.Enabled = true;
                btnThanhToan.Enabled = false;
                Tong = 0;
                alow = true;
                hoaDon = kq + 1;
            }
            else
            {
                btnThem.Enabled = false;
                btnGiam.Enabled = false;
                btnInPhieu.Enabled = false;
                btnThanhToan.Enabled = true;
                alow = false;
                DataRow r = hdBus.GetThongTinHoaDonByIDBan(soBan);
                hoaDon = Convert.ToInt32(r["MaHD"]);
                Tong = Convert.ToInt32(r["TongTien"]);
                DataTable dataTable = new HoaDonChiTiet_BUS().GetThongTinHoaDonChiTietByMaHD(hoaDon);
                foreach (DataRow dr in dataTable.Rows)
                {
                    int MaSP = int.Parse(dr["MaSP"].ToString());
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
            if (alow == true && count > 0)
            {
                E_hoaDon = new HoaDon(hoaDon, MaNV, soBan, Tong, DateTime.Now, false);
                hdBus.ThemHoaDon(E_hoaDon, TableHoaDon);
                hdBus.SaveHoaDon(TableHoaDon);
                foreach (ListViewItem item in lsvBill.Items)
                {
                    string maSP = item.SubItems[4].Text;
                    int soLuong = int.Parse(item.SubItems[1].Text);
                    E_hoaDonChiTiet = new HoaDonChiTiet(hoaDon, maSP, soLuong);
                    hdctBus.ThemHoaDonChiTiet(E_hoaDonChiTiet, TableHoaDonChiTiet);
                }
                hdctBus.SaveHoaDonChiTiet(TableHoaDonChiTiet);

                E_Ban = new Ban(soBan, true);
                banBus.CapNhatTinhTrangBan(E_Ban, TableBan);
                banBus.SaveBan(TableBan);
                btnInPhieu.Enabled = false;
                btnThem.Enabled = false;
                btnGiam.Enabled = false;
                btnThanhToan.Enabled = true;
                alow = false;
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (soBan != 0)
            {
                tinhTrangBan = Convert.ToBoolean(banBus.GetTinhTrangBanByIDBan(soBan)["TinhTrang"]);
                if (tinhTrangBan == true)
                {
                    E_hoaDon = new HoaDon(hoaDon, MaNV, soBan, Tong, DateTime.Now, true);
                    hdBus.CapNhatTinhTrangHoaDon(E_hoaDon, TableHoaDon);
                    hdBus.SaveHoaDon(TableHoaDon);

                    E_Ban = new Ban(soBan, false);
                    banBus.CapNhatTinhTrangBan(E_Ban, TableBan);
                    banBus.SaveBan(TableBan);

                    lsvBill.Items.Clear();
                }
            }
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
        private void Form_Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool completed = true;
            foreach (Button bt in tabPage2.Controls)
            {
                int id = int.Parse(bt.Name.Substring(6));
                tinhTrangBan = Convert.ToBoolean(banBus.GetTinhTrangBanByIDBan(id)["TinhTrang"]);
                if (tinhTrangBan == true)
                    completed = false;
            }
            if (completed == false)
            {
                MessageBox.Show("Có hóa đơn chưa được thanh toán", "Thông báo", MessageBoxButtons.OK);
                e.Cancel = true;
            }
        }
    }
}
