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
    public class SanPham_BUS
    {
        public DataTable GetThongTinMenu()
        {
            try
            {
                return new SanPham_DAO().GetTableProduct();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataRow GetSanPhamByMaSP(string MaSP)
        {
            string condition = "MaSP = '" + MaSP+"'";
            DataRow[] dataRows = new SanPham_DAO().GetTableProduct().Select(condition);
            return dataRows[0];
        }


        public void addProduct_Bus(SanPham sp, DataTable dt)
        {
            new SanPham_DAO().addProduct(sp, dt);
        }

    }
}
