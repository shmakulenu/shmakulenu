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
    [RoutePrefix("api/Cities")]
    public class CitiesController : ApiController
    {
        [HttpGet]
        [Route("GetAllCities")]
        public IHttpActionResult GetAllCities()
        {
            return Ok(CitiesBLL.GetAllCities());
        }
        [HttpPost]
        [Route("AddCity")]
        public IHttpActionResult AddCity(CitiesDTO c)
        {
            return Ok(CitiesBLL.AddCity(c));
        }
    }
}
