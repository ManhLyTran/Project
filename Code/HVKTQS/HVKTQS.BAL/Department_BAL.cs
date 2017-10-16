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
    public class Department_BAL
    {
        private Department_DAL objDepartment_DAL = new Department_DAL();

        public int Update(Department_DTO obj)
        {
            return objDepartment_DAL.Update(obj);
        }

        public int Insert(Department_DTO obj)
        {
            return objDepartment_DAL.Insert(obj);
        }

        public int DeleteByID(int DepartmentID)
        {
            return objDepartment_DAL.DeleteByID(DepartmentID);
        }

        public int UpdateViewOrderInBatches(string strDepartmentID)
        {
            return objDepartment_DAL.UpdateViewOrderInBatches(strDepartmentID);
        }

        public Boolean CanDelete(int DepartmentID)
        {
            return objDepartment_DAL.CanDelete(DepartmentID);
        }

        public DataTable GetAll()
        {
            return objDepartment_DAL.GetAll();
        }

        public Department_DTO GetObject(int DepartmentID)
        {
            return objDepartment_DAL.GetObject(DepartmentID);
        }

        public string GetHTML()
        {
            Department_BAL objImpl = new Department_BAL();
            DataTable dt = objImpl.GetAll();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("");
            strBuilder.AppendLine("<table id = 'tblList' class='table table-striped table-bordered table-advance table-hover'>");
            strBuilder.AppendLine("<thead>");
            strBuilder.AppendLine("<tr>");
            strBuilder.AppendLine("<th class='hidden'></th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 1px;'></th>");
            strBuilder.AppendLine("<th class='text-center' style='width: 40px;'>STT</th>");
            strBuilder.AppendLine("<th class='text-center'>Tên khoa</th>");
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
                    strBuilder.AppendLine("<td class='hidden'>" + row["DepartmentID"].ToString() + "</td>");
                    strBuilder.AppendLine("<td>");
                    strBuilder.AppendLine("<span class='drag-drop' style='cursor: move;'><i></i></span>");
                    strBuilder.AppendLine("</td>");
                    strBuilder.AppendLine("<td>" + index.ToString() + "</td>");
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