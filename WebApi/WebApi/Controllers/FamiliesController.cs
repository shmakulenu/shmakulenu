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
    [RoutePrefix("api/Families")]
    public class FamiliesController : ApiController
    {
       
        [HttpGet]
        [Route("GetFamilyByParentTz/{tz}")]
        // פונקציה המקבלת תז של הורה ומחזירה משפחה
        public IHttpActionResult GetFamilyByParentTz(int tz)
        {
            return Ok(FamiliesBLL.GetFamilyByParentTz(tz));
        }
        
        [HttpGet]
        [Route("GetFamilyIdByTell/{tell}")]
        // פונקציה המחזירה קוד משפחה עפ"י מס טלפון
        // אם חוזר 0 הכוונה לנאל
        public IHttpActionResult GetFamilyIdByTell(string tell)
        {
            return Ok(FamiliesBLL.GetFamilyIdByTell(tell));
        }
        [HttpGet]
        [Route("GellAllFamilies")]
        //פונקציה המחזירה את כל המשפחות
        public IHttpActionResult GellAllFamilies()
        {
            return Ok(FamiliesBLL.GellAllFamilies());
        }
        [HttpPut]
        [Route("UpdateFamily")]
        // פונקציה המעדכנת פרטי משפחה
        public IHttpActionResult UpdateFamily(FamiliesDTO f)
        {
            return Ok(FamiliesBLL.UpdateFamily(f));
        }
        [HttpPost]
        [Route("AddFamily")]
        //פונקציה המוסיפה משפחה
        public IHttpActionResult AddFamily(FamiliesDTO f)
        {
            return Ok(FamiliesBLL.AddFamily(f));
        }
        }
}
