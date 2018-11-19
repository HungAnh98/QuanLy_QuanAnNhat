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
            int expected = 14;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

      
    }
}
