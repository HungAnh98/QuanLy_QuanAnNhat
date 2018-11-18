using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class Account_BUS
    {
        public bool login(Account acc)
        {
            try
            {
                return new Account_DAO().CheckInfor(acc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable GetTableAccount()
        {
            return new Account_DAO().GetTableAccount();
        }
        public DataRow GetThongTinAccountByUserName(string userName)
        {
            string condition = "UserName = '" + userName +"'";
            try
            {
                DataRow[] hoaDon = new Account_DAO().GetTableAccount().Select(condition);
                return hoaDon[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
