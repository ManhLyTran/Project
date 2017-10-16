using HVKTQS.Entities;
using System;
using System.Data;

namespace HVKTQS.DAL
{
    public class Department_DAL
    {
        public int Update(Department_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("Department_Update", obj);
        }

        public int Insert(Department_DTO obj)
        {
            return Int32.Parse(SqlHelper.ExecuteScalarOfT("Department_Insert", obj).ToString());
        }

        public int DeleteByID(int DepartmentID)
        {
            return SqlHelper.ExecuteNoneQuery("Department_DeleteByID", DepartmentID);
        }

        public int UpdateViewOrderInBatches(string strDepartmentID)
        {
            return SqlHelper.ExecuteNoneQuery("Department_UpdateViewOrderInBatches", strDepartmentID);
        }

        public Boolean CanDelete(int DepartmentID)
        {
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("Department_CanDelete", DepartmentID));
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteReader("Department_GetAll");
        }

        public Department_DTO GetObject(int DepartmentID)
        {
            return (Department_DTO)CBO.FillObject(SqlHelper.ExecuteReader("Department_GetObject", DepartmentID), typeof(Department_DTO));
        }
    }
}