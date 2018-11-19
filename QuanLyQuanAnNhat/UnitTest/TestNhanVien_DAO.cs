using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace UnitTest
{
    [TestClass]
    public class TestNhanVien_DAO
    {
        NhanVien_DAO nvd = new NhanVien_DAO();

        [TestMethod]
        public void TestGetTable()
        {
            DataTable tb = nvd.getEmployeeTable();
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddEmpl()
        {
            DataTable tb = nvd.getEmployeeTable();
            NhanVien nv = new NhanVien(4, "Châu", "Nữ", new DateTime(1998, 5, 1), "NV", 3000000, 016789025, "");
            nvd.addEml(nv, tb);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddEmplWithDuplicateID()
        {
            DataTable tb = nvd.getEmployeeTable();
            NhanVien nv = new NhanVien(2, "Châu", "Nữ", new DateTime(1998, 5, 1), "NV", 3000000, 016789025, "");
            nvd.addEml(nv, tb);
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddProductWithMaSoAm()
        {
            DataTable tb = nvd.getEmployeeTable();
            NhanVien nv = new NhanVien(-2, "Châu", "Nữ", new DateTime(1998, 5, 1), "NV", 3000000, 016789025, "");
            nvd.addEml(nv, tb);
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestDelete()
        {
            DataTable tb = nvd.getEmployeeTable();
            int row = 2;
            nvd.Del(row, tb);
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteWithRowAm()
        {
            DataTable tb = nvd.getEmployeeTable();
            int row = -2;
            nvd.Del(row, tb);
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteWithRowLon()
        {
            DataTable tb = nvd.getEmployeeTable();
            int row = 3;
            nvd.Del(row, tb);
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEdit()
        {
            DataTable tb = nvd.getEmployeeTable();
            NhanVien nv = new NhanVien(1, "Nguyễn Hùng Anh", "Nam", new DateTime(1998, 5, 7), "NV", 6000000, 01677900172, "371 NK");
            int index = 0;
            nvd.EditEm(nv, tb, index);

            string ten, gioiTinh, chucVu;
            int maNV, luong;

            maNV = int.Parse(tb.Rows[index]["MaNV"].ToString());
            luong = int.Parse(tb.Rows[index]["Luong"].ToString());
            ten = tb.Rows[index]["Ten"].ToString();
            gioiTinh = tb.Rows[index]["GioiTinh"].ToString();
            chucVu = tb.Rows[index]["ChucVu"].ToString();

            Assert.AreEqual(nv.MaNV, maNV);
            Assert.AreEqual(nv.Ten, ten);
            Assert.AreEqual(nv.GioiTinh, gioiTinh);
            Assert.AreEqual(nv.Luong, luong);
            Assert.AreEqual(nv.ChucVu, chucVu);

        }

        [TestMethod]
        public void TestEditMaSPChuaTonTai()
        {
            DataTable tb = nvd.getEmployeeTable();
            NhanVien nv = new NhanVien(4, "Nguyễn Hùng Anh", "Nam", new DateTime(1998, 5, 7), "NV", 6000000, 01677900172, "371 NK");
            int index = 0;
            nvd.EditEm(nv, tb, index);

            string ten, gioiTinh, chucVu;
            int maNV, luong;

            maNV = int.Parse(tb.Rows[index]["MaNV"].ToString());
            luong = int.Parse(tb.Rows[index]["Luong"].ToString());
            ten = tb.Rows[index]["Ten"].ToString();
            gioiTinh = tb.Rows[index]["GioiTinh"].ToString().Trim();
            chucVu = tb.Rows[index]["ChucVu"].ToString();

            Assert.AreEqual(1, maNV);
            Assert.AreEqual(nv.Ten, ten);
            Assert.AreEqual(nv.GioiTinh, gioiTinh);
            Assert.AreEqual(4500000, luong);
            Assert.AreEqual(nv.ChucVu, chucVu);
        }

        [TestMethod]
        public void TestEditMaSPKhongDungVoiIndex()
        {
            DataTable tb = nvd.getEmployeeTable();
            NhanVien nv = new NhanVien(2, "Nguyễn Hùng Anh", "Nam", new DateTime(1998, 5, 7), "NV", 6000000, 01677900172, "371 NK");
            int index = 0;
            nvd.EditEm(nv, tb, index);

            string ten, gioiTinh, chucVu;
            int maNV, luong;

            maNV = int.Parse(tb.Rows[index]["MaNV"].ToString());
            luong = int.Parse(tb.Rows[index]["Luong"].ToString());
            ten = tb.Rows[index]["Ten"].ToString();
            gioiTinh = tb.Rows[index]["GioiTinh"].ToString().Trim();
            chucVu = tb.Rows[index]["ChucVu"].ToString();

            Assert.AreEqual(1, maNV);
            Assert.AreEqual(nv.Ten, ten);
            Assert.AreEqual(nv.GioiTinh, gioiTinh);
            Assert.AreEqual(4500000, luong);
            Assert.AreEqual(nv.ChucVu, chucVu);

        }
    }
}
