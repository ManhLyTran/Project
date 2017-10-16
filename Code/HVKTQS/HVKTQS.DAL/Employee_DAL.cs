using HVKTQS.Entities;
using System;
using System.Data;

namespace HVKTQS.DAL
{
    public class Employee_DAL
    {
        public int Update(Employee_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("Employee_Update", obj);
        }

        public int Insert(Employee_DTO obj)
        {
            return Int32.Parse(SqlHelper.ExecuteScalarOfT("Employee_Insert", obj).ToString());
        }

        public int DeleteByID(int DepartmentID)
        {
            return SqlHelper.ExecuteNoneQuery("Employee_DeleteByID", DepartmentID);
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteReader("Employee_GetAll");
        }

        public DataTable Search(int SubjectID, int PositionID, string Keyword)
        {
            return SqlHelper.ExecuteReader("Employee_Search", SubjectID, PositionID, Keyword);
        }

        public Employee_DTO GetObject(int DepartmentID)
        {
            return (Employee_DTO)CBO.FillObject(SqlHelper.ExecuteReader("Employee_GetObject", DepartmentID), typeof(Employee_DTO));
        }
    }
}