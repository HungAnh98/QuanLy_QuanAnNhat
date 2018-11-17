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
    public class HoaDonChiTiet_BUS
    {
        public DataTable GetThongTinHoaDonChiTiet()
        {
            try
            {
                return new HoaDonChiTiet_DAO().GetTableHoaDonChiTiet();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable GetThongTinHoaDonChiTietByMaHD(int MaHD)
        {
            try
            {
                return new HoaDonChiTiet_DAO().GetTableHoaDonChiTietByMaHD(MaHD);
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
        public void SaveHoaDonChiTiet(DataTable dataTable)
        {
            HoaDonChiTiet_DAO hoaDon_DAO = new HoaDonChiTiet_DAO();
            try
            {
                hoaDon_DAO.SaveHoaDonChiTiet(dataTable);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
