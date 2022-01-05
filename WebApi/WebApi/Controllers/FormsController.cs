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
    [RoutePrefix("api/Forms")]
    public class FormsController : ApiController
    {
        //לבדוק
        [HttpGet]
        [Route("GetFormsByZakautId/{zakautId}")]
        // פונקציה המחזירה מערך ניתוב קבצים עפ"י קוד זכאות
        public IHttpActionResult GetFormsByZakautId(int zakautId)
        {
            return Ok(FormsBLL.GetFormsByZakautId(zakautId));
        }
        [HttpPost]
        [Route("AddForm")]
        //פונקציה המוסיפה טופס
        public IHttpActionResult AddForm(FormsDTO f)
        {
            return Ok(FormsBLL.AddForm(f));
        }
        [HttpPut]
        [Route("UpdateForm")]
        //פונקציה המעדכנת טופס
        public IHttpActionResult UpdateForm(FormsDTO f)
        {
            return Ok(FormsBLL.UpdateForm(f));
        }
        [HttpGet]
        [Route("GetFormById/{id}")]
        //פונקציה המחזירה טופס לפי קוד טופס
        public IHttpActionResult GetFormById(int id)
        {
            return Ok(FormsBLL.GetFormById(id));
        }
        }
}
