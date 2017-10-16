using HVKTQS.BAL;
using HVKTQS.Web.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web.Account
{
    public partial class ListAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            User_BAL objImpl = new User_BAL();
            rptUser.DataSource = objImpl.Search(txtKeyword.Text);
            rptUser.DataBind();
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int userID = int.Parse(e.CommandArgument.ToString());
            string cmd = e.CommandName;
            User_BAL objImpl = new User_BAL();
            if (cmd == "ResetPassword")
            {
                objImpl.ChangePassword(userID, StringHelper.MD5("123456"));
                litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Reset mật khẩu thành công!</span></div>";
            }
            else if (cmd == "LockUsser")
            {
                objImpl.UpdateLockUsser(userID, true);
                litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Khóa tài khoản thành công!</span></div>";
            }
            else if (cmd == "UnLockUsser")
            {
                objImpl.UpdateLockUsser(userID, false);
                litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Mở khóa tài khoản thành công!</span></div>";
            }
            LoadData();
        }

        protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkLockUsser = (LinkButton)e.Item.FindControl("lnkLockUsser");
                LinkButton lnkUnLockUsser = (LinkButton)e.Item.FindControl("lnkUnLockUsser");
                Label lblRole = (Label)e.Item.FindControl("lblRole");

                bool isLock = Boolean.Parse(DataBinder.Eval(e.Item.DataItem, "IsLock").ToString());
                if (isLock == true)
                {
                    lnkLockUsser.Visible = false;
                    lnkUnLockUsser.Visible = true;
                }
                else
                {
                    lnkLockUsser.Visible = true;
                    lnkUnLockUsser.Visible = false;
                }
                int Role = int.Parse(DataBinder.Eval(e.Item.DataItem, "Role").ToString());
                switch (Role)
                {
                    case 0:
                        lblRole.Text = "Quản trị hệ thống";
                        break;

                    case 1:
                        lblRole.Text = "Quản trị viên";
                        break;

                    case 2:
                        lblRole.Text = "Thành viên";
                        break;

                    default:
                        lblRole.Text = "";
                        break;
                }
            }
        }
    }
}