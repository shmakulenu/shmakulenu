using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RequestsDTO
    { 
        public int Patient_tz { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.DateTime> Intek_date { get; set; }
        public string Request__reaon { get; set; }
        public string Summary { get; set; }
        public int StatusId { get; set; }
        public string Talking1 { get; set; }
        public Nullable<System.DateTime> Talking1_date { get; set; }
        public string Talking2 { get; set; }
        public Nullable<System.DateTime> Talking2_date { get; set; }
        public string Notes { get; set; }
        public int? NumKlinait { get; set; }
        //ניתן להוסיף שדות מטבלת סטטוס פניה
        public string StatusName { get; set; }

    }
}
