using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace DAL.ConvertEF
{
    public class RequestsConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static RequestsDTO ConvertToRequestDTO(Requests r)
        {
            if (r == null)
                return null;
            RequestsDTO request = new RequestsDTO()
            {

                Patient_tz = r.Patient_tz,
                Request__reaon = r.Request__reaon,
                StatusId = r.StatusId,
                Summary = r.Summary,
                Date = r.Date,
                Intek_date = (System.DateTime?)r.Intek_date,
                Notes = r.Notes,
                Talking1 = r.Talking1,
                Talking1_date = r.Talking1_date,
                Talking2 = r.Talking2,
                Talking2_date = r.Talking2_date,
                NumKlinait = r.NumKlinait,
                StatusName = (r.RequestStatus != null) ? r.RequestStatus.Describe : "",
                
            };
            return request;
        }
        //המרה הפוכה
        public static Requests ConvertToRequestDal(RequestsDTO r)
        {
            if (r == null)
                return null;
            Requests request = new Requests()
            {
                Patient_tz = r.Patient_tz,
                Request__reaon = r.Request__reaon,
                StatusId = r.StatusId,
                Summary = r.Summary,
                Date = r.Date,
                Intek_date = r.Intek_date,
                Notes = r.Notes,
                Talking1 = r.Talking1,
                Talking1_date = r.Talking1_date,
                Talking2 = r.Talking2,
                Talking2_date = r.Talking2_date,
                NumKlinait=r.NumKlinait,
                
            };
            return request;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<RequestsDTO> ConvertToRequestsDTOList(List<Requests> list)
        {
            List<RequestsDTO> listRequests = new List<RequestsDTO>();
            foreach (var item in list)
            {
                listRequests.Add(ConvertToRequestDTO(item));
            }
            return listRequests;
        }
        //המרה הפוכה
        public static List<Requests> ConvertToCitiesDALList(List<RequestsDTO> list)
        {
            List<Requests> listRequests = new List<Requests>();
            foreach (var item in list)
            {
                listRequests.Add(ConvertToRequestDal(item));
            }
            return listRequests;
        }
    }
}
