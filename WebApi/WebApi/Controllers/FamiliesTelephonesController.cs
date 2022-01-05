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
    [RoutePrefix("api/FamilyTelephones")]
    public class FamiliesTelephonesController : ApiController
    {
        [HttpGet]
        [Route("GetTellByFamilyId/{id}")]
        //פונקציה המחזירה טל לפי תז
        public IHttpActionResult GetTellByFamilyId(int id)
        {
            return Ok(FamiliesTelephonesBLL.GetTellByFamilyId(id));
        }
        [HttpPut]
        [Route("UpdateFamilyTell")]
        //פונקציה המעדכנת מספר טל למשפחה
       //לא נכן להשתמש בפונקציה זו אלא במחיקה והוספה
        public IHttpActionResult UpdateFamilyTell(FamilyTelephonesDTO ft)
        {
            return Ok(FamiliesTelephonesBLL.UpdateFamilyTell(ft));
        }
    }
}
