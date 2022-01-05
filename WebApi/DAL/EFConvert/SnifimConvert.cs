using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL.EFConvert
{
    public class SnifimConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static SnifimDTO ConvertToSnifimDTO(Snifim s)
        {
            if (s == null)
                return null;
            return new SnifimDTO()
            {
                SnifId = s.SnifId,
                CityId = s.CityId,
                Address = s.Address,
                Mail = s.Mail,
                Telephone1 = s.Telephone1,
                Telephone2 = s.Telephone2,
                SnifName = (s.Cities != null) ? s.Cities.City_Name : "",
            };
        }
        //המרה הפוכה
        public static Snifim ConvertToSnifimDal(SnifimDTO s)
        {
            if (s == null)
                return null;
            return new Snifim()
            {
                SnifId = s.SnifId,
                CityId = s.CityId,
                Address = s.Address,
                Mail = s.Mail,
                Telephone1 = s.Telephone1,
                Telephone2 = s.Telephone2,
                
            };
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<SnifimDTO> ConvertToSnifimDTOList(List<Snifim> list)
        {
            List<SnifimDTO> listSnifim = new List<SnifimDTO>();
            foreach (var item in list)
            {
                listSnifim.Add(ConvertToSnifimDTO(item));
            }
            return listSnifim;
        }
        //המרה הפוכה
        public static List<Snifim> ConvertToSnifimDALList(List<SnifimDTO> list)
        {
            List<Snifim> listSnifim = new List<Snifim>();
            foreach (var item in list)
            {
                listSnifim.Add(ConvertToSnifimDal(item));
            }
            return listSnifim;
        }
    }
}
