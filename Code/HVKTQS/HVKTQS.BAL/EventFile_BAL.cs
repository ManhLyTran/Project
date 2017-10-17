using HVKTQS.DAL;
using HVKTQS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.BAL
{
    public partial class EventFile_BAL
    {
        private EventFile_DAL EventFile_DAL = new EventFile_DAL();

        public int InsertUpdate(EventFile_DTO obj)
        {
            return EventFile_DAL.InsertUpdate(obj);
        }

        public int Update(EventFile_DTO obj)
        {
            return EventFile_DAL.Update(obj);
        }

        public int Insert(EventFile_DTO obj)
        {
            return EventFile_DAL.Insert(obj);
        }

        public int DeleteByID(int PositionID)
        {
            return EventFile_DAL.DeleteByID(PositionID);
        }

        public DataTable GetAll()
        {
            return EventFile_DAL.GetAll();
        }

        public EventFile_DTO GetObject(int PositionID)
        {
            return EventFile_DAL.GetObject(PositionID);
        }
    }
}