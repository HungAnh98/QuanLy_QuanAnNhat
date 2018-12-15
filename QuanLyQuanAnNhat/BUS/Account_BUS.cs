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
        public bool Login(Account acc)
        {
            DataTable dt = GetTableAccount();

            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString().ToLower() == acc.UserName.ToLower() && row[1].ToString() == acc.Password)
                {
                    return true;
                }
            }
            return false;
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
