using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FamiliesDTO
    {
        public string LastName { get; set; }
        public string Father_Name { get; set; }
        public string FatherId { get; set; }
        public string Mather_Name { get; set; }
        public string MotherId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public System.DateTime Entry_Date { get; set; }
        public int Kupat_Cholim_id { get; set; }
        public int SnifId { get; set; }
        //אפשר להוסיף שדות נוספים מטבלאות משפחות ובדיקות
    }
}
