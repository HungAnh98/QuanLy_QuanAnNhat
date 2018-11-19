using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using System.Data;
using System.Data.SqlClient;
using DTO;
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
            sp.Del(3, tb);
            int expected = 3;
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

        [TestMethod]
        public void TestAddProduct()
        {
            DataTable tb = sp.GetTableProduct();
            SanPham sanPham = new SanPham(5, "Gà luộc", "Con", 150000);
            sp.AddProduct(sanPham, tb);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddProductWithDuplicated()
        {
            DataTable tb = sp.GetTableProduct();
            SanPham sanPham = new SanPham(3, "Gà luộc", "Con", 150000);
            sp.AddProduct(sanPham, tb);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
