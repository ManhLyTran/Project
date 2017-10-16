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
    public class Subject_BAL
    {
        private Subject_DAL objSubject_DAL = new Subject_DAL();

        public int Update(Subject_DTO obj)
        {
            return objSubject_DAL.Update(obj);
        }

        public int Insert(Subject_DTO obj)
        {
            return objSubject_DAL.Insert(obj);
        }

        public int DeleteByID(int SubjectID)
        {
            return objSubject_DAL.DeleteByID(SubjectID);
        }

        public int UpdateViewOrderInBatches(string strSubjectID)
        {
            return objSubject_DAL.UpdateViewOrderInBatches(strSubjectID);
        }

        public Boolean CanDelete(int SubjectID)
        {
            return objSubject_DAL.CanDelete(SubjectID);
        }

        public DataTable GetAll()
        {
            return objSubject_DAL.GetAll();
        }

        public Subject_DTO GetObject(int SubjectID)
        {
            return objSubject_DAL.GetObject(SubjectID);
        }

        public string GetHTML()
        {
            Subject_BAL objImpl = new Subject_BAL();
            DataTable dt = objImpl.GetAll();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("");
            strBuilder.AppendLine("<table id = 'tblList' class='table table-striped table-bordered table-advance table-hover'>");
            strBuilder.AppendLine("<thead>");
            strBuilder.AppendLine("<tr>");
            strBuilder.AppendLine("<th class='hidden'></th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 1px;'></th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 40px;'>STT</th>");
            strBuilder.AppendLine("<th class='text-center'>Tên bộ môn</th>");
            strBuilder.AppendLine("<th class='text-center'>Khoa</th>");
            strBuilder.AppendLine("<th class='text-center'>Mô tả</th>");
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
                    strBuilder.AppendLine("<td class='hidden'>" + row["SubjectID"].ToString() + "</td>");
                    strBuilder.AppendLine("<td>");
                    strBuilder.AppendLine("<span class='drag-drop' style='cursor: move;'><i></i></span>");
                    strBuilder.AppendLine("</td>");
                    strBuilder.AppendLine("<td>" + index.ToString() + "</td>");
                    strBuilder.AppendLine("<td>" + row["SubjectName"].ToString() + "</td>");
                    strBuilder.AppendLine("<td>" + row["DepartmentName"].ToString() + "</td>");
                    strBuilder.AppendLine("<td>" + row["Description"].ToString() + "</td>");
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