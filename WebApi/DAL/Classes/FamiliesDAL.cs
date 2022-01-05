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
    public class FamiliesDAL
    {
        // פונקציה המקבלת תז של הורה ומחזירה משפחה
        public static FamiliesDTO GetFamilyByParentTz(int tz)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                Families f = (from s in sk.Families
                              where s.FatherId.Equals(tz) || s.MotherId.Equals(tz)
                              select s).FirstOrDefault();
                return FamiliesConvert.ConvertToFamiliestDTO(f);
            }
        }
        // פונקציה המחזירה קוד משפחה עפ"י מס טלפון
        public static int GetFamilyIdByTell(string tell)
        {
            using (ShemaKolenuEntities sk=new ShemaKolenuEntities())
            {
                var id = (from s in sk.FamilyTelephones
                          where tell == s.Telephone_number
                          select s.FamilyId).FirstOrDefault().ToString();

                return int.Parse(id);
            }
        }
        //פונקציה המחזירה את כל המשפחות
        public static List<FamiliesDTO> GellAllFamilies()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return FamiliesConvert.ConvertToFamiliesDTOList(sk.Families.ToList());
            }
        }
     // פונקציה המעדכנת פרטי משפחה
        public static bool UpdateFamily(FamiliesDTO f)
        {       
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                //Families family = sk.Families.Where(x => x.FamilyTelephones != null && x.FamilyTelephones.ToList()[0].Telephone_number == p.Tellephone1).FirstOrDefault();
                //    if (family2 != null)
                //    {
                //        family2.CityId = f.CityId;
                //        family2.FatherId = f.FatherId;
                //        family2.Kupat_Cholim_id = f.Kupat_Cholim_id;
                //        family2.SnifId = f.SnifId;
                //        family2.MotherId = f.MotherId;
                //        family2.Mather_Name = f.Mather_Name;
                //        family2.Mail = f.Mail;
                //        family2.LastName = f.LastName;
                //        family2.Father_Name = f.Father_Name;
                //        family2.Address = f.Address;
                //        family2.Entry_Date = f.Entry_Date;
                //    }
                try
                {
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        //פונקציה המוסיפה משפחה
        public static int AddFamily(FamiliesDTO f)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                try
                {
                    Families family= sk.Families.Add(FamiliesConvert.ConvertToFamiliestDal(f));
                    sk.SaveChanges();
                    return family.FamilyId;
                }
                catch(Exception e)
                {
                    return -1;
                }
            }
        }
    }
}
