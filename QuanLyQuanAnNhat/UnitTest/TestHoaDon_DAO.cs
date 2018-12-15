using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace UnitTest
{
    [TestClass]
    public class TestHoaDon_DAO
    {
        HoaDon_DAO hdd = new HoaDon_DAO();
        [TestMethod]
        public void TestGetTable()
        {
            DataTable tb = hdd.GetTableHoaDon();
            int expected = 9;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddHoaDon()
        {
            DataTable tb = hdd.GetTableHoaDon();
            HoaDon hd = new HoaDon(10, 3, 5, 0, DateTime.Now, false);
            hdd.ThemHoaDon(hd, tb);
            int expected =  10;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddHoaDonWithDuplicateID()
        {
            DataTable tb = hdd.GetTableHoaDon();
            HoaDon hd = new HoaDon(9, 3, 5, 0, DateTime.Now, false);
            hdd.ThemHoaDon(hd, tb);
            int expected = 9;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddHoaDonWithIDAm()
        {
            DataTable tb = hdd.GetTableHoaDon();
            HoaDon hd = new HoaDon(-1, 3, 5, 0, DateTime.Now, false);
            hdd.ThemHoaDon(hd, tb);
            int expected = 9;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        //public void CapNhatTinhTrangHoaDon(HoaDon hoaDon, DataTable dataTable)

        [TestMethod]
        public void TestCapNhatTinhTrangHoaDon()
        {
            DataTable tb = hdd.GetTableHoaDon();
            HoaDon hd = new HoaDon(3, 3, 5, 0, DateTime.Now, true);
            hdd.CapNhatTinhTrangHoaDon(hd, tb);
            bool actual = Convert.ToBoolean(tb.Rows[2]["TinhTrang"]);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //public void TestCapNhatTinhTrangHoaDon()
        //{
        //    DataTable tb = hdd.GetTableHoaDon();
        //    HoaDon hd = new HoaDon(3, 3, 5, 0, DateTime.Now, true);
        //    hdd.CapNhatTinhTrangHoaDon(hd, tb);
        //    bool actual = Convert.ToBoolean(tb.Rows[2]["TinhTrang"]);
        //    bool expected = true;
        //    Assert.AreEqual(expected, actual);
        //}

    }
}
