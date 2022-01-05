using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL.EFConvert
{
    public class UserStatusConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static UserStatusDTO ConvertToUserStatusDTO(UserStatus s)
        {
            if (s == null)
                return null;
            return new UserStatusDTO()
            {
                StatusId=s.StatusId,
                Status_name=s.Status_name,
            };
        }
        //המרה הפוכה
        public static UserStatus ConvertToUserStatusDAL(UserStatusDTO s)
        {
            if (s == null)
                return null;
            return new UserStatus()
            {
                StatusId = s.StatusId,
                Status_name = s.Status_name,
            };
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<UserStatusDTO> ConvertToUserStatusDTOList(List<UserStatus> list)
        {
            List<UserStatusDTO> listStatus = new List<UserStatusDTO>();
            foreach (var item in list)
            {
                listStatus.Add(ConvertToUserStatusDTO(item));
            }
            return listStatus;
        }
        //המרה הפוכה
        public static List<UserStatus> ConvertToUserStatusDALList(List<UserStatusDTO> list)
        {
            List<UserStatus> listStatus = new List<UserStatus>();
            foreach (var item in list)
            {
                listStatus.Add(ConvertToUserStatusDAL(item));
            }
            return listStatus;
        }
    }
}

