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
    [RoutePrefix("api/Patients")]
    public class PatientsController : ApiController
    {
        [HttpGet]
        [Route("GetAllPatient")]
        //פונקציה המחזירה את כל הפציינטים
        public IHttpActionResult GetAllPatient()
        {
            return Ok(PatientBLL.GetAllPatient());
        }
        [HttpGet]
        [Route("GetAllPatientByStatus/{statusId}")]
        //פונקציה המחזירה את כל הפציינטים שהסטטוס פניה שלהם הוא...
        public IHttpActionResult GetAllPatientByStatus(int statusId)
        {
            return Ok(PatientBLL.GetAllPatientByStatus(statusId));
        }
        [HttpGet]
        [Route("GetPatientsByStatusAndSnif/{snifId}/{statusId}")]
        //פונקציה המקבלת סניף ומחזירה פציינטים של סניף זה
        public IHttpActionResult GetPatientsByStatusAndSnif(int snifId,int statusId)
        {
            return Ok(PatientBLL.GetPatientsByStatusAndSnif(snifId, statusId));
        }
        [HttpGet]
        [Route("GetPatientsByTz/{tz}")]
        //פונקציה המחזירה פציינט על פי תעודת זהות 
        public IHttpActionResult GetPatientsByTz(int tz)
        {
            return Ok(PatientBLL.GetPatientsByTz(tz));
        }
        [HttpPost]
        [Route("SendFormsMailToPatient")]
        //פונקציה ששולחת מייל טפסים לתלמיד
        public IHttpActionResult SendFormsMailToPatient(List<string> actions)
        {
            PatientBLL.SendFormsMailToPatient(int.Parse(actions[1]), actions[0],actions[2]);
            return Ok();
        }

        [HttpPut]
        [Route("UpdatePatient")]
        
        //פונקציה המעדכנת פציינט
        public IHttpActionResult UpdatePatient(PatientsDTO p)
        {
            return Ok(PatientBLL.UpdatePatient(p));
        }
        [HttpPost]
        [Route("AddPatient")]
        //פונקציה המוסיפה פציינט
        public IHttpActionResult AddPatient(PatientsDTO p)
        {
            return Ok(PatientBLL.AddPatient(p));
        }
        [HttpDelete]
        [Route("DeletePatient")]
        //מחזיר פאלס
        //פונקציה המוחקת פציינט
        public IHttpActionResult DeletePatient(PatientsDTO p)
        {
            return Ok(PatientBLL.DeletePatient(p));
        }
        }
}
