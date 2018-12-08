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

        public int Del(int row, DataTable dt)
        {
            try
            {

                int number = em.Del(row, dt);
                if (number > 0)
                    return number;
                else
                    return -1;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void editEm(NhanVien nv, DataTable dt, int index)
        {
            em.EditEm(nv, dt, index);
        }
        public void Save(DataTable dt, string tenBang)
        {
            try
            {
                em.Save(dt, tenBang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataRow GetThongTinNhanVienByID(int MaNV)
        {
            string condition = "MaNV = " + MaNV;
            try
            {
                DataRow[] hoaDon = new NhanVien_DAO().getEmployeeTable().Select(condition);
                return hoaDon[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
