using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace BLL
{
    public class FamiliesBLL
    {
        // פונקציה המקבלת תז של הורה ומחזירה משפחה
        public static FamiliesDTO GetFamilyByParentTz(int tz)
        {
            return FamiliesDAL.GetFamilyByParentTz(tz);
        }
        // פונקציה המחזירה קוד משפחה עפ"י מס טלפון
        public static int GetFamilyIdByTell(string tell)
        {
            return FamiliesDAL.GetFamilyIdByTell(tell);
        }
        //פונקציה המחזירה את כל המשפחות
        public static List<FamiliesDTO> GellAllFamilies()
        {
            return FamiliesDAL.GellAllFamilies();
        }
        // פונקציה המעדכנת פרטי משפחה
        public static bool UpdateFamily(FamiliesDTO f)
        {
            return FamiliesDAL.UpdateFamily(f);
        }
        //פונקציה המוסיפה משפחה
        public static int AddFamily(FamiliesDTO f)
        {
            return FamiliesDAL.AddFamily(f);
        }
    }
}
