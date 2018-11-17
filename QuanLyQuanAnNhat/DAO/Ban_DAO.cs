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
    public class Ban_DAO:Dataprovider
    {
        public DataTable GetTableBan()
        {
            string sql = "SELECT * FROM Ban";
            return GetDataSet(sql, "Ban").Tables[0];
        }
    }
}
