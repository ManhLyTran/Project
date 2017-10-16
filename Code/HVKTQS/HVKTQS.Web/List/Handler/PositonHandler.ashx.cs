using HVKTQS.BAL;
using HVKTQS.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HVKTQS.Web.List.Handler
{
    /// <summary>
    /// Summary description for PositonHandler
    /// </summary>
    public class PositonHandler : IHttpHandler
    {
        private string MethodName = string.Empty;
        private Position_BAL objImpl = new Position_BAL();

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (((context.Request.IsAuthenticated == false) || (string.IsNullOrEmpty(context.User.Identity.Name))))
            {
                //context.Response.Redirect("~/Account/Login");
            }
            MethodName = context.Request.Params["fn"];
            switch (MethodName)
            {
                case "AddUpdate":
                    AddUpdate();
                    break;

                case "UpdateViewOrderInBatches":
                    UpdateViewOrderInBatches();
                    break;

                case "DeleteByID":
                    DeleteByID();
                    break;

                case "GetByIDCache":
                    GetByID();
                    break;

                case "GetHTML":
                    GetHTML();
                    break;
            }
        }

        private void AddUpdate()
        {
            string strJson = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
            Position_DTO objInfo = JsonConvert.DeserializeObject<Position_DTO>(strJson);
            int result = 0;
            ResponseResult objResponse = new ResponseResult();
            if ((objInfo != null))
            {
                if ((objInfo.PositionID < 1))
                {
                    result = objImpl.Insert(objInfo);
                    objResponse.d = Convert.ToString(result);
                    objResponse.msg = "Thêm mới thành công!";
                    objResponse.hasExecuted = true;
                    objResponse.c = 1;
                }
                else
                {
                    result = objImpl.Update(objInfo);
                    objResponse.d = Convert.ToString(result);
                    objResponse.msg = "Sửa thành công!";
                    objResponse.hasExecuted = true;
                    objResponse.c = 1;
                }
            }
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(objResponse));
            HttpContext.Current.Response.End();
        }

        private void UpdateViewOrderInBatches()
        {
            string strPositionID = "";
            if ((HttpContext.Current.Request.Params["strPositionID"] != null))
            {
                strPositionID = HttpContext.Current.Request.Params["strPositionID"].ToString();
            }

            int result = 0;
            ResponseResult objResponse = new ResponseResult();
            result = objImpl.UpdateViewOrderInBatches(strPositionID);
            objResponse.d = Convert.ToString(result);
            if ((result > 0))
            {
                objResponse.msg = "Lưu thứ tự xem thành công!";
                objResponse.hasExecuted = true;
            }
            else
            {
                objResponse.msg = "Lưu thứ tự xem thất bại!";
                objResponse.hasExecuted = false;
            }
            objResponse.c = result;

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(objResponse));
            HttpContext.Current.Response.End();
        }

        private void DeleteByID()
        {
            int PositionID = 0;
            if ((HttpContext.Current.Request.Params["PositionID"] != null))
            {
                PositionID = Convert.ToInt32(HttpContext.Current.Request.Params["PositionID"]);
            }

            ResponseResult objResponse = new ResponseResult();

            // kiểm tra xóa
            if ((objImpl.CanDelete(PositionID) == true))
            {
                int result = objImpl.DeleteByID(PositionID);
                objResponse.d = Convert.ToString(result);
                objResponse.msg = "Xóa thành công!";
                objResponse.hasExecuted = true;
                objResponse.c = 1;
            }
            else
            {
                objResponse.d = string.Empty;
                objResponse.msg = "Xóa thất bại!";
                objResponse.hasExecuted = false;
                objResponse.c = 0;
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(objResponse));
            HttpContext.Current.Response.End();
        }

        private void GetByID()
        {
            int positionID = 0;
            if ((HttpContext.Current.Request.Params["PositionID"] != null))
            {
                positionID = Convert.ToInt32(HttpContext.Current.Request.Params["PositionID"]);
            }

            ResponseResult objResponse = new ResponseResult();
            objResponse.d = JsonConvert.SerializeObject(objImpl.GetObject(positionID));

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(objResponse));
            HttpContext.Current.Response.End();
        }

        private void GetHTML()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/plain";
            HttpContext.Current.Response.Write(objImpl.GetHTML());
            HttpContext.Current.Response.End();
        }
    }
}