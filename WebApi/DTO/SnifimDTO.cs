using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SnifimDTO
    {
        public int SnifId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public int Telephone1 { get; set; }
        public Nullable<int> Telephone2 { get; set; }
        //ניתן להוסיף שדות מטבלאות ערים,משתמשים,משפחות,בדיקות
        public string SnifName { get; set; }

    }
}
