using HVKTQS.BAL;
using System;

namespace HVKTQS.Web
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Department_BAL objImpl = new Department_BAL();
                litList.Text = objImpl.GetHTML();
            }
        }
    }
}