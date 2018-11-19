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
        // done testing
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

        // done testing
        public void AddProduct(SanPham sp, DataTable tb)
        {
            foreach (DataRow r in tb.Rows)
            {
                if ((sp.MaSP == int.Parse(r["MaSP"].ToString())) || sp.MaSP < 0)
                    return;
            }
                DataRow row = tb.NewRow();
                row["MaSP"] = sp.MaSP;
                row["Ten"] = sp.Ten;
                row["DonVi"] = sp.DonVi;
                row["GiaBan"] = sp.GiaBan;
                tb.Rows.Add(row);

        }

        //done testing
        public void Del(int row, DataTable dt)
        {
            if (row >= 0 && row <= dt.Rows.Count)
            {
                dt.Rows[row].Delete();
                Save(dt, "SanPham");
            }
        }

        //done
        public void Edit(SanPham sp, DataTable dt, int index)
        {
            if (index >= 0 && index < dt.Rows.Count)
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
}