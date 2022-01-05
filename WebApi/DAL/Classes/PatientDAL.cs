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
    //בעיות!!!!!!!!!!!!!!!!!
    // מה עושים עם קופת חולים??????????? מחייב לעדכן בדטה בייס בהוספת משפחה????????

    public class PatientDAL
    {
        //פונקציה המחזירה את כל הפציינטים
        public static List<PatientsDTO> GetAllPatient()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return PatientConvert.ConvertToPatientDTOList(sk.Patients.ToList());
            }
        }
        //פונקציה המחזירה את כל הפציינטים שהסטטוס פניה שלהם הוא...
        public static List<PatientsDTO> GetAllPatientByStatus(int statusId)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                List<Patients> list = new List<Patients>();
                foreach (var item in sk.Patients)
                {
                    Patients tempItem = item;
                    if (item.Requests.Count > 0 && item.Requests.ToList()[0].StatusId == statusId)
                        list.Add(item);

                }
                return PatientConvert.ConvertToPatientDTOList(list);
            }
        }
        //פונקציה המקבלת סניף ומחזירה פציינטים של סניף זה
        public static List<PatientsDTO> GetPatientsByStatusAndSnif(int snifId, int statusId)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                List<Patients> list = new List<Patients>();
                foreach (var item in sk.Patients)
                {
                    if (item.Families != null)
                    {
                        if (item.Families.SnifId == snifId && item.Requests.Count > 0 && item.Requests.ToList()[0].StatusId == statusId)
                            list.Add(item);
                    }

                }
                return PatientConvert.ConvertToPatientDTOList(list);
            }

        }
        //פונקציה המחזירה פציינט על פי תעודת זהות 
        public static PatientsDTO GetPatientsByTz(int tz)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                Patients p = (from s in sk.Patients
                              where s.Tz == tz
                              select s).FirstOrDefault();
                return PatientConvert.ConvertToPatientDTO(p);
            }
        }
        //פונקציה המעדכנת פציינט
        public static bool UpdatePatient(PatientsDTO p)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                int? familyId = null;
                //אם תנאי זה מתקיים סימן שהגענו מהקלינט
                if (p.MotherId != null || p.FatherId != null)
                {
                    //if (p.Tellephone1 != null)
                    //Families.FamilyTelephones.ToList()[0].Telephone_number
                    //FamilyTelephones ft = sk.FamilyTelephones.Where(y => y.Telephone_number == p.Tellephone1).FirstOrDefault();
                    //if(ft!=null)
                    Families family = sk.Families.Where(x => x.MotherId == p.MotherId || x.FatherId == p.FatherId).FirstOrDefault();
                    if (family != null)
                    {
                        // עידכון השדות של המשפחה שמלאו בקלינט
                        family.LastName = p.LastName;
                        family.CityId = (int)p.CityId;
                        family.Address = p.Address;
                        family.Father_Name = p.Father_Name;
                        family.Mather_Name = p.Mother_Name;
                        family.Mail = p.Mail;
                        family.SnifId = (int)p.SnifId;
                        //נשלח לפונקציה שמוסיפה או מעדכנת טלפונים 
                        bool f=addAndUpdateTellephones(p, family);

                        // עידכון כדי לדעת לאיזה משפחה הצטרף familyId
                        familyId = family.FamilyId;
                    }
                    else
                    {
                        FamiliesDTO newfamily = new FamiliesDTO();
                        newfamily.Address = p.Address;
                        newfamily.CityId = (int)p.CityId;
                        newfamily.LastName = p.LastName;
                        newfamily.Father_Name = p.Father_Name;
                        newfamily.Mather_Name = p.Mother_Name;
                        newfamily.Mail = p.Mail;
                        newfamily.MotherId = p.MotherId;
                        newfamily.FatherId = p.FatherId;
                        //p.SnifId==אין סיכוי שזה יהיה נ"ל
                        newfamily.SnifId = (int)p.SnifId;
                        //מה עושים עם קופת חולים??????????? מחייב לעדכן בדטה בייס
                        newfamily.Kupat_Cholim_id = 1;
                        
                        //הוספת משפחה
                        // עידכון familyId
                        familyId = FamiliesDAL.AddFamily(newfamily);

                        Families newFamily = sk.Families.Where(x => x.FamilyId == familyId).FirstOrDefault();
                        bool f = addAndUpdateTellephones(p, newFamily);
                    }
                }
                Patients patient = sk.Patients.Where(x => x.Tz == p.Tz).FirstOrDefault();
                if (patient != null)
                {
                    // לבדוק אם להשאיר ערך קודם אם לא נשלח ערך, עושים זאת כך
                    //patient.School = p.School ?? patient.School;
                    patient.FamilyId = familyId;
                    patient.School = p.School;
                    patient.Min = p.Min;
                    patient.First_name = p.First_name;
                    patient.date_of_birth = p.date_of_birth;

                }
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

        // פונקציה שמוסיפה או מעדכנת טלפונים
        static bool addAndUpdateTellephones(PatientsDTO p, Families family)
        {
            //פונקציה זו  צריכה להיות כתובה במחלקה 
            //FamiliesTelephonesDAL
            try
            {
                using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
                {
                    var arr = sk.FamilyTelephones.Where(x => x.FamilyId == family.FamilyId);
                    sk.FamilyTelephones.RemoveRange(arr);
                    sk.SaveChanges();
                    if(p.Tellephone1!="")
                    { 
                        FamilyTelephones ft1 = new FamilyTelephones();
                        ft1.FamilyId = family.FamilyId;
                        ft1.Telephone_number = p.Tellephone1;
                        family.FamilyTelephones.Add(ft1);
                    }
                    if(p.Tellephone2 != "")
                    {
                        FamilyTelephones ft2 = new FamilyTelephones();
                        ft2.FamilyId = family.FamilyId;
                        ft2.Telephone_number = p.Tellephone2;
                        family.FamilyTelephones.Add(ft2);
                    }
                    if (p.Tellephone3 != "")
                    {

                        FamilyTelephones ft3 = new FamilyTelephones();
                        ft3.FamilyId = family.FamilyId;
                        ft3.Telephone_number = p.Tellephone3;
                        family.FamilyTelephones.Add(ft3);
                    }
                    sk.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //פונקציה המוסיפה פציינט
        public static bool AddPatient(PatientsDTO p)
        {

            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {

                int? familyId = null;
                //אם תנאי זה מתקיים סימן שהגענו מהקלינט
                if (p.MotherId != null || p.FatherId != null)
                {

                    Families family = sk.Families.Where(x => x.MotherId == p.MotherId || x.FatherId == p.FatherId).FirstOrDefault();
                    if (family != null)
                    {
                        family.LastName = p.LastName;
                        family.CityId = (int)p.CityId;
                        family.Address = p.Address;
                        family.Father_Name = p.Father_Name;
                        family.Mather_Name = p.Mother_Name;
                        family.Mail = p.Mail;
                        family.SnifId = (int)p.SnifId;

                        //נשלח לפונקציה שמוסיפה או מעדכנת טלפונים 
                        bool f = addAndUpdateTellephones(p, family);

                        // לעדכן את השדות של המשפחה שמלאו בקלינט
                        // לעדכן familyId
                        familyId = family.FamilyId;

                    }
                    //אם המשפחה לא קיימת צריך ליצור אותה
                    else
                    {
                        FamiliesDTO newfamily = new FamiliesDTO();
                        newfamily.Address = p.Address;
                        newfamily.CityId = (int)p.CityId;
                        newfamily.LastName = p.LastName;
                        newfamily.Father_Name = p.Father_Name;
                        newfamily.Mather_Name = p.Mother_Name;
                        newfamily.Mail = p.Mail;
                        newfamily.MotherId = p.MotherId;
                        newfamily.FatherId = p.FatherId;
                        //p.SnifId==אין סיכוי שזה יהיה נ"ל
                        newfamily.SnifId = (int)p.SnifId;
                        //מה עושים עם קופת חולים??????????? מחייב לעדכן בדטה בייס
                        newfamily.Kupat_Cholim_id = 1;
                        // לעדכן familyId
                        familyId = FamiliesDAL.AddFamily(newfamily);
                    
                        Families newFamily = sk.Families.Where(x => x.FamilyId == familyId).FirstOrDefault();
                        //נשלח לפונקציה שמוסיפה או מעדכנת טלפונים 
                        addAndUpdateTellephones(p, newFamily);
                    }
                }
                p.FamilyId = familyId;
                try
                {
                    sk.Patients.Add(PatientConvert.ConvertToPatientDal(p));
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            

        }

        //פונקציה המוחקת פציינט
        public static bool DeletePatient(PatientsDTO p)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                PatientsDTO pToEdit = GetPatientsByTz(p.Tz);
                Patients patient = PatientConvert.ConvertToPatientDal(pToEdit);
                try
                {
                    sk.Patients.Remove(patient);
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
