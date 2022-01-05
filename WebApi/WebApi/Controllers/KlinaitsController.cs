using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
namespace WebApi.Controllers
{
    [RoutePrefix("api/Klinaits")]
    public class KlinaitsController : ApiController
    {
        [HttpGet]
        [Route("GetAllKlinaits")]
        //הקלניות פונקציה המחזירה את כל 
        public IHttpActionResult GetAllKlinaits()
        {
            return Ok(KlinaitsBLL.GetAllKlinaits());
        }
        [HttpPost]
        [Route("SendMailToKlinaitAndPatient")]
        //פונקציה ששולחת מיילים לקלינאית ולתלמיד
        public IHttpActionResult SendMailToKlinaitAndPatient(List<string> implementations)
        {
            KlinaitsBLL.SendMailToKlinaitAndPatient(int.Parse(implementations[0]),implementations[1]);
            return Ok();
        }

    }   
}
