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
    public class Dataprovider
    {
        SqlConnection con;
        public Dataprovider()
        {
            string cnStr = "Server = .; Database = Quan_an ; Integrated security = true ";
            con = new SqlConnection(cnStr);
        }
        /// <summary>
        /// Connecting database
        /// </summary>
        public void Connect()
        {
            if (con != null && con.State == ConnectionState.Closed)
                try
                {
                    con.Open();
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
        }
        /// <summary>
        /// Disconnecting database
        /// </summary>
        public void Disconnect()
        {
            if (con != null && con.State == ConnectionState.Open)
                try
                {
                    con.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
        }
        public int MyExecuteScalar(string sql)
        {
            Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            try
            {
                int number = (int)cmd.ExecuteScalar();
                return number;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public int MyExecuteNonQuery(string sql)
        {

            Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            try
            {
                int number = cmd.ExecuteNonQuery();
                return number;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public SqlDataReader GetTable(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public DataSet GetDataSet(string sql, string tenBang)
        {
            DataSet ds = new DataSet();
            sql = "SELECT * FROM " + tenBang;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;
        }
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }

        public SqlDataAdapter initDa(string tenBang)
        {
            DataSet Ds = new DataSet();
            string sql = "SELECT * FROM " + tenBang;
            SqlDataAdapter Da = new SqlDataAdapter(sql, con);
            return Da;
        }

        public void Save(DataTable dt, string tenBang)
        {
            // Dataprovider dp = new Dataprovider();
            SqlDataAdapter Da = initDa(tenBang);
            SqlCommandBuilder bd = new SqlCommandBuilder(Da);
            try
            {

                Da.Update(dt);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
