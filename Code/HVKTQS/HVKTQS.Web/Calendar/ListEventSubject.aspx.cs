using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web.Calendar
{
    public partial class ListEventSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lbtAddEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/calendar/addeditcalendar");
        }
    }
}