using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DTO;

namespace BLL
{
    //מה כותבים כאן מעבר להפעלת הפונקציות?????????????????????????????????????
    public class UserBLL
    {
        //פונקציה מקבלת שם משתמש וססמה ומחזירה יוזר או נאל
        public static UserDTO GetUserByNameAndPassword(int password, string user_name)
        {
            return UserDAL.GetUserByNameAndPassword(password, user_name);
        }
        //פונקציה המחזירה רשימת עובדים לפי קוד עיר
        public static List<UserDTO> GetUsersByCityId(int cityId)
        {
            return UserDAL.GetUsersByCityId(cityId);
        }
        //פונקציה המחזירה את כל העובדים
        public static List<UserDTO> GetAllUsers()
        {
            return UserDAL.GetAllUsers();
        }
        //פונקציה המקבלת אוביקט עובד ומוסיפה אותו לדטה בייס
        public static bool AddUser(UserDTO user)
        {
            return UserDAL.AddUser(user);
        }
        //פונקציה המקבלת יוזר וקוד שלו ומעדכנת אותו
        public static bool UpdateUser(UserDTO u)
        {
            return UserDAL.UpdateUser(u);
        }
        //פונקציה המוחקת יוזר
        public static bool DeleteUser(UserDTO u)
        {
            return UserDAL.DeleteUser(u);
        }
        //פונקציה המחזירה את כל  סטטוס העובדים
        public static List<UserStatusDTO> GetAllUsersStatus()
        {
            return UserDAL.GetAllUsersStatus();
        }
    }
}
