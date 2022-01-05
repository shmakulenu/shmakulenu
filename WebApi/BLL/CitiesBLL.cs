using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL;
using DTO;

namespace BLL
{
    public class CitiesBLL
    {
        //פונקציה המחזירה את כל הערים
        public static List<CitiesDTO> GetAllCities()
        {
            return CitiesDAL.GetAllCities();
        }
        //פונקציה המוסיפה עיר
        public static bool AddCity(CitiesDTO c)
        {
            return CitiesDAL.AddCity(c);
        }
    }
}
