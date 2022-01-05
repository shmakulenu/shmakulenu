using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.ConvertEF;

namespace DAL.Classes
{
    public class CitiesDAL
    {
        
        //פונקציה המחזירה את כל הערים
        public static List<CitiesDTO> GetAllCities() 
        {
            using(ShemaKolenuEntities sk=new ShemaKolenuEntities())
            {
                return CitiesConvert.ConvertToCitiesDTOList(sk.Cities.ToList());
            }
        }
        //פונקציה המוסיפה עיר
        public static bool AddCity(CitiesDTO c)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                try
                {
                    sk.Cities.Add(CitiesConvert.ConvertToCitiesDal(c));
                    sk.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return true;
                }
            }
        }
    }
}
