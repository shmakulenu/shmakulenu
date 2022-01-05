using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
using System.IO;


namespace WebApi.Controllers
{
    [RoutePrefix("api/Tested")]
    public class TestedController : ApiController
    {

        [HttpPost]
        [Route("AddTest")]
        //פונקציה המוסיפה בדיקה לפצינט חדש שלא עשה בדיקה בשמע קולינו
        public IHttpActionResult AddTest(List<string> detailes)
        {
            try
            {
                return Ok(TestedBLL.AddTest(int.Parse(detailes[0]), detailes[1]));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //const string FILE_PATH = @"F:\פרויקט\Files\";

        [HttpPost]
        [Route("AddFile")]
        public IHttpActionResult Post([FromBody] FileToUpload theFile)
        {
            try
            {
                return Ok(TestedBLL.AddFile(theFile));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //var filePathName = FILE_PATH + Path.GetFileNameWithoutExtension(theFile.FileName) + "-" +
            //    DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") +
            //    Path.GetExtension(theFile.FileName);
            //if (theFile.FileAsBase64.Contains(","))
            //{
            //    theFile.FileAsBase64 = theFile.FileAsBase64.Substring(theFile.FileAsBase64.IndexOf(",") + 1);
            //}

            //using (var fs = new FileStream(filePathName, FileMode.CreateNew))
            //{
            //    fs.Write(Convert.FromBase64String(theFile.FileAsBase64), 0, Convert.FromBase64String(theFile.FileAsBase64).Length);
            //}
            //return Ok(filePathName);
        }
    }

}
