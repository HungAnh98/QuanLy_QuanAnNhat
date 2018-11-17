using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class NhanVien_DAO : Dataprovider
    {
        public DataTable getEmployeeTable()
        {
            try
            {
                //string sql = "";
                return GetDataSet("NhanVien").Tables[0];
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
