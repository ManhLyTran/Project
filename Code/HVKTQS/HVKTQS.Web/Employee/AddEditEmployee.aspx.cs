using HVKTQS.BAL;
using HVKTQS.Entities;
using HVKTQS.Web.Component;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;

namespace HVKTQS.Web.Employee
{
    public partial class AddEditEmployee : System.Web.UI.Page
    {
        private int EmployeeID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EmployeeID = int.Parse(Request.Params["Id"]);
            }
            catch (Exception)
            {
            }
            if (!IsPostBack)
            {
                Subject_BAL objSubject_DAL = new Subject_BAL();
                foreach (DataRow row in objSubject_DAL.GetAll().Rows)
                {
                    ListItem item = new ListItem(row["SubjectName"].ToString(), row["SubjectID"].ToString());
                    item.Attributes["OptionGroup"] = row["DepartmentName"].ToString();
                    ddlSubject.Items.Add(item);
                }
                ddlSubject.Items.Insert(0, new ListItem("----Chọn---", "-1"));
                ddlSubject.DataBind();

                Position_BAL objPosition_BAL = new Position_BAL();
                ddlPosition.DataSource = objPosition_BAL.GetAll();
                ddlPosition.DataTextField = "PositionName";
                ddlPosition.DataValueField = "PositionID";
                ddlPosition.DataBind();
                ddlPosition.Items.Insert(0, new ListItem("----Chọn---", "-1"));

                if (EmployeeID > 0)
                {
                    lblTitle.Text = "Sửa thông tin giảng viên";
                }
                else
                {
                    lblTitle.Text = "Thêm mới thông tin giảng viên";
                }
                loadEntity();
            }
        }

        private void loadEntity()
        {
            Employee_BAL objImpl = new Employee_BAL();
            Employee_DTO objInfo = objImpl.GetObject(EmployeeID);
            if (objInfo == null)
            {
                return;
            }
            txtFullName.Text = objInfo.FullName;
            txtDateOfBirth.Text = objInfo.DateOfBirth.ToString("dd/MM/yyyy");
            if (objInfo.Gender == true)
            {
                rbtFeMale.Checked = true;
            }
            else
            {
                rbtMale.Checked = true;
            }
            ddlSubject.SelectedValue = objInfo.SubjectID.ToString();
            ddlPosition.SelectedValue = objInfo.PositionID.ToString();
            txtAcademicRank.Text = objInfo.AcademicRank;
            txtBachelorDegree.Text = objInfo.BachelorDegree;
            txtEmail.Text = objInfo.Email;
            txtPhone.Text = objInfo.Phone;
            txtAddress.Text = objInfo.Address;
            hddImagePath.Value = "/assets/global/employee/" + objInfo.ImagePath;
            hddFileImage.Value = objInfo.ImagePath;
            User_BAL objUser_BAL = new User_BAL();
            User_DTO objUser_DTO = objUser_BAL.GetObject(EmployeeID);
            txtUsername.Text = objUser_DTO.UserName;
            ddlRole.SelectedValue = objUser_DTO.Role.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee_DTO objInfo = new Employee_DTO();
            objInfo.FullName = txtFullName.Text;
            if (String.IsNullOrEmpty(txtDateOfBirth.Text) == false)
            {
                objInfo.DateOfBirth = DateTime.ParseExact(txtDateOfBirth.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            objInfo.Gender = rbtFeMale.Checked == true ? true : false;
            objInfo.SubjectID = int.Parse(ddlSubject.SelectedValue.ToString());
            objInfo.PositionID = int.Parse(ddlPosition.SelectedValue.ToString());
            objInfo.AcademicRank = txtAcademicRank.Text;
            objInfo.BachelorDegree = txtBachelorDegree.Text;
            objInfo.Email = txtEmail.Text;
            objInfo.Address = txtAddress.Text;
            objInfo.Phone = txtPhone.Text;
            objInfo.EmployeeID = EmployeeID;
            //user
            User_DTO objUserInfo = new User_DTO();
            objUserInfo.UserID = EmployeeID;
            objUserInfo.UserName = txtUsername.Text;
            objUserInfo.Role = int.Parse(ddlRole.SelectedValue);
            Employee_BAL objImpl = new Employee_BAL();
            User_BAL objUserImpl = new User_BAL();
            var data_path = "/assets/global/employee/";
            if (objUserImpl.IsExists(objUserInfo.UserID, objUserInfo.UserName) == true)
            {
                litError.Text = "<div class='alert alert-danger'><button class='close' data-close='alert'></button><span>Tài khoản này đã tồn tại!</span></div>";
                return;
            }
            else
            {
                litError.Text = "";
            }
            if (objInfo.EmployeeID > 0)
            {
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
                objUserImpl.Update(objUserInfo);
            }
            else
            {
                if (fuImagePath.PostedFile != null && fuImagePath.FileName.Length > 0)
                {
                    if (!Directory.Exists(Server.MapPath(data_path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(data_path));
                    }
                    string fileNameImage = Guid.NewGuid().ToString() + Path.GetExtension(fuImagePath.PostedFile.FileName.ToLower());
                    fuImagePath.PostedFile.SaveAs(Server.MapPath(data_path + fileNameImage));
                    objInfo.ImagePath = fileNameImage;
                }

                EmployeeID = objImpl.Insert(objInfo);
                objUserInfo.UserID = EmployeeID;
                objUserInfo.Password = StringHelper.MD5("123456");
                objUserInfo.IsLock = false;
                objUserImpl.Insert(objUserInfo);
            }
            Response.Redirect("~/employee/listemployee");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/employee/listemployee");
        }
    }
}