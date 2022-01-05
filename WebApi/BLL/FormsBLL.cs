using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace BLL
{
    public class FormsBLL
    {
        // פונקציה המחזירה מערך ניתוב קבצים עפ"י קוד זכאות
        public static List<string> GetFormsByZakautId(int zakautId)
        {
            return FormsDAL.GetFormsByZakautId(zakautId);
        }
   
        //פונקציה המוסיפה טופס
        public static bool AddForm(FormsDTO f)
        {
            return FormsDAL.AddForm(f);
        }
        //פונקציה המעדכנת טופס
        public static bool UpdateForm(FormsDTO f)
        {
            return FormsDAL.UpdateForm(f);
        }
        //פונקציה המחזירה טופס לפי קוד טופס
        public static FormsDTO GetFormById(int id)
        {
            return FormsDAL.GetFormById(id);
        }
    }
}
