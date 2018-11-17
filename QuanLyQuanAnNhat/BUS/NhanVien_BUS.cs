using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class NhanVien_BUS
    {
        NhanVien_DAO em = new NhanVien_DAO();
        public DataTable getEmployeeTable()
        {
            try
            {

                //em = new NhanVien_DAO();
                return em.getEmployeeTable();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void AddEmp(NhanVien nv, DataTable dt)
        {


            em.addEml(nv, dt);



        }

        public void Del(int row, DataTable dt)
        {

            em.Del(row, dt);
        }
    }
}
