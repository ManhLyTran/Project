using HVKTQS.Entities;
using System;
using System.Data;

namespace HVKTQS.DAL
{
    public class GeneralEvent_DAL
    {
        public int Update(GeneralEvent_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("GeneralEvent_Update", obj);
        }

        public int Insert(GeneralEvent_DTO obj)
        {
            return Int32.Parse(SqlHelper.ExecuteScalarOfT("GeneralEvent_Insert", obj).ToString());
        }

        public int DeleteByID(int GeneralEventID)
        {
            return SqlHelper.ExecuteNoneQuery("GeneralEvent_DeleteByID", GeneralEventID);
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteReader("GeneralEvent_GetAll");
        }

        public GeneralEvent_DTO GetObject(int GeneralEventID)
        {
            return (GeneralEvent_DTO)CBO.FillObject(SqlHelper.ExecuteReader("GeneralEvent_GetObject", GeneralEventID), typeof(GeneralEvent_DTO));
        }
    }
}