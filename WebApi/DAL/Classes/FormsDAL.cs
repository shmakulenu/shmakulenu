using DAL.EFConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.ConvertEF;


namespace DAL.Classes
{
    public class FormsDAL
    {
       // פונקציה המחזירה מערך ניתוב קבצים עפ"י קוד זכאות
       public static List<string> GetFormsByZakautId(int zakautId)
        {
            using(ShemaKolenuEntities sk=new ShemaKolenuEntities())
            {
                List<string> list = new List<string>();
                foreach(var item in sk.Forms.ToList())
                {
                    if (item.ZakautId == zakautId)
                    {
                        list.Add(item.Form_FileName_Navigation);
                    }                  
                }
                return list;
            }
        }
        //פונקציה המוסיפה טופס
        public static bool AddForm(FormsDTO f) 
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                try
                {
                    sk.Forms.Add(FormsConvert.ConvertToFormsDAL(f));                 
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        //פונקציה המעדכנת טופס
        public static bool UpdateForm(FormsDTO f)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                FormsDTO fToEdit = GetFormById(f.FormId);
                Forms form = FormsConvert.ConvertToFormsDAL(fToEdit);               
                if (form != null)
                {
                    form.FormId = f.FormId;
                    form.Form_FileName_Navigation = f.Form_FileName_Navigation;
                    form.Form_Name = f.Form_Name;
                    form.ZakautId = f.ZakautId;
                }
                try
                {
                    sk.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
                
            }
        }
        //פונקציה המחזירה טופס לפי קוד טופס
        public static FormsDTO GetFormById(int id)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                Forms f = (from s in sk.Forms
                           where s.FormId == id
                           select s).FirstOrDefault();
                return FormsConvert.ConvertToFormsDTO(f);
            }
        }
    }
}
