using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;
namespace DAL.EFConvert
{
    public class KupatCholimConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static KupatCholimDTO ConvertToKupatCholimDTO(KupatCholim k)
        {
            if (k == null)
                return null;
            KupatCholimDTO kc = new KupatCholimDTO()
            {
                Kupat_Cholim_id = k.Kupat_Cholim_id,
                Kupat_cholim_name=k.Kupat_cholim_name
            
            };
            return kc;
        }
        //המרה הפוכה
        public static KupatCholim ConvertToKupatCholim(KupatCholimDTO k)
        {
            if (k == null)
                return null;
            KupatCholim kc = new KupatCholim()
            {
                Kupat_Cholim_id = k.Kupat_Cholim_id,
                Kupat_cholim_name = k.Kupat_cholim_name

            };
            return kc;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<KupatCholimDTO> ConvertToKupatCholimDTOList(List<KupatCholim> list)
        {
            List<KupatCholimDTO> listKupatCholim = new List<KupatCholimDTO>();
            foreach (var item in list)
            {
                listKupatCholim.Add(ConvertToKupatCholimDTO(item));
            }
            return listKupatCholim;
        }
        //המרה הפוכה
        public static List<KupatCholim> ConvertToKupatCholimList(List<KupatCholimDTO> list)
        {
            List<KupatCholim> listKupatCholim = new List<KupatCholim>();
            foreach (var item in list)
            {
                listKupatCholim.Add(ConvertToKupatCholim(item));
            }
            return listKupatCholim;
        }
    }
}

