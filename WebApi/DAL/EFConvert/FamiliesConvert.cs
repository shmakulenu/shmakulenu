using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace DAL.ConvertEF
{
    public class FamiliesConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static FamiliesDTO ConvertToFamiliestDTO(Families f)
        {
            if (f == null)
                return null;
            FamiliesDTO family = new FamiliesDTO()
            {
                Address = f.Address,
                CityId = f.CityId,
                Entry_Date = f.Entry_Date,
                //FamilyId = f.FamilyId,
                FatherId = f.FatherId,
                Father_Name = f.Father_Name,
                Kupat_Cholim_id = f.Kupat_Cholim_id,
                LastName = f.LastName,
                Mail = f.Mail,
                Mather_Name = f.Mather_Name,
                MotherId = f.MotherId,
                SnifId = f.SnifId
            };
            return family;
        }

        //המרה הפוכה
        public static Families  ConvertToFamiliestDal(FamiliesDTO f)
        {
            if (f == null)
                return null;
            Families family = new Families()
            {
                Address = f.Address,
                CityId = f.CityId,
                Entry_Date = f.Entry_Date,
                FatherId = f.FatherId,
                Father_Name = f.Father_Name,
                Kupat_Cholim_id = f.Kupat_Cholim_id,
                LastName = f.LastName,
                Mail = f.Mail,
                Mather_Name = f.Mather_Name,
                MotherId = f.MotherId,
                SnifId = f.SnifId
            };
            return family;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<FamiliesDTO> ConvertToFamiliesDTOList(List<Families> list)
        {
            List<FamiliesDTO> listFamilies = new List<FamiliesDTO>();
            foreach (var item in list)
            {
                listFamilies.Add(ConvertToFamiliestDTO(item));
            }
            return listFamilies;
        }
        //המרה הפוכה
        public static List<Families> ConvertToFamiliesDALList(List<FamiliesDTO> list)
        {
            List<Families> listFamilies = new List<Families>();
            foreach (var item in list)
            {
                listFamilies.Add(ConvertToFamiliestDal(item));
            }
            return listFamilies;
        }
    }
}
