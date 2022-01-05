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
    [RoutePrefix("api/Requests")]
    public class RequestsController : ApiController
    {
        [HttpGet]
        [Route("GetAllRequest")]
        //פונקציה המחזירה את כל הפניות
        public IHttpActionResult GetAllRequest()
        {
            return Ok(RequestsBLL.GetAllRequests());
        }
        [HttpPost]
        [Route("AddRequest")]
        //פונקציה המוסיפה פנייה
        public IHttpActionResult AddRequest(RequestsDTO request)
        {
            return Ok(RequestsBLL.AddRequest(request));
        }
        [HttpGet]
        [Route("GetRequestByTz/{tz}")]
        //פונקציה המחזירה פניה של פצינט מסוים
        public IHttpActionResult GetRequestByTz(int tz)
        {
            return Ok(RequestsBLL.GetRequestByTz(tz));
        }
        //פוקציה המעדכנת פניה
        [HttpPut]
        [Route("UpdateRequest")]
        public IHttpActionResult UpdateRequest(RequestsDTO r)
        {
            return Ok(RequestsBLL.UpdateRequest(r));
        }

    }
}
