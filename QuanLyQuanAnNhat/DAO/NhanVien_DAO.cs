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
        //done
        public DataTable getEmployeeTable()
        {
            try
            {
                return GetDataSet("NhanVien").Tables[0];
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //done
        public void addEml(NhanVien nv, DataTable tb)
        {
            foreach (DataRow r in tb.Rows)
            {
                if ((nv.MaNV == int.Parse(r["MaNV"].ToString())) || nv.MaNV < 0)
                    return;
            }
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

        //done
        public int Del(int row, DataTable dt)
        {
            //if (row >= 0 && row <= dt.Rows.Count)
            ////{
            ////    dt.Rows[row].Delete();
            ////    Save(dt, "NhanVien");
            //}
            string manv = dt.Rows[row][0].ToString();
            string sql = "DELETE FROM NhanVien WHERE NhanVien.MaNV ='" + manv + "'";
            try
            {

                int number = MyExecuteNonQuery(sql);
                if (number > 0)
                    return number;
                else return -1;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        //done
        public void EditEm(NhanVien nv, DataTable dt, int index)
        {
            if (index >= 0 && index < dt.Rows.Count)
            {
                if (dt.Rows[index]["MaNV"].ToString() == nv.MaNV.ToString())
                {
                    dt.Rows[index].SetField("Ten", nv.Ten.ToString());
                    dt.Rows[index].SetField("GioiTinh", nv.GioiTinh.ToString());
                    dt.Rows[index].SetField("NgaySinh", nv.NgaySinh.ToString());
                    dt.Rows[index].SetField("ChucVu", nv.ChucVu.ToString());
                    dt.Rows[index].SetField("Luong", nv.Luong.ToString());
                    dt.Rows[index].SetField("SDT", nv.Sdt.ToString());
                    dt.Rows[index].SetField("DiaChi", nv.DiaChi.ToString());
                }
            }
        }
    }
}
