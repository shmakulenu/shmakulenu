using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientsDTO
    {
        public int Tz { get; set; }
        public System.DateTime date_of_birth { get; set; }
        public string First_name { get; set; }
        public int? FamilyId { get; set; }
        public string Min { get; set; }
        public string School { get; set; }
        //  אפשר להוסיף שדות נוספים מטבלאות משפחות ובדיקות ופניות
        public string Tellephone1 { get; set; }
        public string Tellephone2 { get; set; }
        public string Tellephone3 { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string KupatCholimName { get; set; }
        public Nullable<System.DateTime> Intek_date { get; set; }
        public System.DateTime RequestDate { get; set; }
        public string Notes { get; set; }
        public int StatusId { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Father_Name { get; set; }
        public string Mother_Name { get; set; }
        public string MotherId { get; set; }
        public string FatherId { get; set; }
        public string StatusName { get; set; }
        public int? CityId { get; set; }
        public int? SnifId { get; set; }


    }


}
