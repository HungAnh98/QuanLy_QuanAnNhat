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
            return GetDataSet("Ban").Tables[0];
        }
        public void CapNhatTinhTrangBan(Ban ban, DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr["MaBan"].ToString() == ban.MaBan.ToString())
                {
                    dr.SetField("TinhTrang", ban.TinhTrang);
                }
            }
        }
        public void SaveBan(DataTable dataTable)
        {
            Save(dataTable, "Ban");
        }
    }
}
