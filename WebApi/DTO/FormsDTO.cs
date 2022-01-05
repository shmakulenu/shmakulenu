using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FormsDTO
    {
        public int FormId { get; set; }
        public int ZakautId { get; set; }
        public string Form_Name { get; set; }
        public string Form_FileName_Navigation { get; set; }
        //אפשר להוסיף שדות נוספים מטבלאות זכאויות
    }
}
