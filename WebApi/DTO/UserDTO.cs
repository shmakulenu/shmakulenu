using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {

        public string User_tz { get; set; }
        public int Password { get; set; }
        public string User_name { get; set; }
        public string Last_name { get; set; }
        public int SnifId { get; set; }
        public Nullable<int> StatusId { get; set; }
        //אפשר להוסיף שדות מטבלת סניפים
        public String UserStatusName { get; set; }

    }
}
