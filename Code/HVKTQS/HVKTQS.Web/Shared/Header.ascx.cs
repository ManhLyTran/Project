using HVKTQS.Entities;
using System;

namespace HVKTQS.Web.Shared
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                UserExtension_DTO objInfo = (UserExtension_DTO)Session["UserLogin"];
                lblFullName.Text = objInfo.FullName;
                if (objInfo.ImagePath == "")
                {
                    imgAvatar.ImageUrl = "~/assets/img/avatar.jpg";
                }
                else
                {
                    imgAvatar.ImageUrl = "~/assets/global/employee/" + objInfo.ImagePath;
                }
            }
            else
            {
                //Response.Redirect("~/Account/Login");
            }
            if (Session["LockScreen"] != null && Boolean.Parse(Session["LockScreen"].ToString()) == true)
            {
                Response.Redirect("~/Account/UserLock");
            }
        }
    }
}