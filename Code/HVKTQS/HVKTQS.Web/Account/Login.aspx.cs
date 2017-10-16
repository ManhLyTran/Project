using HVKTQS.BAL;
using HVKTQS.Entities;
using HVKTQS.Web.Component;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HVKTQS.Web.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                Session["UserLogin"] = null;
            }
            if (Request.Cookies["userInfo"] != null)
            {
                chkRemember.Checked = true;
                txtUsername.Text = Server.HtmlEncode(Request.Cookies["userInfo"]["userName"]);
                txtPassword.Attributes.Add("value", Server.HtmlEncode(Request.Cookies["userInfo"]["password"]));
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User_BAL objUserImpl = new User_BAL();
            UserExtension_DTO objInfo = objUserImpl.Login(txtUsername.Text, StringHelper.MD5(txtPassword.Text));
            if (objInfo != null)
            {
                if (objInfo.IsLock == true)
                {
                    litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Tài khoản đang bị khóa!</span></div>";
                }
                else
                {
                    Session["LockScreen"] = false;
                    Session["UserLogin"] = objInfo;
                    if (chkRemember.Checked == true)
                    {
                        HttpCookie userCookie = new HttpCookie("userInfo");
                        userCookie.Values["userName"] = txtUsername.Text;
                        userCookie.Values["password"] = txtPassword.Text;
                        userCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(userCookie);
                    }
                    objUserImpl.UpdateLastIPAddress(objInfo.UserID, GetIPAddress());
                    Response.Redirect("~/Default");
                }
            }
            else
            {
                litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Tài khoản và mật khẩu không đúng!</span></div>";
            }
        }

        public string GetIPAddress()
        {
            string IPAddress = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
    }
}