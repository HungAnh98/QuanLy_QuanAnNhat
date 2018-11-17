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
        public DataRow GetThongTinHoaDonByIDBan(int idBan)
        {
            string condition = "MaBan = " + idBan ;
            try
            {
                DataRow[] hoaDon = new HoaDon_DAO().GetTableHoaDon().Select(condition);
                return hoaDon[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int GetMaHoaDonLonNhat()
        {
            DataTable da = new HoaDon_DAO().GetTableHoaDon();
            int index;
            if (da.Rows.Count > 0)
            {
                index = da.Rows.Count - 1;
                return Convert.ToInt32(da.Rows[index]["MaHD"]);
            }
            else
                return 0;          
        }
        public void SaveHoaDon(DataTable dataTable)
        {
            HoaDon_DAO hoaDon_DAO = new HoaDon_DAO();
            hoaDon_DAO.SaveHoaDon(dataTable);
        }

    }
}
