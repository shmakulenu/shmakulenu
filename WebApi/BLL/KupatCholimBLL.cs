using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;


namespace BLL
{
    public class KupatCholimBLL
    {
       // פונקציה המחזירה את כל קופות החולים
        public static List<KupatCholimDTO> GetAllKuputCholim()
        {          
            return KupatCholimDAL.GetAllKuputCholim();
        }
    }
}
