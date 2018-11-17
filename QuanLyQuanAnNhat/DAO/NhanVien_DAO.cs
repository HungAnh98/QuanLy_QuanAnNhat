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

        public void EditEm(NhanVien nv, DataTable dt, int index)
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
