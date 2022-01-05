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
    public class FamiliesTelephonesDAL
    {
        //פונקציה המחזירה טל לפי תז
        public static string GetTellByFamilyId(int id)
        {
            using (ShemaKolenuEntities sk=new ShemaKolenuEntities()) 
            {
                var tell = (from s in sk.FamilyTelephones.ToList()
                            where s.FamilyId == id
                            select new { s.Telephone_number }).FirstOrDefault();
                if (tell == null)
                    return null;
                return tell.ToString() ;
            }
        }
        //פונקציה המחזירה את כל הטלפונים
        public static List<FamilyTelephonesDTO> GettAllTelephones()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return FamilyTelephonesConvert.ConvertToFamilyTelephonesDTOList(sk.FamilyTelephones.ToList());
            }
        }
        //פונקציה המעדכנת מספר טל למשפחה
        public static bool UpdateFamilyTell(FamilyTelephonesDTO ft)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                FamilyTelephonesDTO ftToEdit = GettAllTelephones().FirstOrDefault(f => f.FamilyId == ft.FamilyId);
                FamilyTelephones familyTelephone = FamilyTelephonesConvert.ConvertToFamilyTelephonesDAL(ftToEdit);
                if(familyTelephone!=null)
                {
                    familyTelephone.FamilyId = ft.FamilyId;
                    familyTelephone.Telephone_number = ft.Telephone_number;
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
        //פונקציה המוסיפה מס טל לדטה בייס
        //public static bool AddFamilyTelephone(FamilyTelephonesDTO ft)
        //{
        //    using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
        //    {
        //        try
        //        {
        //            sk.FamilyTelephones.Add
        //        }
        //    }
        //}
    }
}
