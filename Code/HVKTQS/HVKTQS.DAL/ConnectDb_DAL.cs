using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.DAL
{
    public class ConnectDb_DAL
    {
        public bool CurrentConnectDb()
        {
            bool status = false;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        status = true;
                    }
                }
                return status;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool TestConnectDb(string connectionString)
        {
            bool status = false;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        status = true;
                    }
                }
                return status;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataTable GetDatabase(string connectionString)
        {
            const string queryString = "SELECT * FROM master.dbo.sysdatabases where [dbid] > 4";
            SqlConnection conn = null;
            SqlCommand myCommand = new SqlCommand();
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                myCommand.Connection = conn;
                myCommand.CommandText = queryString;
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(dt);
                return dt;
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                myAdapter.Dispose();
                myCommand.Dispose();
            }
        }
    }
}