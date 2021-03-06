﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class HoaDonChiTiet_DAO:Dataprovider
    {

        /// <summary>
        /// Lấy tất cả các hàng của bảng hóa đơn chi tiết
        /// </summary>
        /// 
        public DataTable GetTableHoaDonChiTiet()
        {
           
            return GetDataSet( "HoaDonChiTiet").Tables[0];
        }

        /// <summary>
        /// Lấy tất cả các hàng của bảng hóa đơn chi tiết theo mả hóa đơn
        /// </summary>
        /// <param name="MaHD"></param>
        /// <returns></returns>
        public DataTable GetTableHoaDonChiTietByMaHD(int MaHD)
        {
            string sql = "SELECT * FROM HoaDonChiTiet WHERE MaHD = " + MaHD;
            return GetDataTable(sql);
        }

        public void SaveHoaDonChiTiet(DataTable dataTable)
        {
            try
            {
                Save(dataTable, "HoaDonChiTiet");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ThemHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet, DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row["MaHD"] = hoaDonChiTiet.MaHD;
            row["MaSP"] = hoaDonChiTiet.MaSP;
            row["SoLuong"] = hoaDonChiTiet.SoLuong;
            dataTable.Rows.Add(row);
        }

    }
}
