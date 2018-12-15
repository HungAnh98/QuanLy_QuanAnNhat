using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class HoaDon_DAO:Dataprovider
    {
        //done
        public DataTable GetTableHoaDon()
        {
            return GetDataSet("HoaDon").Tables[0];
        }

        public void ThemHoaDon(HoaDon hoaDon,DataTable dataTable)
        {
            foreach (DataRow r in dataTable.Rows)
            {
                if ((hoaDon.MaHD == int.Parse(r["MaHD"].ToString())) || hoaDon.MaHD < 0)
                    return;
            }
            DataRow row = dataTable.NewRow();
            row["MaHD"] = hoaDon.MaHD;
            row["MaNV"] = hoaDon.MaNV;
            row["MaBan"] = hoaDon.MaBan;
            row["TongTien"] = hoaDon.TongTien;
            row["ThoiGian"] = hoaDon.ThoiGian;
            row["TinhTrang"] = hoaDon.TinhTrang;
            dataTable.Rows.Add(row);
        }

        public void CapNhatTinhTrangHoaDon(HoaDon hoaDon, DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr["MaHD"].ToString() == hoaDon.MaHD.ToString())
                {
                    dr.SetField("TinhTrang", hoaDon.TinhTrang);
                }
            }
        }
        //done
        public void SaveHoaDon(DataTable dataTable)
        {
            Save(dataTable,"HoaDon");
        }

        public DataTable GetThongTinHoaDonByIDNhanVienTrongThang(int idNV)
        {
            try
            {
                string sql = "SELECT * FROM HoaDon WHERE MaNV = " + idNV + " AND MONTH(ThoiGian) = " + DateTime.Now.Month;
                return GetDataTable(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public DataTable GetThongTinHoaDonTrongThang()
        {
            try
            {
                string sql = "SELECT * FROM HoaDon WHERE MONTH(ThoiGian) = " + DateTime.Now.Month;
                return GetDataTable(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
