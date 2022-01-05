using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.EFConvert
{
    public class OfficesConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static OfficesDTO ConvertToOfficesDTO(Offices o)
        {
            if (o == null)
                return null;
            return new OfficesDTO()
            { 
                OfficeId=o.OfficeId,
                Office_Name=o.Office_Name
            };
        }
        //המרה הפוכה
        public static Offices ConvertToOfficesDal(OfficesDTO o)
        {
            if (o == null)
                return null;
            return new Offices()
            {
                OfficeId = o.OfficeId,
                Office_Name = o.Office_Name
            };
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<OfficesDTO> ConvertToOfficesDTOList(List<Offices> list)
        {
            List<OfficesDTO> listOffices = new List<OfficesDTO>();
            foreach (var item in list)
            {
                listOffices.Add(ConvertToOfficesDTO(item));
            }
            return listOffices;
        }
        //המרה הפוכה
        public static List<Offices> ConvertToOfficesDALList(List<OfficesDTO> list)
        {
            List<Offices> ListOffices = new List<Offices>();
            foreach (var item in list)
            {
                ListOffices.Add(ConvertToOfficesDal(item));
            }
            return ListOffices;
        }
    }
}

