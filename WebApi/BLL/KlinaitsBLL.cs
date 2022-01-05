using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.ConvertEF;
using DAL.EFConvert;
using DTO;
namespace BLL
{
    public class KlinaitsBLL
    {
        //הקלניות פונקציה המחזירה את כל 
        public static List<KlinaitsDTO> GetAllKlinaits()
        {
                return KlinaitsDAL.GetAllKlinaits();

        }
        //פונקציה ששולחת מייל לקלינאת ולתלמיד
        public static void SendMailToKlinaitAndPatient(int tz, string link)
        {
            try
            {
                PatientsDTO patient = PatientDAL.GetPatientsByTz(tz);
                RequestsDTO request = RequestsDAL.GetRequestByTz(tz);
                KlinaitsDTO klinait = KlinaitsDAL.GetKlinaitByNum(request.NumKlinait);
                SendMailToKlinait(patient, klinait,link);
                SendMailToPatient(patient, klinait);
            }
            catch (Exception ex)
            {

            }
        }
        public static void SendMailToKlinait(PatientsDTO patient,KlinaitsDTO klinait,string link)
        {
            
                EmailDetails EmailDetails = new EmailDetails();
                //שליחת מיילים מתבצעת מהחשבון הכללי של שמע קולינו תמיד
                EmailDetails.EAddressSend = EmailsBLL.AddressSend;
                EmailDetails.ENameSend = EmailsBLL.NameSend;
                EmailDetails.EAddressGet = klinait.Mail;
                EmailDetails.ENameGet = klinait.Name;
                //אפשר ?לערוך את גוף המייל קצת יותר יפה
                EmailDetails.Body = link;
                EmailDetails.Subject = "תלמיד חדש עידכון ממכון שמע קולינו";
                EmailsBLL.SendMail(EmailDetails);
           
        }
        public static void SendMailToPatient(PatientsDTO patient,KlinaitsDTO klinait)
        {
           
                EmailDetails EmailDetails = new EmailDetails();
                //שליחת מיילים מתבצעת מהחשבון הכללי של שמע קולינו תמיד
                EmailDetails.EAddressSend = EmailsBLL.AddressSend;
                EmailDetails.ENameSend = EmailsBLL.NameSend;
                EmailDetails.EAddressGet = patient.Mail;
                EmailDetails.ENameGet = patient.First_name + " " + patient.LastName;
                //אפשר לערוך את גוף המייל קצת יותר יפה
                EmailDetails.Body = " הקלינאית::" + klinait.Name + " " + patient.RequestDate;
                EmailDetails.Subject = "עידכון ממכון שמע קולינו";
                EmailsBLL.SendMail(EmailDetails);
           
        }
    }
}
