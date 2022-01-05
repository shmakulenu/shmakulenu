using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.ConvertEF;
using DAL.EFConvert;

namespace DAL.Classes
{
    public class RequestsDAL
    {
        //פונקציה המחזירה את כל הפניות
        public static List<RequestsDTO> GetAllRequests()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return RequestsConvert.ConvertToRequestsDTOList(sk.Requests.ToList());
            }
        }
        //פונקציה המוסיפה פנייה
        public static bool AddRequest(RequestsDTO request)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                try
                {
                    sk.Requests.Add(RequestsConvert.ConvertToRequestDal(request));
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        //פונקציה המחזירה פניה של פצינט מסוים
        public static RequestsDTO GetRequestByTz(int tz)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                Requests r = (from requests in sk.Requests
                              where requests.Patient_tz == tz
                              select requests).FirstOrDefault();
                return RequestsConvert.ConvertToRequestDTO(r);
            }    
        }
        //פונקציה המעדכנת פניה
        public static bool UpdateRequest(RequestsDTO rToEdit)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
               
                Requests request = sk.Requests.Where( r=> r.Patient_tz == rToEdit.Patient_tz).FirstOrDefault();
                if (request != null)
                {
                    request.Date = rToEdit.Date;
                    request.Intek_date = rToEdit.Intek_date;
                    request.StatusId= rToEdit.StatusId;
                    request.Request__reaon = rToEdit.Request__reaon;
                    request.Summary = rToEdit.Summary;
                    request.Talking1= rToEdit.Talking1;
                    request.Talking1_date= request.Talking1_date;
                    request.Talking2 = rToEdit.Talking2;
                    request.Talking2_date = request.Talking2_date;
                    request.Notes = rToEdit.Notes;
                    request.NumKlinait = rToEdit.NumKlinait;    
                }
                try
                {
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

    }
}
