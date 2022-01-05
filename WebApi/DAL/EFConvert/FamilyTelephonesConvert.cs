using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace DAL.ConvertEF
{
    public class FamilyTelephonesConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static FamilyTelephonesDTO ConvertToFamilyTelephonesDTO(FamilyTelephones f)
        {
            if (f == null)
                return null;
            FamilyTelephonesDTO familyTelephone = new FamilyTelephonesDTO()
            {
                FamilyId = f.FamilyId,
                Telephone_number = f.Telephone_number                
            };
            return familyTelephone;
        }
        //המרה הפוכה
        public static FamilyTelephones ConvertToFamilyTelephonesDAL(FamilyTelephonesDTO f)
        {
            if (f == null)
                return null;
            FamilyTelephones familyTelephone = new FamilyTelephones()
            {
                FamilyId = f.FamilyId,
                Telephone_number = f.Telephone_number
            };
            return familyTelephone;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<FamilyTelephonesDTO> ConvertToFamilyTelephonesDTOList(List<FamilyTelephones> list)
        {
            List<FamilyTelephonesDTO> listFamiliesTelephones = new List<FamilyTelephonesDTO>();
            foreach (var item in list)
            {
                listFamiliesTelephones.Add(ConvertToFamilyTelephonesDTO(item));
            }
            return listFamiliesTelephones;
        }
        //המרה הפוכה
        public static List<FamilyTelephones> ConvertToFamilyTelephonesDALList(List<FamilyTelephonesDTO> list)
        {
            List<FamilyTelephones> listFamiliesTelephones = new List<FamilyTelephones>();
            foreach (var item in list)
            {
                listFamiliesTelephones.Add(ConvertToFamilyTelephonesDAL(item));
            }
            return listFamiliesTelephones;
        }
    }
}
