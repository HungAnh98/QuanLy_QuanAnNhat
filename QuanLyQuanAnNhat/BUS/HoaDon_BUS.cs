using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class HoaDon_BUS
    {
        public DataTable GetThongTinHoaDon()
        {
            try
            {
                return new HoaDon_DAO().GetTableHoaDon();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int GetThongTinHoaDonByIDBan(int idBan)
        {
            string condition = "MaBan = " + idBan + " AND TinhTrang = " + false;
            try
            {
                DataRow[] hoaDon = new HoaDon_DAO().GetTableHoaDon().Select(condition);
                return Convert.ToInt32(hoaDon[0]["MaHD"]);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException exx)
            {
                throw exx;
            }
        }
        public int GetMaHoaDonLonNhat()
        {
            DataTable da = new HoaDon_DAO().GetTableHoaDon();
            int index = da.Rows.Count - 1;
            int kq = Convert.ToInt32(da.Rows[index]["MaHD"]);
            return kq;
        }

    }
}
