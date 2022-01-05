using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace DAL.ConvertEF
{
   
    public class PatientConvert
    {
        
        
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static PatientsDTO ConvertToPatientDTO(Patients p)
        {
            if (p == null)
                return null;
            PatientsDTO patient = new PatientsDTO()
            {

                date_of_birth = p.date_of_birth,
                //לא נכון משום כיוון
                //FamilyId = p.FamilyId,
                First_name = p.First_name,
                Min = p.Min,
                School = p.School,
                Tz = p.Tz,
                Tellephone1 = (p.Families != null && p.Families.FamilyTelephones.Count >= 1) ? p.Families.FamilyTelephones.ToList()[0].Telephone_number : "",
                Tellephone2 = (p.Families != null && p.Families.FamilyTelephones.Count >= 2) ? p.Families.FamilyTelephones.ToList()[1].Telephone_number : "",
                Tellephone3 = (p.Families != null && p.Families.FamilyTelephones.Count >= 3) ? p.Families.FamilyTelephones.ToList()[2].Telephone_number : "",
                Address = (p.Families != null) ? p.Families.Address : "",
                CityName = (p.Families != null && p.Families.Cities != null) ? p.Families.Cities.City_Name : "",
                KupatCholimName = (p.Families != null) ? p.Families.KupatCholim.Kupat_cholim_name : null,
                Intek_date = (p.Requests.Count > 0) ? (System.DateTime?)p.Requests.ToList()[0].Intek_date : System.DateTime.Today,
                Notes = (p.Requests.Count > 0) ? p.Requests.ToList()[0].Notes : null,
                RequestDate = (p.Requests.Count > 0) ? p.Requests.ToList()[0].Date : System.DateTime.Today,
                StatusId = (p.Requests.Count > 0) ? (int)p.Requests.ToList()[0].StatusId : 0,
                LastName = (p.Families != null) ? p.Families.LastName : "",
                Mail = (p.Families != null) ? p.Families.Mail : "",
                Father_Name = (p.Families != null) ? p.Families.Father_Name : "",
                Mother_Name = (p.Families != null) ? p.Families.Mather_Name : "",
                StatusName = (p.Requests.Count > 0) ? p.Requests.ToList()[0].RequestStatus.Describe : "",
                CityId = (p.Families != null && p.Families.Cities != null) ? (int?)p.Families.Cities.CityId : null,
                SnifId = (p.Families != null && p.Families.Snifim != null) ? (int?)p.Families.SnifId : null,
                FatherId = (p.Families != null) ? p.Families.FatherId:"",
                MotherId=(p.Families!=null)?p.Families.MotherId:"",
                

                
            };
            return patient;
        }
        //המרה הפוכה
        public static Patients ConvertToPatientDal(PatientsDTO p)
        {
            if (p == null)
                return null;
            Patients patient = new Patients()
            {
                date_of_birth = p.date_of_birth,
                FamilyId = p.FamilyId,
                First_name = p.First_name,
                Min = p.Min,
                School = p.School,
                Tz = p.Tz,            
            };
            return patient;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<PatientsDTO> ConvertToPatientDTOList(List<Patients> list)
        {
            List<PatientsDTO> listPatient = new List<PatientsDTO>();
            foreach (var item in list)
            {
                listPatient.Add(ConvertToPatientDTO(item));
            }
            return listPatient;
        }
        //המרה הפוכה
        public static List<Patients> ConvertToPatientDALList(List<PatientsDTO> list)
        {
            List<Patients> listPatient = new List<Patients>();
            foreach (var item in list)
            {
                listPatient.Add(ConvertToPatientDal(item));
            }
            return listPatient;
        }
    }
}
