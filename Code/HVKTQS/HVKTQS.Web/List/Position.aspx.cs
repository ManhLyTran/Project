using HVKTQS.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web
{
    public partial class Position : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Position_BAL objImpl = new Position_BAL();
                litList.Text = objImpl.GetHTML();
            }
        }
    }
}