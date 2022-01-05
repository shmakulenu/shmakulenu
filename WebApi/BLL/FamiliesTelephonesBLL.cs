using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace BLL
{
    public class FamiliesTelephonesBLL
    {
        //פונקציה המחזירה טל לפי תז
        public static string GetTellByFamilyId(int id)
        {
            return FamiliesTelephonesDAL.GetTellByFamilyId(id); 
        }
        //פונקציה המעדכנת מספר טל למשפחה
        public static bool UpdateFamilyTell(FamilyTelephonesDTO ft)
        {
            return FamiliesTelephonesDAL.UpdateFamilyTell(ft);
        }
    }
}
