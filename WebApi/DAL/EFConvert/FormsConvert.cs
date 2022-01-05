using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;
namespace DAL.ConvertEF
{
    public class FormsConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו
        public static FormsDTO ConvertToFormsDTO(Forms f)
        {
            if (f == null)
                return null;
            FormsDTO form = new FormsDTO()
            {
                FormId = f.FormId,
                Form_FileName_Navigation = f.Form_FileName_Navigation,
                Form_Name = f.Form_Name,
                ZakautId = f.ZakautId
            };
            return form;
        }
        //המרה הפוכה
        public static Forms ConvertToFormsDAL(FormsDTO f)
        {
            if (f == null)
                return null;
            Forms form = new Forms()
            {
                FormId = f.FormId,
                Form_FileName_Navigation = f.Form_FileName_Navigation,
                Form_Name = f.Form_Name,
                ZakautId = f.ZakautId
            };
            return form;
        }
        //המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<FormsDTO> ConvertToFormsDTOList(List<Forms> list)
        {
            List<FormsDTO> formList = new List<FormsDTO>();
            foreach (var item in list)
            {
                formList.Add(ConvertToFormsDTO(item));
            }
            return formList;
        }
        //המרה הפוכה
        public static List<Forms> ConvertToUserDALList(List<FormsDTO> list)
        {
            List<Forms> formList = new List<Forms>();
            foreach (var item in list)
            {
                formList.Add(ConvertToFormsDAL(item));
            }
            return formList;
        }
    }
}   
