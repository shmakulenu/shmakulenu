using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL.EFConvert
{
    public class KlinaitsConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static KlinaitsDTO ConvertToKlinaitsDTO(Klinaits k)
        {
            if (k == null)
                return null;
            KlinaitsDTO kc = new KlinaitsDTO()
            {
                Mail=k.Mail,
                Name=k.Name,
                NumKlinait=k.NumKlinait
            };
            return kc;
        }
        //המרה הפוכה
        public static Klinaits ConvertToKlinaits(KlinaitsDTO k)
        {
            if (k == null)
                return null;
            Klinaits kc = new Klinaits()
            {
                NumKlinait=k.NumKlinait,
                Name=k.Name,
                Mail=k.Mail
            };
            return kc;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<KlinaitsDTO> ConvertToKlinaitsDTOList(List<Klinaits> list)
        {
            List<KlinaitsDTO> listKlinaits = new List<KlinaitsDTO>();
            foreach (var item in list)
            {
                listKlinaits.Add(ConvertToKlinaitsDTO(item));
            }
            return listKlinaits;
        }
        //המרה הפוכה
        public static List<Klinaits> ConvertToKlinaitsList(List<KlinaitsDTO> list)
        {
            List<Klinaits> listKlinaits = new List<Klinaits>();
            foreach (var item in list)
            {
                listKlinaits.Add(ConvertToKlinaits(item));
            }
            return listKlinaits;
        }
    }
}
