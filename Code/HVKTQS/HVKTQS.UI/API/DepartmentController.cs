using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HVKTQS.Model.Models;
using HVKTQS.Service;
using HVKTQS.UI.Infrastructure.Core;
using HVKTQS.UI.Models;
using HVKTQS.UI.Infrastructure.Extensions;
using System.Web.Script.Serialization;

namespace HVKTQS.UI.Api
{
    [RoutePrefix("api/department")]
    //[Authorize]
    public class DepartmentController : ApiControllerBase
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IErrorService errorService, IDepartmentService departmentService) :
            base(errorService)
        {
            this._departmentService = departmentService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int departmentID)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _departmentService.GetById(departmentID);

                var responseData = Mapper.Map<List<DepartmentViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _departmentService.GetAll();

                var responseData = Mapper.Map<List<DepartmentViewModel>>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, DepartmentViewModel departmentVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Department newDepartment = new Department();
                    newDepartment.UpdateDepartment(departmentVm);

                    var responseData = _departmentService.Add(newDepartment);
                    _departmentService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, DepartmentViewModel departmentVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var departmentDb = _departmentService.GetById(departmentVm.DepartmentID);
                    departmentDb.UpdateDepartment(departmentVm);
                    _departmentService.Update(departmentDb);
                    _departmentService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int departmentID)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _departmentService.Delete(departmentID);
                    _departmentService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedDepartment)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listDepartment = new JavaScriptSerializer().Deserialize<List<int>>(checkedDepartment);
                    foreach (var item in listDepartment)
                    {
                        _departmentService.Delete(item);
                    }

                    _departmentService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listDepartment.Count);
                }

                return response;
            });
        }
    }
}