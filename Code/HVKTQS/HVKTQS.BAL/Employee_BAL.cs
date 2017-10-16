using HVKTQS.DAL;
using HVKTQS.Entities;
using System;
using System.Data;
using System.Text;

namespace HVKTQS.BAL
{
    public class Employee_BAL
    {
        private Employee_DAL objEmployee_DAL = new Employee_DAL();

        public int Update(Employee_DTO obj)
        {
            return objEmployee_DAL.Update(obj);
        }

        public int Insert(Employee_DTO obj)
        {
            return objEmployee_DAL.Insert(obj);
        }

        public int DeleteByID(int EmployeeID)
        {
            return objEmployee_DAL.DeleteByID(EmployeeID);
        }

        public DataTable GetAll()
        {
            return objEmployee_DAL.GetAll();
        }

        public DataTable Search(int SubjectID, int PositionID, string Keyword)
        {
            return objEmployee_DAL.Search(SubjectID, PositionID, Keyword);
        }

        public Employee_DTO GetObject(int EmployeeID)
        {
            return objEmployee_DAL.GetObject(EmployeeID);
        }
    }
}