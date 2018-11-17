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
            try
            {
                return GetDataSet("SanPham").Tables[0];
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void addProduct(SanPham sp, DataTable tb)
        {
            DataRow row = tb.NewRow();
            row["MaSP"] = sp.MaSP;
            row["Ten"] = sp.Ten;
            row["DonVi"] = sp.DonVi;
            row["GiaBan"] = sp.GiaBan;
            tb.Rows.Add(row);

        }


    }
}
