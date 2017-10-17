using HVKTQS.DAL;
using HVKTQS.Entities;
using System;
using System.Data;
using System.Text;

namespace HVKTQS.BAL
{
    public class GeneralEvent_BAL
    {
        private GeneralEvent_DAL objGeneralEvent_DAL = new GeneralEvent_DAL();

        public int Update(GeneralEvent_DTO obj)
        {
            return objGeneralEvent_DAL.Update(obj);
        }

        public int Insert(GeneralEvent_DTO obj)
        {
            return objGeneralEvent_DAL.Insert(obj);
        }

        public int DeleteByID(int GeneralEventID)
        {
            return objGeneralEvent_DAL.DeleteByID(GeneralEventID);
        }

        public DataTable GetAll()
        {
            return objGeneralEvent_DAL.GetAll();
        }

        public GeneralEvent_DTO GetObject(int GeneralEventID)
        {
            return objGeneralEvent_DAL.GetObject(GeneralEventID);
        }
    }
}