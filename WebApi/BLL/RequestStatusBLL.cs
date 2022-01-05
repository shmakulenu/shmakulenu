using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace BLL
{
    public class RequestStatusBLL
    {
        //פונקציה המחזירה את כל הפניות
        public static List<RequestStatusDTO> GetAllRequestStatus()
        {
            return RequestStatusDAL.GetAllRequestStatus();
        }

    }
}
