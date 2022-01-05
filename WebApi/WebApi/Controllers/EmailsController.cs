using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApi.Controllers
{
    public class EmailsController : ApiController
    {
        //מה זה יש בקונטרולר הזה צורך?
        [HttpPost]
        [Route("api/Emails/SendMail/")]
        public IHttpActionResult SendMail([FromBody] DTO.EmailDetails EmailDetails)
        {
            //EmailsBLL.SendMail(EmailDetails);
            List<Asapim> l = new List<Asapim>();
            EmailsBLL.sendEmailsToSnifim(l);
            return Ok();
        }
    }
}
//    //לזכור לשנות את ההגדרת אבטחה של החשבון בכתובת הזו
//    // https://www.google.com/settings/security/lesssecureapps
//    var fromAddress = new MailAddress(EmailDetails.EAddressSend, EmailDetails.ENameSend);
//    var toAddress = new MailAddress(EmailDetails.EAddressGet, EmailDetails.ENameGet);
//    const string fromPassword = "gur2021gur";
//    const string subject = "Subject";
//    //SendMail() משתנה זה הוא מלל המייל צריך לקבלו בפונקציה
//    const string body = "Body";

//    var smtp = new SmtpClient
//    {
//        Host = "smtp.gmail.com",
//        Port = 587,
//        EnableSsl = true,
//        DeliveryMethod = SmtpDeliveryMethod.Network,
//        UseDefaultCredentials = false,
//        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
//    };
//            using (var message = new MailMessage(fromAddress, toAddress)
//    {
//        Subject = subject,
//                Body = body
//            })
//            {
//                smtp.Send(message);
//            }
//return Ok();

