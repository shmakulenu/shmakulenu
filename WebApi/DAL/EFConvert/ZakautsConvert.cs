using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.EFConvert
{
    public class ZakautsConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static ZakautsDTO ConvertToZakautDTO(Zakauts z)
        {
            if (z == null)
                return null;
            return new ZakautsDTO()
            { 
                OfficeId=z.OfficeId,
                ZakautId=z.ZakautId,
                Zakaut_Name=z.Zakaut_Name
            };

        }
        //המרה הפוכה
        public static Zakauts ConvertToZakautsDal(ZakautsDTO z)
        {
            if (z == null)
                return null;
            return new Zakauts()
            {
                OfficeId = z.OfficeId,
                ZakautId = z.ZakautId,
                Zakaut_Name = z.Zakaut_Name
            };

        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<ZakautsDTO> ConvertToZakautsDTOList(List<Zakauts> list)
        {
            List<ZakautsDTO> listZakauts = new List<ZakautsDTO>();
            foreach (var item in list)
            {
                listZakauts.Add(ConvertToZakautDTO(item));
            }
            return listZakauts;
        }
        //המרה הפוכה
        public static List<Zakauts> ConvertToZakautsDALList(List<ZakautsDTO> list)
        {
            List<Zakauts> listZakauts = new List<Zakauts>();
            foreach (var item in list)
            {
                listZakauts.Add(ConvertToZakautsDal(item));
            }
            return listZakauts;
        }
    }
}

