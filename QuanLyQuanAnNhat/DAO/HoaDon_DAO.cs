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
        public DataTable GetTableHoaDon()
        {
            string sql = "SELECT * FROM HoaDon";
            return GetDataSet(sql, "HoaDon").Tables[0];
        }
    }
}
