using HVKTQS.BAL;
using HVKTQS.Entities;
using HVKTQS.Web.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web.Account
{
    public partial class UserLock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LockScreen"] = true;
            if (Session["UserLogin"] != null)
            {
                UserExtension_DTO objInfo = (UserExtension_DTO)Session["UserLogin"];
                lblFullName.Text = objInfo.FullName;
                lblFullName1.Text = objInfo.FullName;
                if (objInfo.ImagePath == "")
                {
                    imgAvatar.ImageUrl = "/assets/img/avatar.jpg";
                }
                else
                {
                    imgAvatar.ImageUrl = "/assets/global/employee/" + objInfo.ImagePath;
                }
            }
            else
            {
                Response.Redirect("~/Account/Login");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                UserExtension_DTO objInfo = (UserExtension_DTO)Session["UserLogin"];
                User_BAL objUserImpl = new User_BAL();
                UserExtension_DTO objInfonew = objUserImpl.Login(objInfo.UserName, StringHelper.MD5(txtPassword.Text));
                if (objInfonew != null)
                {
                    Session["UserLogin"] = objInfonew;
                    Session["LockScreen"] = false;
                    Response.Redirect("~/Default");
                }
                else
                {
                    litError.Text = "<div class='alert alert-danger alert-lock'><button class='close' data-close='alert'></button><span>Mật khẩu không đúng!</span></div>";
                }
            }
            else
            {
                Response.Redirect("~/Account/Login");
            }
        }
    }
}