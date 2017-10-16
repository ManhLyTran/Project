using HVKTQS.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web.Employee
{
    public partial class ListEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Subject_BAL objSubject_DAL = new Subject_BAL();
                foreach (DataRow row in objSubject_DAL.GetAll().Rows)
                {
                    ListItem item = new ListItem(row["SubjectName"].ToString(), row["SubjectID"].ToString());
                    item.Attributes["OptionGroup"] = row["DepartmentName"].ToString();
                    ddlSubject.Items.Add(item);
                }
                ddlSubject.Items.Insert(0, new ListItem("----Tất cả---", "-1"));
                ddlSubject.DataBind();

                Position_BAL objPosition_BAL = new Position_BAL();
                ddlPosition.DataSource = objPosition_BAL.GetAll();
                ddlPosition.DataTextField = "PositionName";
                ddlPosition.DataValueField = "PositionID";
                ddlPosition.DataBind();
                ddlPosition.Items.Insert(0, new ListItem("----Tất cả---", "-1"));
                loadData();
            }
        }

        private void loadData()
        {
            int subjectID = int.Parse(ddlSubject.SelectedValue.ToString());
            int positionID = int.Parse(ddlPosition.SelectedValue.ToString());
            string keywword = txtKeyword.Text;
            Employee_BAL objImpl = new Employee_BAL();
            rptEmployee.DataSource = objImpl.Search(subjectID, positionID, keywword);
            rptEmployee.DataBind();
        }

        protected void lbtAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/employee/addeditemployee");
        }

        protected void rptEmployee_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int employeeID = int.Parse(e.CommandArgument.ToString());
            string cmd = e.CommandName;
            if (cmd == "Edit")
            {
                Response.Redirect("~/employee/addeditemployee?id=" + employeeID.ToString());
            }
            else if (cmd == "Delete")
            {
                Employee_BAL objImpl = new Employee_BAL();
                objImpl.DeleteByID(employeeID);
                loadData();
            }
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}