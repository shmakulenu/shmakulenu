using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.ConvertEF;
using DAL.EFConvert;

namespace DAL.Classes
{
    public class TestedDAL
    {
        //פונקציה המוסיפה בדיקה
        public static bool AddTest(TestedDTO test)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                try
                {
                    sk.Tested.Add(TestedConvert.ConvertToTestedsDal(test));
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
