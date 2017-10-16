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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                UserExtension_DTO objInfo = (UserExtension_DTO)Session["UserLogin"];
                User_BAL objImpl = new User_BAL();
                if (objInfo.Password == StringHelper.MD5(txtCurrentPassword.Text))
                {
                    objImpl.ChangePassword(objInfo.UserID, StringHelper.MD5(txtNewPassword.Text));
                    litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Thay đổi mật khẩu thành công!</span></div>";
                }
                else
                {
                    litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Mật khẩu không đúng!</span></div>";
                }
            }
        }
    }
}