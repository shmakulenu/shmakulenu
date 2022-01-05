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
    [RoutePrefix("api/ReadExcel")]
    public class ReadExcelController : ApiController
    {
        [Route("Get")]
        public IHttpActionResult Get()
        {
         
            ReadAsapimExcel.ReadExcel();
            //הפונקציה חיבת להחזיר ערך בגלל ה-get?
            //ואם אני לא רוצה שהיא תחזיר ערך מה נעשה?
            return Ok();
        }

    }
}
