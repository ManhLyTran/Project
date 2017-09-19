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
    [RoutePrefix("api/position")]
    //[Authorize]
    public class PositionController : ApiControllerBase
    {
        private IPositionService _positionService;

        public PositionController(IErrorService errorService, IPositionService positionService) :
            base(errorService)
        {
            this._positionService = positionService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int PositionID)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _positionService.GetById(PositionID);

                var responseData = Mapper.Map<List<PositionViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _positionService.GetAll();

                var responseData = Mapper.Map<List<PositionViewModel>>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PositionViewModel PositionVm)
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
                    Position newPosition = new Position();
                    newPosition.UpdatePosition(PositionVm);

                    var responseData = _positionService.Add(newPosition);
                    _positionService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PositionViewModel PositionVm)
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
                    var PositionDb = _positionService.GetById(PositionVm.PositionID);
                    PositionDb.UpdatePosition(PositionVm);
                    _positionService.Update(PositionDb);
                    _positionService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int PositionID)
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
                    _positionService.Delete(PositionID);
                    _positionService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedPosition)
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
                    var listPosition = new JavaScriptSerializer().Deserialize<List<int>>(checkedPosition);
                    foreach (var item in listPosition)
                    {
                        _positionService.Delete(item);
                    }

                    _positionService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listPosition.Count);
                }

                return response;
            });
        }
    }
}