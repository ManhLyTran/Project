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
    public partial class Position_BAL
    {
        private Position_DAL objPositon_DAL = new Position_DAL();

        public int Update(Position_DTO obj)
        {
            return objPositon_DAL.Update(obj);
        }

        public int Insert(Position_DTO obj)
        {
            return objPositon_DAL.Insert(obj);
        }

        public int DeleteByID(int PositionID)
        {
            return objPositon_DAL.DeleteByID(PositionID);
        }

        public int UpdateViewOrderInBatches(string strPositionID)
        {
            return objPositon_DAL.UpdateViewOrderInBatches(strPositionID);
        }

        public Boolean CanDelete(int PositionID)
        {
            return objPositon_DAL.CanDelete(PositionID);
        }

        public DataTable GetAll()
        {
            return objPositon_DAL.GetAll();
        }

        public Position_DTO GetObject(int PositionID)
        {
            return objPositon_DAL.GetObject(PositionID);
        }

        public string GetHTML()
        {
            Position_BAL objImpl = new Position_BAL();
            DataTable dt = objImpl.GetAll();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("");
            strBuilder.AppendLine("<table id = 'tblList' class='table table-striped table-bordered table-advance table-hover'>");
            strBuilder.AppendLine("<thead>");
            strBuilder.AppendLine("<tr>");
            strBuilder.AppendLine("<th class='hidden'></th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 1px;'></th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 40px;'>STT</th>");
            strBuilder.AppendLine("<th class='text-center'>Tên chức vụ</th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 40px;'>Sửa</th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 40px;'>Xóa</th>");
            strBuilder.AppendLine("</tr>");
            strBuilder.AppendLine("</thead>");
            strBuilder.AppendLine("<tbody>");
            if (dt.Rows.Count > 0)
            {
                int index = 0;
                foreach (DataRow row in dt.Rows)
                {
                    index = index + 1;
                    strBuilder.AppendLine("<tr>");
                    strBuilder.AppendLine("<td class='hidden'>" + row["PositionID"].ToString() + "</td>");
                    strBuilder.AppendLine("<td>");
                    strBuilder.AppendLine("<span class='drag-drop' style='cursor: move;'><i></i></span>");
                    strBuilder.AppendLine("</td>");
                    strBuilder.AppendLine("<td>" + index.ToString() + "</td>");
                    strBuilder.AppendLine("<td>" + row["PositionName"].ToString() + "</td>");
                    strBuilder.AppendLine("<td class='text-center'>");
                    strBuilder.AppendLine("<a class='lnkEdit' href='javascript:void(0);' title='Sửa'><i class='fa fa-pencil-square-o fa-lg'></i></a>");
                    strBuilder.AppendLine("</td>");
                    strBuilder.AppendLine("<td class='text-center'>");
                    strBuilder.AppendLine("<a class='lnkDelete' href='javascript:void(0);' title='Xóa'><i class='fa fa-trash-o fa-lg'></i></a>");
                    strBuilder.AppendLine("</td>");
                    strBuilder.AppendLine("</tr>");
                }
            }
            strBuilder.AppendLine("</tbody>");
            strBuilder.AppendLine("</table>");
            return strBuilder.ToString();
        }
    }
}