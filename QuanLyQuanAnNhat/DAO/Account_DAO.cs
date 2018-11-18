using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class Account_DAO : Dataprovider
    {
        public bool CheckInfor(Account account)
        {
            string sql = "SELECT COUNT(UserName) FROM Account WHERE UserName = '" + account.UserName + "' AND Password = '" + account.Password + "'";
            int number;
            try
            {
                number = MyExecuteScalar(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            if (number > 0)
                return true;
            else
                return false;
        }

        public DataTable GetTableAccount()
        {
            return GetDataSet("Account").Tables[0];
        }

    }
}
