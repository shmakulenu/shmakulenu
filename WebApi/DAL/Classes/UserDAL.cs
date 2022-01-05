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
    public class UserDAL
    {
        //------------FUNCTIONS--------------------
        //פונקציה מקבלת שם משתמש וססמה ומחזירה יוזר או נאל
        public static UserDTO GetUserByNameAndPassword(int password, string name)
        {
            using (ShemaKolenuEntities sk=new ShemaKolenuEntities())
            {
                Users u = (from user in sk.Users.ToList()
                               where user.User_name == name && user.Password == password
                               select user).FirstOrDefault();
                return UserConvert.ConvertToUserDTO(u);
            }
            
        }

        //פונקציה המחזירה רשימת עובדים לפי קוד עיר
        public static List<UserDTO> GetUsersByCityId(int cityId) 
        {
            using (ShemaKolenuEntities sk=new ShemaKolenuEntities()) 
            {
                List<Users> list = new List<Users>();
                foreach(var item in sk.Users.ToList())
                {
                    if (item.Snifim.CityId == cityId)
                        list.Add(item);
                }
                return UserConvert.ConvertToUserDTOList(list);
            }
        }
        //פונקציה המחזירה את כל העובדים
        public static List<UserDTO> GetAllUsers() 
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return UserConvert.ConvertToUserDTOList(sk.Users.ToList());
                //List<Users> list = new List<Users>();
                //foreach (var item in sk.Users.ToList())
                //{
                //    list.Add(item);
                //}
                //return UserConvert.ConvertToUserDTOList(list);
            }
        }
        //פונקציה המקבלת אוביקט עובד ומוסיפה אותו לדטה בייס
        public static bool AddUser(UserDTO user) 
        {
            using (ShemaKolenuEntities sk=new ShemaKolenuEntities()) { 
                try
                {               
                    sk.Users.Add(UserConvert.ConvertToUserDal(user));
                    sk.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        //פונקציה המקבלת יוזר וקוד שלו ומעדכנת אותו
        public static bool UpdateUser(UserDTO u) 
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                UserDTO userToEdit = GetAllUsers().FirstOrDefault(user => user.User_tz == u.User_tz);
                Users user2 = UserConvert.ConvertToUserDal(userToEdit);
                if (user2 != null)
                {
                    user2.User_tz = u.User_tz;
                    user2.Password = u.Password;
                    user2.SnifId = u.SnifId;
                    user2.User_name = u.User_name;
                    user2.Last_name = u.Last_name;
                    user2.StatusId = u.StatusId;

                }
                try
                {
                    sk.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
        //פונקציה המוחקת יוזר
        public static bool DeleteUser(UserDTO u)
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                UserDTO userToEdid = GetAllUsers().FirstOrDefault(us => us.User_tz == u.User_tz);
                Users user = UserConvert.ConvertToUserDal(userToEdid);
                try
                {
                    sk.Users.Remove(user);
                    sk.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }                 
        }
        //פונקציה המחזירה את כל  סטטוס העובדים
        public static List<UserStatusDTO> GetAllUsersStatus()
        {
            using (ShemaKolenuEntities sk = new ShemaKolenuEntities())
            {
                return UserStatusConvert.ConvertToUserStatusDTOList(sk.UserStatus.ToList());
                 

            }
        }
    }
}
