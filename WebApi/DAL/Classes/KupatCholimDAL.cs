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
    public class KupatCholimDAL
    {
        //פונקציה המחזירה את כל קופות החולים
        public static List<KupatCholimDTO> GetAllKuputCholim()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return KupatCholimConvert.ConvertToKupatCholimDTOList(sk.KupatCholim.ToList());
            }

        }
    }
}
