using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1; i <= 31; i++)
                {
                    ddlActualMonthlyDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }
    }
}