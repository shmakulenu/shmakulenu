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
    public class RequestStatusDAL
    {
        public static List<RequestStatusDTO> GetAllRequestStatus()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return RequestStatusConvert.ConvertToRequestStatusDTOList(sk.RequestStatus.ToList());
            }
        }
       
    }
}
