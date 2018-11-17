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

        public void addEml(NhanVien nv, DataTable tb)
        {



            DataRow row = tb.NewRow();
            row["MaNV"] = nv.MaNV;
            row["Ten"] = nv.Ten;
            row["GioiTinh"] = nv.GioiTinh;
            row["NgaySinh"] = nv.NgaySinh;
            row["ChucVu"] = nv.ChucVu;
            row["Luong"] = nv.Luong;
            row["SDT"] = nv.Sdt;
            row["DiaChi"] = nv.DiaChi;
            tb.Rows.Add(row);




        }

        public void Del(int row, DataTable dt)
        {

            dt.Rows[row].Delete();
        }
    }
}
