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
        public void TestDelete()
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
            sp.Del(4, tb);
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
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddProductWithMaSoAm()
        {
            DataTable tb = sp.GetTableProduct();
            SanPham sanPham = new SanPham(-1, "Gà luộc", "Con", 150000);
            sp.AddProduct(sanPham, tb);
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        

        [TestMethod]
        public void TestEdit()
        {
            DataTable tb = sp.GetTableProduct();
            SanPham sanPham = new SanPham(1, "Gà luộc", "Con", 150000);
            int index = 0;
            sp.Edit(sanPham, tb, index);

            int maSP, giaBan;
            string ten, donVi;

            maSP = int.Parse(tb.Rows[index]["MaSP"].ToString());
            giaBan = int.Parse(tb.Rows[index]["GiaBan"].ToString());
            ten = tb.Rows[index]["Ten"].ToString();
            donVi = tb.Rows[index]["DonVi"].ToString();

            Assert.AreEqual(1,maSP);
            Assert.AreEqual("Gà luộc", ten);
            Assert.AreEqual("Con", donVi);
            Assert.AreEqual(150000, giaBan);

        }

        [TestMethod]
        public void TestEditMaSPChuaTonTai()
        {
            DataTable tb = sp.GetTableProduct();
            SanPham sanPham = new SanPham(4, "Gà luộc", "Con", 150000);

            int index = 0;

            sp.Edit(sanPham, tb, index);

            int maSP, giaBan;
            string ten, donVi;

            maSP = int.Parse(tb.Rows[index]["MaSP"].ToString());
            giaBan = int.Parse(tb.Rows[index]["GiaBan"].ToString());
            ten = tb.Rows[index]["Ten"].ToString();
            donVi = tb.Rows[index]["DonVi"].ToString();

            Assert.AreEqual(1, maSP);
            Assert.AreEqual("SuShi", ten);
            Assert.AreEqual("miếng", donVi);
            Assert.AreEqual(10000, giaBan);

        }

        [TestMethod]
        public void TestEditMaSPKhongDungVoiIndex()
        {
            DataTable tb = sp.GetTableProduct();
            SanPham sanPham = new SanPham(2, "Gà luộc", "Con", 150000);

            int index = 0;

            sp.Edit(sanPham, tb, index);

            int maSP, giaBan;
            string ten, donVi;

            maSP = int.Parse(tb.Rows[index]["MaSP"].ToString());
            giaBan = int.Parse(tb.Rows[index]["GiaBan"].ToString());
            ten = tb.Rows[index]["Ten"].ToString();
            donVi = tb.Rows[index]["DonVi"].ToString();

            Assert.AreEqual(1, maSP);
            Assert.AreEqual("SuShi", ten);
            Assert.AreEqual("miếng", donVi);
            Assert.AreEqual(10000, giaBan);
        }
    }
}
