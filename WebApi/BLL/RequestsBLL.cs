using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;
namespace BLL
{
    public class RequestsBLL
    {
        //פונקציה המחזירה את כל הפניות
        public static List<RequestsDTO> GetAllRequests()
        {
            return RequestsDAL.GetAllRequests();
        }
        //פונקציה המוסיפה פנייה
        public static bool AddRequest(RequestsDTO request)
        {
            return RequestsDAL.AddRequest(request);
        }
        //פונקציה המחזירה פניה של פצינט מסוים
        public static RequestsDTO GetRequestByTz(int tz)
        {
            return RequestsDAL.GetRequestByTz(tz);
        }
        //פוקציה המעדכנת פניה
        public static bool UpdateRequest(RequestsDTO r)
        {
            return RequestsDAL.UpdateRequest(r);
        }

    }
}
