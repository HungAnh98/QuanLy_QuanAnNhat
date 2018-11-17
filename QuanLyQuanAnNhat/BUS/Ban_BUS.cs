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
    public class Ban_BUS
    {
        public DataTable GetTableBan()
        {
            return new Ban_DAO().GetTableBan();
        }
        public DataRow GetTinhTrangBanByIDBan(int idBan)
        {
            string condition = "MaBan = " + idBan;
            try
            {
                DataRow[] hoaDon = new Ban_DAO().GetTableBan().Select(condition);
                return hoaDon[0];
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
    }
}
