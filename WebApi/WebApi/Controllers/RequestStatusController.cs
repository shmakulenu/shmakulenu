using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RequestStatus")]
    public class RequestStatusController : ApiController
    {
        [HttpGet]
        [Route("GetAllRequestStatus")]
        public IHttpActionResult GetAllRequestStatus()
        {
            return Ok(RequestStatusBLL.GetAllRequestStatus());
        }
    }
}
