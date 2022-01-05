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
    [RoutePrefix("api/KupatCholim")]
    public class KupatCholimController : ApiController
    {
        [HttpGet]
        [Route("GetAllKuputCholim")]
        // פונקציה המחזירה את כל קופות החולים
        public IHttpActionResult GetAllKuputCholim()
        {
            return Ok(KupatCholimBLL.GetAllKuputCholim());
        }

    }
}
