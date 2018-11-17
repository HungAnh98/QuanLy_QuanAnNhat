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
    public class SanPham_DAO:Dataprovider
    {
        public DataTable GetTableProduct()
        {       
            return GetDataSet("SanPham").Tables[0];
        }
    }
}
