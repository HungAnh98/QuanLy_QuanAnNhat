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
    public class SanPham_DAO : Dataprovider
    {
        // possible
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

        // possible
        public void AddProduct(SanPham sp, DataTable tb)
        {
            DataRow row = tb.NewRow();
            row["MaSP"] = sp.MaSP;
            row["Ten"] = sp.Ten;
            row["DonVi"] = sp.DonVi;
            row["GiaBan"] = sp.GiaBan;
            tb.Rows.Add(row);
        }


        public void Del(int row, DataTable dt)
        {
            dt.Rows[row].Delete();
        }
        public void Edit(SanPham sp, DataTable dt, int index)
        {
            if (dt.Rows[index]["MaSP"].ToString() == sp.MaSP.ToString())
            {
                dt.Rows[index].SetField("Ten", sp.Ten.ToString());
                dt.Rows[index].SetField("DonVi", sp.DonVi.ToString());
                dt.Rows[index].SetField("GiaBan", sp.GiaBan.ToString());
            }
        }
    }
}