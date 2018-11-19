using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using System.Data;
using System.Data.SqlClient;
namespace UnitTest
{
    [TestClass]
    public class TestSanPham_DAO
    {
        SanPham_DAO sp = new SanPham_DAO();
        [TestMethod]
        public void TestGetTable()
        {
            DataTable tb = sp.GetTableProduct();
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDeleteWithRowAm()
        {
            DataTable tb = sp.GetTableProduct();
            sp.Del(-1, tb);
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDeleteWithRowDung()
        {
            DataTable tb = sp.GetTableProduct();
            sp.Del(1, tb);
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDeleteWithRowLon()
        {
            DataTable tb = sp.GetTableProduct();
            sp.Del(7, tb);
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

    }
}
