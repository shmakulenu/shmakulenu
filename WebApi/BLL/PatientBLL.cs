using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace BLL
{
    public class PatientBLL
    {
        //פונקציה המחזירה את כל הפציינטים
        public static List<PatientsDTO> GetAllPatient()
        {
            return PatientDAL.GetAllPatient();
        }
        //פונקציה המחזירה את כל הפציינטים שהסטטוס פניה שלהם הוא...
        public static List<PatientsDTO> GetAllPatientByStatus(int statusId)
        {
            return PatientDAL.GetAllPatientByStatus(statusId);
        }
        //פונקציה המקבלת סניף ומחזירה פציינטים של סניף זה       
        public static List<PatientsDTO> GetPatientsByStatusAndSnif(int snifId, int statusId)
        {
            return PatientDAL.GetPatientsByStatusAndSnif(snifId, statusId);
        }
        //פונקציה המחזירה פציינט על פי תעודת זהות 
        public static PatientsDTO GetPatientsByTz(int tz)
        {
            return PatientDAL.GetPatientsByTz(tz);
        }
        //פונקציה ששולחת מייל טפסים לתלמיד
        public static void SendFormsMailToPatient(int tz, string form, string fileName)
        {
            PatientsDTO patient = PatientDAL.GetPatientsByTz(tz);
            EmailDetails EmailDetails = new EmailDetails();
            //שליחת מיילים מתבצעת מהחשבון הכללי של שמע קולינו תמיד
            EmailDetails.EAddressSend = "sk0556729932@gmail.com";
            EmailDetails.ENameSend = "שמעקו";
            EmailDetails.EAddressGet = patient.Mail;
            EmailDetails.ENameGet = patient.First_name + " " + patient.LastName;
            //אפשר לערוך את גוף המייל קצת יותר יפה
            EmailDetails.Body = form;
            EmailDetails.FileName = fileName;
            EmailDetails.Subject = "עידכון ממכון שמע קולינו";
            EmailsBLL.SendMail(EmailDetails);

        }
        //פונקציה המעדכנת פציינט
        public static bool UpdatePatient(PatientsDTO p)
        {
            return PatientDAL.UpdatePatient(p);
        }
        //פונקציה המוסיפה פציינט
        public static bool AddPatient(PatientsDTO p)
        {
            return PatientDAL.AddPatient(p);
        }
        //פונקציה המוחקת פציינט
        public static bool DeletePatient(PatientsDTO p)
        {
            return PatientDAL.DeletePatient(p);
        }

    }
}
