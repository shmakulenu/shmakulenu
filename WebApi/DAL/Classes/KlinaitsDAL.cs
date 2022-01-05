using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.EFConvert;
namespace DAL.Classes
{
    public class KlinaitsDAL
    {
        //הקלניות פונקציה המחזירה את כל 
        public static List<KlinaitsDTO> GetAllKlinaits()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return KlinaitsConvert.ConvertToKlinaitsDTOList(sk.Klinaits.ToList());
            }
        }
        //פונקציה המחזירה קלנאית על פי מספר קלנאית
        public static KlinaitsDTO GetKlinaitByNum(int? num)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                Klinaits k = (from s in sk.Klinaits
                              where s.NumKlinait == num
                              select s).FirstOrDefault();
                return KlinaitsConvert.ConvertToKlinaitsDTO(k);
            }
        }
    }
}
