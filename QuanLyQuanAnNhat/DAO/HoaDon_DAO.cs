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
            return GetDataSet("HoaDon").Tables[0];
        }
        public void SaveHoaDon(DataTable dataTable)
        {
            Save(dataTable,"HoaDon");
        }
    }
}
