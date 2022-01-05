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
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            return Ok(UserBLL.GetAllUsers());
        }
        [HttpGet]
        [Route("GetUsersByCityId/{cityId}")]
        public IHttpActionResult GetUsersByCityId(int cityId)
        {
            return Ok(UserBLL.GetUsersByCityId(cityId));
        }
        [HttpPost]
        [Route("AddUser")]
        //למה מחזיר פאלס
        //פונקציה המקבלת אוביקט עובד ומוסיפה אותו לדטה בייס
        public IHttpActionResult AddUser(UserDTO u)
        {
            return Ok(UserBLL.AddUser(u));
        }
        [HttpPut]
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser(UserDTO u)
        {
            return Ok(UserBLL.UpdateUser(u));
        }
        [HttpDelete]
        //למה מחזיר פאלס
        [Route("DeleteUser")]
        public IHttpActionResult DeleteUser(UserDTO u)
        {
            return Ok(UserBLL.DeleteUser(u));
        }
        [HttpGet]
        [Route("GetUserByNameAndPassword/{password}/{name}")]
        public IHttpActionResult GetUserByNameAndPassword(int password, string name)
        {
            return Ok(UserBLL.GetUserByNameAndPassword(password, name));
        }
        [HttpGet]
        [Route("GetAllUsersStatus")]
       // פונקציה המחזירה את כל  סטטוס העובדים
        public IHttpActionResult GetAllUsersStatus()
        {
            return Ok(UserBLL.GetAllUsersStatus());
        }

    }
}
