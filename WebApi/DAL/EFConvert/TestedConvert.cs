using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL.EFConvert
{
    public class TestedConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static TestedDTO ConvertToTestedDTO(Tested t)
        {
            if (t == null)
                return null;
            return new TestedDTO()
            {
               //Test_number=t.Test_number,
               Patient_tz=t.Patient_tz,
               SnifId=t.SnifId,
               Test_date_=t.Test_date_,
               File_test_result_navigation=t.File_test_result_navigation
            };

        }
        //המרה הפוכה
        public static Tested ConvertToTestedsDal(TestedDTO t)
        {
            if (t == null)
                return null;
            return new Tested()
            {
                //Test_number = t.Test_number,
                Patient_tz = t.Patient_tz,
                SnifId = t.SnifId,
                Test_date_ = t.Test_date_,
                File_test_result_navigation = t.File_test_result_navigation
            };
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<TestedDTO> ConvertToTestedDTOList(List<Tested> list)
        {
            List<TestedDTO> listTested = new List<TestedDTO>();
            foreach (var item in list)
            {
                listTested.Add(ConvertToTestedDTO(item));
            }
            return listTested;
        }
        //המרה הפוכה
        public static List<Tested> ConvertToTestedDALList(List<TestedDTO> list)
        {
            List<Tested> listTested = new List<Tested>();
            foreach (var item in list)
            {
                listTested.Add(ConvertToTestedsDal(item));
            }
            return listTested;
        }
    }
}

