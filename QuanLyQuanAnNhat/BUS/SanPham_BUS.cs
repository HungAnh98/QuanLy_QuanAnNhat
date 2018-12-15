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
        SanPham_DAO product = new SanPham_DAO();
      
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

        public DataRow GetSanPhamByMaSP(int MaSP)
        {
            string condition = "MaSP = " + MaSP;
            DataRow[] dataRows = new SanPham_DAO().GetTableProduct().Select(condition);
            return dataRows[0];
        }


        public void AddProduct_Bus(SanPham sp, DataTable dt)
        {
            new SanPham_DAO().AddProduct(sp, dt);
        }

        public int DelProduct_Bus(int row, DataTable dt)
        {
            try
            {

                int number = product.Del(row, dt);
                if (number > 0)
                    return number;
                else return -1;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void Edit_Bus(SanPham sp, DataTable dt, int index)
        {
            product.Edit(sp, dt, index);
        }

        public void Save_Bus(DataTable dt)
        {
            try
            {
                product.Save(dt, "SanPham");
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }
}
