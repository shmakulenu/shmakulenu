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
    [RoutePrefix("api/Snifim")]
    public class SnifimController : ApiController
    {
        //פונקציה המחזירה את כל שמות הסניפים
        [HttpGet]        
        [Route("GetAllSnifim")]
        public IHttpActionResult GetAllSnifim()
        {
            return Ok(SnifimBLL.GetAllSnifim());
        }
        [HttpGet]
        [Route("GetSnifIdByCityName/{cityName}")]
        //פונקציה המתזירה  סניף על פי שם עיר 
        public IHttpActionResult GetSnifIdByCityName(string cityName)
        {
            return Ok(SnifimBLL.GetSnifIdByCityName(cityName));
        }
    }
}
