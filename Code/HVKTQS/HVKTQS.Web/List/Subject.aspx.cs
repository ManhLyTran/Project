using HVKTQS.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web
{
    public partial class Subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Subject_BAL objImpl = new Subject_BAL();
                litList.Text = objImpl.GetHTML();
                Department_BAL objDepartment_BAL = new Department_BAL();
                ddlDepartment.DataSource = objDepartment_BAL.GetAll();
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("---Chọn---", "-1"));
            }
        }
    }
}