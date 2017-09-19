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
    [RoutePrefix("api/subject")]
    //[Authorize]
    public class SubjectController : ApiControllerBase
    {
        private ISubjectService _subjectService;

        public SubjectController(IErrorService errorService, ISubjectService subjectService) :
            base(errorService)
        {
            this._subjectService = subjectService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int SubjectID)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _subjectService.GetById(SubjectID);

                var responseData = Mapper.Map<List<SubjectViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _subjectService.GetAll();

                var responseData = Mapper.Map<List<SubjectViewModel>>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, SubjectViewModel SubjectVm)
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
                    Subject newSubject = new Subject();
                    newSubject.UpdateSubject(SubjectVm);

                    var responseData = _subjectService.Add(newSubject);
                    _subjectService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, SubjectViewModel SubjectVm)
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
                    var SubjectDb = _subjectService.GetById(SubjectVm.SubjectID);
                    SubjectDb.UpdateSubject(SubjectVm);
                    _subjectService.Update(SubjectDb);
                    _subjectService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int SubjectID)
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
                    _subjectService.Delete(SubjectID);
                    _subjectService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedSubject)
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
                    var listSubject = new JavaScriptSerializer().Deserialize<List<int>>(checkedSubject);
                    foreach (var item in listSubject)
                    {
                        _subjectService.Delete(item);
                    }

                    _subjectService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listSubject.Count);
                }

                return response;
            });
        }
    }
}