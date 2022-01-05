using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL;
using DTO;
using System.Net;
using System.Net.Mail;

namespace BLL
{
    public class EmailsBLL
    {
        public static string AddressSend = "sk0556729932@gmail.com";
        public static string NameSend = "מכון שמע קולינו";
        public static void SendMail(EmailDetails EmailDetails)
        {
            //לזכור לשנות את ההגדרת אבטחה של החשבון בכתובת הזו
            //https://www.google.com/settings/security/lesssecureapps
            //var fromAddress = new MailAddress("gur.programing.2021@gmail.com", "from name");
            //var toAddress = new MailAddress("comp.gur@gmail.com", "to name");

            var fromAddress = new MailAddress(EmailDetails.EAddressSend, EmailDetails.ENameSend);
            var toAddress = new MailAddress(EmailDetails.EAddressGet, EmailDetails.ENameGet);
            //const string fromPassword = "gur2021gur";
            const string fromPassword = "Aa123123!!";
            string subject = EmailDetails.Subject;
            //SendMail() משתנה זה הוא מלל המייל צריך לקבלו בפונקציה
            string body = EmailDetails.Body;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body,
            //})
            //{
            var message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            if (!string.IsNullOrEmpty(EmailDetails.FileName))
            {
                Attachment attachment = new Attachment(EmailDetails.FileName);
                message.Attachments.Add(attachment);
            }
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            //}

        }
        public static void sendEmailsToSnifim(List<Asapim> list)
        {
            var arrAllSnifim = SnifimDAL.GetAllSnifim();
            EmailDetails EmailDetails = new EmailDetails();
            //שליחת מיילים מתבצעת מהחשבון הכללי של שמע קולינו תמיד
            EmailDetails.EAddressSend = AddressSend;
            EmailDetails.ENameSend = NameSend;
            EmailDetails.Subject = "תלמידים חדשים";
            //SendMail(EmailDetails);
            //צריך לדבג
            for (int i = 0; i < arrAllSnifim.Count(); i++)
            {
                List<Asapim> snifList = filterListBySnifName(list, arrAllSnifim[i].SnifName);
                if (snifList.Count() > 0)
                {
                    //כאן צריך לערוך את המשתנים של המייל לדוגמא שם השולח ושם המקבל ו כן למי לשלוח 
                    EmailDetails.Body = ReadAsapimExcel.ToString(snifList);
                    EmailDetails.EAddressGet = arrAllSnifim[i].Mail;
                    EmailDetails.ENameGet = arrAllSnifim[i].SnifName;
                    SendMail(EmailDetails);
                }
            }
        }
        public static List<Asapim> filterListBySnifName(List<Asapim> allList, string snifName)
        {
            return allList.Where(a => a.SnifName.Equals(snifName)).ToList();
        }
    }
}
