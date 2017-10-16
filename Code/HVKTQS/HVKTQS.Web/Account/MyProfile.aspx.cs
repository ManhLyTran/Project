using HVKTQS.BAL;
using HVKTQS.Entities;
using System;
using System.Globalization;
using System.IO;

namespace HVKTQS.Web.Account
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserLogin"] != null)
                {
                    UserExtension_DTO objInfo = (UserExtension_DTO)Session["UserLogin"];
                    lblFullName.Text = objInfo.FullName;
                    lblDateOfBirth.Text = objInfo.DateOfBirth.ToString("dd/MM/yyyy");
                    lblGender.Text = objInfo.Gender == true ? "Nam" : "Nữ";
                    lblSubject.Text = objInfo.SubjectName;
                    lblPosition.Text = objInfo.PositionName;
                    txtAcademicRank.Text = objInfo.AcademicRank;
                    txtBachelorDegree.Text = objInfo.BachelorDegree;
                    txtEmail.Text = objInfo.Email;
                    txtPhone.Text = objInfo.Phone;
                    txtAddress.Text = objInfo.Address;
                    hddImagePath.Value = "/assets/global/employee/" + objInfo.ImagePath;
                    hddFileImage.Value = objInfo.ImagePath;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserExtension_DTO objUserExtensInfo = new UserExtension_DTO(); ;
            if (Session["UserLogin"] != null)
            {
                objUserExtensInfo = (UserExtension_DTO)Session["UserLogin"];
            }
            Employee_DTO objInfo = new Employee_DTO();
            objInfo.FullName = objUserExtensInfo.FullName;
            objInfo.DateOfBirth = DateTime.ParseExact(lblDateOfBirth.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objInfo.Gender = objUserExtensInfo.Gender;
            objInfo.SubjectID = objUserExtensInfo.SubjectID;
            objInfo.PositionID = objUserExtensInfo.PositionID;
            objInfo.AcademicRank = txtAcademicRank.Text;
            objInfo.BachelorDegree = txtBachelorDegree.Text;
            objInfo.Email = txtEmail.Text;
            objInfo.Address = txtAddress.Text;
            objInfo.Phone = txtPhone.Text;
            objInfo.EmployeeID = objUserExtensInfo.UserID;
            Employee_BAL objImpl = new Employee_BAL();
            var data_path = "/assets/global/employee/";
            if (fuImagePath.PostedFile != null && fuImagePath.FileName.Length > 0)
            {
                if (!Directory.Exists(Server.MapPath(data_path)))
                {
                    Directory.CreateDirectory(Server.MapPath(data_path));
                }
                string fileNameImage = Guid.NewGuid().ToString() + Path.GetExtension(fuImagePath.PostedFile.FileName.ToLower());
                this.fuImagePath.PostedFile.SaveAs(Server.MapPath(data_path + fileNameImage));
                objInfo.ImagePath = fileNameImage;
                if (!string.IsNullOrEmpty(this.hddFileImage.Value))
                {
                    string PathFile = Server.MapPath(data_path + hddFileImage.Value);
                    if (File.Exists(PathFile))
                    {
                        File.Delete(PathFile);
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.hddFileImage.Value))
                {
                    if (this.hddRemoveImage.Value == "1")
                    {
                        string PathFile = Server.MapPath(data_path + this.hddFileImage.Value);
                        if (File.Exists(PathFile))
                        {
                            File.Delete(PathFile);
                        }
                        objInfo.ImagePath = "";
                    }
                    else
                    {
                        objInfo.ImagePath = hddFileImage.Value;
                    }
                }
            }
            objImpl.Update(objInfo);
            Session["UserLogin"] = (new User_BAL()).Login(objUserExtensInfo.UserName, objUserExtensInfo.Password);
            litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Cập nhật thông tin cá nhân thành công!</span></div>";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~");
        }
    }
}