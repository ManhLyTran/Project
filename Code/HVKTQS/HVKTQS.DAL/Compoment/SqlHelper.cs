using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HVKTQS.DAL
{
    //protected
    public class SqlHelper
    {
        /// <summary>
        ///  Phương thức mở kết nối tới cơ sở dữ liệu
        /// </summary>
        /// <returns></returns>
        private static SqlConnection openConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
                return conn;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Không thể kết nối đến cơ sở dữ liệu" + e.Message);
            }
        }

        /// <summary>
        /// Đóng kết nối cơ sở dữ liệu
        /// </summary>
        /// <param name="conn"></param>
        private static void closeConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        /// <summary>
        /// Excute DataReader
        /// </summary>
        /// <param name="procedureName">Procedure Name</param>
        /// <param name="parameterValues">Vaulue list</param>
        /// <returns>Return type SqlDataReader</returns>
        /// <remarks></remarks>
        public static DataTable ExecuteReader(string procedureName, params object[] parameterValues)
        {
            SqlConnection conn = openConnection();
            SqlCommand myCommand = new SqlCommand();
            SqlDataReader myReader = null;
            DataTable dt = new DataTable();
            try
            {
                if (parameterValues != null && parameterValues.Length > 0)
                {
                    SqlParameter[] sqlParameter = new SqlParameter[parameterValues.Length];
                    AssignParameterValues(procedureName, sqlParameter, parameterValues);
                    myCommand.Parameters.AddRange(sqlParameter);
                }
                myCommand.Connection = conn;
                myCommand.CommandText = procedureName;
                myCommand.CommandType = CommandType.StoredProcedure;
                myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
                return dt;
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message);
            }
            finally
            {
                closeConnection(conn);
                if (myReader != null)
                    myReader.Close();
                if (myCommand != null)
                    myCommand.Dispose();
            }
        }

        /// <summary>
        /// Get sigle object from procedure
        /// </summary>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="parameterValues">Values list</param>
        /// <returns>Return sigle value with type is object</returns>
        /// <remarks></remarks>
        public static object ExecuteScalar(string procedureName, params object[] parameterValues)
        {
            SqlConnection conn = openConnection();
            SqlCommand myCommand = new SqlCommand();
            try
            {
                if (parameterValues != null && parameterValues.Length > 0)
                {
                    SqlParameter[] sqlParameter = new SqlParameter[parameterValues.Length];
                    AssignParameterValues(procedureName, sqlParameter, parameterValues);
                    myCommand.Parameters.AddRange(sqlParameter);
                }
                myCommand.Connection = conn;
                myCommand.CommandText = procedureName;
                myCommand.CommandType = CommandType.StoredProcedure;
                return myCommand.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message);
            }
            finally
            {
                closeConnection(conn);
                if (myCommand != null)
                    myCommand.Dispose();
            }
        }

        /// <summary>
        /// hàm thực thi thủ tục
        /// </summary>
        /// <param name="procedureName">Tên thủ tục</param>
        /// <param name="parameterValues">Values list</param>
        /// <returns>Return type ResultExcute</returns>
        /// <remarks></remarks>
        public static int ExecuteNoneQuery(string procedureName, params object[] parameterValues)
        {
            SqlConnection conn = openConnection();
            SqlCommand myCommand = new SqlCommand();
            try
            {
                if (parameterValues != null && parameterValues.Length > 0)
                {
                    SqlParameter[] sqlParameter = new SqlParameter[parameterValues.Length];
                    AssignParameterValues(procedureName, sqlParameter, parameterValues);
                    myCommand.Parameters.AddRange(sqlParameter);
                }
                myCommand.Connection = openConnection();
                myCommand.CommandText = procedureName;
                myCommand.CommandType = CommandType.StoredProcedure;
                return myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message);
            }
            finally
            {
                closeConnection(conn);
                if (myCommand != null)
                    myCommand.Dispose();
            }
        }

        /// <summary>
        /// Hàm này dùng để map các tham số
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="sqlParameter"></param>
        /// <param name="parameterValues"></param>
        private static void AssignParameterValues(string procedureName, SqlParameter[] sqlParameter, params object[] parameterValues)
        {
            if (String.IsNullOrEmpty(procedureName) == true)
            {
                throw new ArgumentException("Bạn chưa điền tên procedure");
            }
            if (parameterValues != null && parameterValues.Length > 0)
            {
                DataTable dtProcedureInfo = GetProcedureInfo(procedureName);
                if (dtProcedureInfo.Rows.Count == 0)
                {
                    throw new ArgumentException("Không tìm thấy procedure");
                }
                if (dtProcedureInfo.Rows.Count != parameterValues.Length)
                {
                    throw new ArgumentException("Không thể map các đối tượng");
                }
                for (int i = 0; i <= dtProcedureInfo.Rows.Count - 1; i++)
                {
                    sqlParameter[i] = new SqlParameter(dtProcedureInfo.Rows[i]["PARAMETER_NAME"].ToString(), Null.GetNull(parameterValues[i], DBNull.Value));
                    if (dtProcedureInfo.Rows[i]["DATA_TYPE"].ToString().Equals("image") == true)
                    {
                        sqlParameter[i].SqlDbType = SqlDbType.Image;
                    }
                }
            }
        }

        /// <summary>
        /// hàm thực thi chuỗi câu lệnh truy vấn
        /// </summary>
        /// <param name="queryString"> Chuỗi câu lệnh quy vấn</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string queryString)
        {
            SqlConnection conn = openConnection();
            SqlCommand myCommand = new SqlCommand();
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
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
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string procedureName, DataTable dt)
        {
            object objObject = new object();
            DataTable dtProcedureInfo = GetProcedureInfo(procedureName);
            object[] parameterValues = new object[dtProcedureInfo.Rows.Count];
            string fieldName = "";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                parameterValues = new object[dtProcedureInfo.Rows.Count];
                //Khởi tạo lại giá trị cho mảng
                for (int j = 0; j <= dtProcedureInfo.Rows.Count - 1; j++)
                {
                    fieldName = dtProcedureInfo.Rows[j]["PARAMETER_NAME"].ToString();
                    fieldName = fieldName.Replace("@", "");
                    parameterValues.SetValue(dt.Rows[i][fieldName], j);
                }
                //Thực thi Procedure
                objObject = ExecuteScalar(procedureName, parameterValues);
            }
            return objObject;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int ExecuteNoneQuery(string procedureName, DataTable dt)
        {
            int resultExec = new int();
            DataTable dtProcedureInfo = GetProcedureInfo(procedureName);
            object[] parameterValues = new object[dtProcedureInfo.Rows.Count];
            string fieldName = "";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                parameterValues = new object[dtProcedureInfo.Rows.Count];
                //Khởi tạo lại giá trị cho mảng
                for (int j = 0; j <= dtProcedureInfo.Rows.Count - 1; j++)
                {
                    fieldName = dtProcedureInfo.Rows[j]["PARAMETER_NAME"].ToString();
                    fieldName = fieldName.Replace("@", "");
                    parameterValues.SetValue(dt.Rows[i][fieldName], j);
                }
                //Thực thi Procedure
                return ExecuteNoneQuery(procedureName, parameterValues);
            }
            return resultExec;
        }

        /// <summary>
        /// Phương thức lấy thông tin của Procedure
        /// </summary>
        /// <param name="spName">Tên Procedure</param>
        /// <returns>Trả lại kiểu Datatable lưu thông tin của Procedure</returns>
        /// <remarks></remarks>
        private static DataTable GetProcedureInfo(string spName)
        {
            string queryString = string.Format("Select * From information_schema.parameters Where ([SPECIFIC_Name]=N'{0}')", spName);
            return GetDataTable(queryString);
        }

        public static SqlParameter[] GetParameterValues<T>(string procedureName, T objInfo)
        {
            DataTable dtProcedureInfo = GetProcedureInfo(procedureName);
            if (dtProcedureInfo.Rows.Count == 0)
            {
                throw new ArgumentException("Không tìm thấy procedure");
            }
            SqlParameter[] sqlParameter = new SqlParameter[dtProcedureInfo.Rows.Count];

            string strFieldName = "";

            Dictionary<string, object> dicProperty = new Dictionary<string, object>();
            Type pType = objInfo.GetType();

            foreach (System.Reflection.PropertyInfo info in pType.GetProperties())
            {
                dicProperty.Add(info.Name, info.GetValue(objInfo, null));
            }

            object objO = new object();
            for (int i = 0; i < dtProcedureInfo.Rows.Count; i++)
            {
                try
                {
                    strFieldName = dtProcedureInfo.Rows[i]["PARAMETER_NAME"].ToString().Trim();
                    strFieldName = strFieldName.Replace("@", "");
                    sqlParameter[i] = new SqlParameter(dtProcedureInfo.Rows[i]["PARAMETER_NAME"].ToString(), Null.GetNull(dicProperty[strFieldName], DBNull.Value));
                    if (dtProcedureInfo.Rows[i]["DATA_TYPE"].ToString().Equals("image") == true)
                    {
                        sqlParameter[i].SqlDbType = SqlDbType.Image;
                    }
                }
                catch (Exception ex)
                {
                    throw new System.ArgumentException("Trường gây lỗi: " + strFieldName + " :" + ex.Message);
                }
            }
            return sqlParameter;
        }

        public static int ExecuteNonQueryOfT<T>(string spName, T objInfo)
        {
            SqlParameter[] partametervalue = GetParameterValues(spName, objInfo);
            SqlConnection conn = openConnection();
            SqlCommand myCommand = new SqlCommand();
            try
            {
                if (objInfo != null)
                {
                    myCommand.Parameters.AddRange(partametervalue);
                }
                myCommand.Connection = openConnection();
                myCommand.CommandText = spName;
                myCommand.CommandType = CommandType.StoredProcedure;
                return myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message);
            }
            finally
            {
                closeConnection(conn);
                if (myCommand != null)
                    myCommand.Dispose();
            }
        }

        public static object ExecuteScalarOfT<T>(string spName, T objInfo)
        {
            SqlParameter[] partametervalue = GetParameterValues(spName, objInfo);
            SqlConnection conn = openConnection();
            SqlCommand myCommand = new SqlCommand();
            try
            {
                if (objInfo != null)
                {
                    myCommand.Parameters.AddRange(partametervalue);
                }
                myCommand.Connection = openConnection();
                myCommand.CommandText = spName;
                myCommand.CommandType = CommandType.StoredProcedure;
                return myCommand.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message);
            }
            finally
            {
                closeConnection(conn);
                if (myCommand != null)
                    myCommand.Dispose();
            }
        }
    }
}