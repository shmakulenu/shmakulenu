using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace DAL.EFConvert
{
    public class RequestStatusConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static RequestStatusDTO ConvertToRequestStatusDTO(RequestStatus r)
        {
            if (r == null)
                return null;
            RequestStatusDTO request = new RequestStatusDTO()
            {
                StatusId=r.StatusId,
                Describe=r.Describe,
            };
            return request;
        }
        //המרה הפוכה
        public static RequestStatus ConvertToRequestStatusDAL(RequestStatusDTO r)
        {
            if (r == null)
                return null;
            RequestStatus request = new RequestStatus()
            {
                StatusId = r.StatusId,
                Describe = r.Describe,
            };
            return request;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<RequestStatusDTO> ConvertToRequestStatusDTOList(List<RequestStatus> list)
        {
            List<RequestStatusDTO> listRequestStatus = new List<RequestStatusDTO>();
            foreach (var item in list)
            {
                listRequestStatus.Add(ConvertToRequestStatusDTO(item));
            }
            return listRequestStatus;
        }
        //המרה הפוכה
        public static List<RequestStatus> ConvertToRequestStatusDALList(List<RequestStatusDTO> list)
        {
            List<RequestStatus> listRequestStatus = new List<RequestStatus>();
            foreach (var item in list)
            {
                listRequestStatus.Add(ConvertToRequestStatusDAL(item));
            }
            return listRequestStatus;
        }
    }
    
}
