using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace DAL.ConvertEF
{
    public class CitiesConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static CitiesDTO ConvertToCitiesDTO(Cities c)
        {
            if (c == null)
                return null;
            CitiesDTO city = new CitiesDTO()
            {
                CityId = c.CityId,
                City_Name = c.City_Name
            };
            return city;
        }
        //המרה הפוכה
        public static Cities ConvertToCitiesDal(CitiesDTO c)
        {
            if (c == null)
                return null;
            Cities city = new Cities()
            {
                CityId=c.CityId,
                City_Name=c.City_Name
            };
            return city;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<CitiesDTO> ConvertToCitiesDTOList(List<Cities> list)
        {
            List<CitiesDTO> listCities = new List<CitiesDTO>();
            foreach (var item in list)
            {
                listCities.Add(ConvertToCitiesDTO(item));
            }
            return listCities;
        }
        //המרה הפוכה
        public static List<Cities> ConvertToCitiesDALList(List<CitiesDTO> list)
        {
            List<Cities> listCities = new List<Cities>();
            foreach (var item in list)
            {
                listCities.Add(ConvertToCitiesDal(item));
            }
            return listCities;
        }
    }
}
    
        
