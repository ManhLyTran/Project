using HVKTQS.Entities;
using System;
using System.Data;

namespace HVKTQS.DAL
{
    public class Subject_DAL
    {
        public int Update(Subject_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("Subject_Update", obj);
        }

        public int Insert(Subject_DTO obj)
        {
            return Int32.Parse(SqlHelper.ExecuteScalarOfT("Subject_Insert", obj).ToString());
        }

        public int DeleteByID(int SubjectID)
        {
            return SqlHelper.ExecuteNoneQuery("Subject_DeleteByID", SubjectID);
        }

        public int UpdateViewOrderInBatches(string strSubjectID)
        {
            return SqlHelper.ExecuteNoneQuery("Subject_UpdateViewOrderInBatches", strSubjectID);
        }

        public Boolean CanDelete(int SubjectID)
        {
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("Subject_CanDelete", SubjectID));
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteReader("Subject_GetAll");
        }

        public Subject_DTO GetObject(int SubjectID)
        {
            return (Subject_DTO)CBO.FillObject(SqlHelper.ExecuteReader("Subject_GetObject", SubjectID), typeof(Subject_DTO));
        }
    }
}