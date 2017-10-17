using HVKTQS.BAL;
using HVKTQS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HVKTQS.Web.Calendar
{
    public partial class AddEditCalendar : System.Web.UI.Page
    {
        private int type = -1;
        private int GeneralEventID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Request.Params["type"]) == false)
                {
                    type = int.Parse(Request.Params["type"]);
                }
                if (String.IsNullOrEmpty(Request.Params["id"]) == false)
                {
                    GeneralEventID = int.Parse(Request.Params["id"]);
                }
            }
            catch (Exception)
            {
            }
            if (!IsPostBack)
            {
                switch (type)
                {
                    case 2:
                        lblSubject.Text = "Bộ môn <span class='required'>*</span>";
                        ddlDepartment_G.Visible = false;
                        ddlSubject_G.Visible = true;
                        lblTitle.Text = "Thêm mới sự kiện khoa";
                        break;

                    default:
                        lblSubject.Text = "Khoa <span class='required'>*</span>";
                        ddlDepartment_G.Visible = true;
                        ddlSubject_G.Visible = false;
                        lblTitle.Text = "Thêm mới sự kiện khoa";
                        break;
                }

                for (int i = 1; i <= 31; i++)
                {
                    ddlActualMonthlyDay_G.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                Subject_BAL objSubject_DAL = new Subject_BAL();
                DataTable dt = objSubject_DAL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    ListItem item = new ListItem(row["SubjectName"].ToString(), row["SubjectID"].ToString());
                    item.Attributes["OptionGroup"] = row["DepartmentName"].ToString();
                    ddlSubject_G.Items.Add(item);
                }
                ddlSubject_G.DataBind();
                ddlSubject_G.Items.Insert(0, new ListItem("----Chọn---", "-1"));
                if (dt.Rows.Count > 0)
                {
                    ddlSubject_G.SelectedIndex = 1;
                }
                Department_BAL objDepartment_BAL = new Department_BAL();
                DataTable dt1 = objDepartment_BAL.GetAll();
                ddlDepartment_G.DataSource = dt1;
                ddlDepartment_G.DataTextField = "DepartmentName";
                ddlDepartment_G.DataValueField = "DepartmentID";
                ddlDepartment_G.DataBind();
                ddlDepartment_G.Items.Insert(0, new ListItem("----Chọn---", "-1"));
                if (dt1.Rows.Count > 0)
                {
                    ddlDepartment_G.SelectedIndex = 1;
                }
                LoadData();
            }
        }

        private void LoadData()
        {
            GeneralEvent_BAL objImpl = new GeneralEvent_BAL();
            GeneralEvent_DTO objInfo = objImpl.GetObject(GeneralEventID);
            if (objInfo == null)
            {
                return;
            }
            ddlDepartment_G.SelectedValue = objInfo.DepartmentID.ToString();
            ddlSubject_G.SelectedValue = objInfo.SubjectID.ToString();
            chkIsDone_G.Checked = objInfo.IsDone;
            chkIsImportant_G.Checked = objInfo.IsImportant;
            txtTitle_G.Text = objInfo.Title;
            txtStartDate_G.Text = objInfo.StartDate.ToString("dd/MM/yyyy");
            if (objInfo.EndDate.Hour == 0 && objInfo.EndDate.Minute == 0)
            {
                chkNotEndDate_G.Checked = true;
            }
            else
            {
                chkNotEndDate_G.Checked = false;
                txtTimeEnd_G.Text = objInfo.EndDate.ToString("HH:mm");
            }
            if (objInfo.StartDate.Hour == 0 && objInfo.StartDate.Minute == 0)
            {
                chkAllDay_G.Checked = true;
            }
            else
            {
                chkAllDay_G.Checked = false;
                txtTimeStart_G.Text = objInfo.StartDate.ToString("HH:mm");
            }
            txtDescription_G.Text = objInfo.Description;
            txtLocation_G.Text = objInfo.Location;
            txtOrganizer_G.Text = objInfo.Organizer;
            txtParticipant_G.Text = objInfo.Participant;
            txtPreparation_G.Text = objInfo.Preparation;
            divRecurrence.Visible = false;
            litModify.Text = "<span class='caption-helper'>Tạo lúc " + objInfo.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss") + " bởi " + objInfo.CreatedBy + "</span></br>";
            litModify.Text += "<span class='caption-helper'>Cập nhật lúc " + objInfo.ModifyDate.ToString("dd/MM/yyyy HH:mm:ss") + " bởi " + objInfo.ModifyBy + "</span>";
        }

        protected void btnCancel_G_Click(object sender, EventArgs e)
        {
        }

        private double DayDifference(DateTime lValue, DateTime rValue)
        {
            return (lValue - rValue).TotalDays;
        }

        protected void btnSave_G_Click(object sender, EventArgs e)

        {
            GeneralEvent_DTO objInfo = new GeneralEvent_DTO();
            if (String.IsNullOrEmpty(ddlDepartment_G.SelectedValue))
            {
                objInfo.DepartmentID = -1;
            }
            else
            {
                objInfo.DepartmentID = int.Parse(ddlDepartment_G.SelectedValue);
            }
            if (String.IsNullOrEmpty(ddlSubject_G.SelectedValue))
            {
                objInfo.SubjectID = -1;
            }
            else
            {
                objInfo.SubjectID = int.Parse(ddlSubject_G.SelectedValue);
            }
            objInfo.Title = txtTitle_G.Text;
            DateTime startDate = DateTime.ParseExact(txtStartDate_G.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objInfo.StartDate = startDate;
            objInfo.EndDate = startDate;
            if (String.IsNullOrEmpty(txtTimeStart_G.Text) == false)
            {
                Char delimiter = ':';
                String[] str = txtTimeStart_G.Text.Split(delimiter);
                objInfo.StartDate = objInfo.StartDate.AddHours(Double.Parse(str[0]));
                objInfo.StartDate = objInfo.StartDate.AddMinutes(Double.Parse(str[1]));
            }
            if (String.IsNullOrEmpty(txtTimeEnd_G.Text) == false)
            {
                Char delimiter = ':';
                String[] str = txtTimeEnd_G.Text.Split(delimiter);
                objInfo.EndDate = objInfo.EndDate.AddHours(Double.Parse(str[0]));
                objInfo.EndDate = objInfo.EndDate.AddMinutes(Double.Parse(str[1]));
            }
            objInfo.Description = txtDescription_G.Text;
            objInfo.Location = txtLocation_G.Text;
            objInfo.Organizer = txtOrganizer_G.Text;
            objInfo.Participant = txtParticipant_G.Text;
            objInfo.Preparation = txtPreparation_G.Text;
            objInfo.IsDone = chkIsDone_G.Checked;
            objInfo.IsImportant = chkIsImportant_G.Checked;
            UserExtension_DTO objUsserInfo = (UserExtension_DTO)Session["UserLogin"];
            objInfo.ModifyBy = objUsserInfo.UserName;
            objInfo.CreatedBy = objUsserInfo.UserName;
            GeneralEvent_BAL objImpl = new GeneralEvent_BAL();
            var data_path = "/assets/global/event/";

            if (GeneralEventID > 0)
            {
            }
            else
            {
                if (rdoRecurrenceNone_G.Checked)
                {
                    GeneralEventID = objImpl.Insert(objInfo);
                    if (fileAttachments.PostedFile != null && fileAttachments.FileName.Length > 0)
                    {
                        if (!Directory.Exists(Server.MapPath(data_path)))
                        {
                            Directory.CreateDirectory(Server.MapPath(data_path));
                        }
                        EventFile_BAL objEventFile_BAL = new EventFile_BAL();
                        foreach (HttpPostedFile postedFile in fileAttachments.PostedFiles)
                        {
                            string fileNameImage = Guid.NewGuid().ToString() + Path.GetExtension(postedFile.FileName.ToLower());
                            postedFile.SaveAs(Server.MapPath(data_path + fileNameImage));
                            EventFile_DTO objEventFile_DTO = new EventFile_DTO();
                            objEventFile_DTO.GeneralEventID = GeneralEventID;
                            objEventFile_DTO.FileName = postedFile.FileName.ToLower();
                            objEventFile_DTO.FilePath = fileNameImage;
                            objEventFile_DTO.FileSize = postedFile.ContentLength;
                            objEventFile_BAL.Insert(objEventFile_DTO);
                        }
                    }
                }
                if (rdoRecurrencePeriodic_G.Checked)
                {
                    int PeriodicAmount = int.Parse(txtPeriodicAmount_G.Text);
                    string PeriodicCode = ddlPeriodicCode_G.SelectedValue;
                    DateTime RecurrenceStartDate = DateTime.ParseExact(txtRecurrenceStartDate_G.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime RecurrenceEndDate = DateTime.ParseExact(txtRecurrenceEndDate_G.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    int OriginalEventID = -1;
                    while (DayDifference(RecurrenceStartDate, RecurrenceEndDate) < 0)
                    {
                        objInfo.OriginalEventID = OriginalEventID;
                        objInfo.StartDate = RecurrenceStartDate;
                        objInfo.EndDate = RecurrenceStartDate;
                        if (String.IsNullOrEmpty(txtTimeStart_G.Text) == false)
                        {
                            Char delimiter = ':';
                            String[] str = txtTimeStart_G.Text.Split(delimiter);
                            objInfo.StartDate = objInfo.StartDate.AddHours(Double.Parse(str[0]));
                            objInfo.StartDate = objInfo.StartDate.AddMinutes(Double.Parse(str[1]));
                        }
                        if (String.IsNullOrEmpty(txtTimeEnd_G.Text) == false)
                        {
                            Char delimiter = ':';
                            String[] str = txtTimeEnd_G.Text.Split(delimiter);
                            objInfo.EndDate = objInfo.EndDate.AddHours(Double.Parse(str[0]));
                            objInfo.EndDate = objInfo.EndDate.AddMinutes(Double.Parse(str[1]));
                        }
                        int id = objImpl.Insert(objInfo);
                        if (OriginalEventID == -1)
                        {
                            OriginalEventID = id;
                        }
                        switch (PeriodicCode)
                        {
                            case "d":
                                RecurrenceStartDate = RecurrenceStartDate.AddDays(PeriodicAmount);
                                break;

                            case "w":
                                RecurrenceStartDate = RecurrenceStartDate.AddDays(PeriodicAmount * 7);
                                break;

                            case "m":
                                RecurrenceStartDate = RecurrenceStartDate.AddMonths(PeriodicAmount);
                                break;

                            case "y":
                                RecurrenceStartDate = RecurrenceStartDate.AddYears(PeriodicAmount);
                                break;

                            default:
                                RecurrenceStartDate = RecurrenceEndDate;
                                break;
                        }
                    }
                }
                if (rdoRecurrenceMonthlyActual_G.Checked)
                {
                    int ActualMonthlyDay = int.Parse(ddlActualMonthlyDay_G.SelectedValue);
                    DateTime RecurrenceStartDate = DateTime.ParseExact(txtRecurrenceStartDate_G.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime RecurrenceEndDate = DateTime.ParseExact(txtRecurrenceEndDate_G.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    int day = ActualMonthlyDay - RecurrenceStartDate.Day;
                    RecurrenceStartDate = RecurrenceStartDate.AddDays(day);
                    int OriginalEventID = -1;
                    while (DayDifference(RecurrenceStartDate, RecurrenceEndDate) < 0)
                    {
                        objInfo.OriginalEventID = OriginalEventID;
                        objInfo.StartDate = RecurrenceStartDate;
                        objInfo.EndDate = RecurrenceStartDate;
                        if (String.IsNullOrEmpty(txtTimeStart_G.Text) == false)
                        {
                            Char delimiter = ':';
                            String[] str = txtTimeStart_G.Text.Split(delimiter);
                            objInfo.StartDate = objInfo.StartDate.AddHours(Double.Parse(str[0]));
                            objInfo.StartDate = objInfo.StartDate.AddMinutes(Double.Parse(str[1]));
                        }
                        if (String.IsNullOrEmpty(txtTimeEnd_G.Text) == false)
                        {
                            Char delimiter = ':';
                            String[] str = txtTimeEnd_G.Text.Split(delimiter);
                            objInfo.EndDate = objInfo.EndDate.AddHours(Double.Parse(str[0]));
                            objInfo.EndDate = objInfo.EndDate.AddMinutes(Double.Parse(str[1]));
                        }
                        RecurrenceStartDate = RecurrenceStartDate.AddMonths(1);
                        int id = objImpl.Insert(objInfo);
                        if (OriginalEventID == -1)
                        {
                            OriginalEventID = id;
                        }
                    }
                }
            }
        }
    }
}