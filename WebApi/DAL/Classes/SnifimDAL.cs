using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.EFConvert;
namespace DAL.Classes
{
    public class SnifimDAL
    {
        //פונקציה המחזירה את כל שמות הסניפים
        public static List<SnifimDTO> GetAllSnifim()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return SnifimConvert.ConvertToSnifimDTOList(sk.Snifim.ToList());
            }

        }
        //פונקציה המתזירה  סניף על פי שם עיר 
        public static SnifimDTO GetSnifIdByCityName(string cityName)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                Snifim s = (from snif in sk.Snifim
                              where snif.Cities.City_Name==cityName
                              select snif).FirstOrDefault();
                return SnifimConvert.ConvertToSnifimDTO(s);
            }
        }
        
    }
}
