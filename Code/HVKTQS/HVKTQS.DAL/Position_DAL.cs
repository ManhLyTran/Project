using HVKTQS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.DAL
{
    public partial class Position_DAL
    {
        public int Update(Position_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("Position_Update", obj);
        }

        public int Insert(Position_DTO obj)
        {
            return Int32.Parse(SqlHelper.ExecuteScalarOfT("Position_Insert", obj).ToString());
        }

        public int DeleteByID(int PositionID)
        {
            return SqlHelper.ExecuteNoneQuery("Position_DeleteByID", PositionID);
        }

        public int UpdateViewOrderInBatches(string strPositionID)
        {
            return SqlHelper.ExecuteNoneQuery("Position_UpdateViewOrderInBatches", strPositionID);
        }

        public Boolean CanDelete(int PositionID)
        {
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("Position_CanDelete", PositionID));
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteReader("Position_GetAll");
        }

        public Position_DTO GetObject(int PositionID)
        {
            return (Position_DTO)CBO.FillObject(SqlHelper.ExecuteReader("Position_GetObject", PositionID), typeof(Position_DTO));
        }
    }
}