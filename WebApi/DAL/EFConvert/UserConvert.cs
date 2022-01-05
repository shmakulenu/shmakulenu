using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace DAL.ConvertEF
{
    
    public class UserConvert
    {
        //המרה ממחלקה של מיקרוסופט למחלקה שלנו 
        public static UserDTO ConvertToUserDTO(Users u)
        {
            if (u == null)
                return null;
            UserDTO user = new UserDTO()
            {
                User_tz= u.User_tz,
                User_name = u.User_name,
                Last_name=u.Last_name,
                Password = u.Password,
                SnifId = u.SnifId,
                StatusId=u.StatusId,
                UserStatusName= (u.UserStatus != null) ? u.UserStatus.Status_name : "",
            };
            return user;
        }
        //המרה הפוכה
        public static Users ConvertToUserDal(UserDTO u)
        {
            if (u == null)
                return null;
            Users user = new Users()
            {
                User_tz = u.User_tz,
                User_name = u.User_name,
                Last_name = u.Last_name,
                Password = u.Password,
                SnifId = u.SnifId,
                StatusId = u.StatusId

            };
            return user;
        }
        // המרת אוסף מופעים ממחלקה של מיקרוסופט למחלקה שלנו
        public static List<UserDTO> ConvertToUserDTOList(List<Users> list)
        {
            List<UserDTO> useurList = new List<UserDTO>();
            foreach(var item in list)
            {
                useurList.Add(ConvertToUserDTO(item));
            }
            return useurList;
        }
        //המרה הפוכה
        public static List<Users> ConvertToUserDALList(List<UserDTO> list)
        {
            List<Users> useurList = new List<Users>();
            foreach (var item in list)
            {
                useurList.Add(ConvertToUserDal(item));
            }
            return useurList;
        }
    } 
}
