using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;
namespace BLL
{
    public class SnifimBLL
    {
        //פונקציה המחזירה את כל שמות הסניפים
        public static List<SnifimDTO> GetAllSnifim()
        {
            return SnifimDAL.GetAllSnifim();
        }
        //פונקציה המתזירה  סניף על פי שם עיר 
        public static SnifimDTO GetSnifIdByCityName(string cityName)
        {
            return SnifimDAL.GetSnifIdByCityName(cityName);
        }
    }
}
