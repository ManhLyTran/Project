using HVKTQS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.DAL
{
    public partial class EventFile_DAL
    {
        public int InsertUpdate(EventFile_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("EventFile_InsertUpdate", obj);
        }

        public int Update(EventFile_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("EventFile_Update", obj);
        }

        public int Insert(EventFile_DTO obj)
        {
            return Int32.Parse(SqlHelper.ExecuteScalarOfT("EventFile_Insert", obj).ToString());
        }

        public int DeleteByID(int EventFileID)
        {
            return SqlHelper.ExecuteNoneQuery("EventFile_DeleteByID", EventFileID);
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteReader("EventFile_GetAll");
        }

        public EventFile_DTO GetObject(int EventFileID)
        {
            return (EventFile_DTO)CBO.FillObject(SqlHelper.ExecuteReader("EventFile_GetObject", EventFileID), typeof(EventFile_DTO));
        }
    }
}