using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Asapim
    {
        public int Tz { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public DateTime Date_of_birth { get; set; }
        public DateTime DateRequest { get; set; }
        //public double Date_of_birth { get; set; }
        public string Name { get; set; }
        public string SnifName { get; set; }
        //אוזן שמאל
        public Dictionary<string, double> Left { get; set; }
        //אוזן ימין
        public Dictionary<string, double> Right { get; set; }
        public Asapim()
        {
            Left = new Dictionary<string, double>();
            Right= new Dictionary<string, double>();
        }
        //אוזן ימין
        //public double R250 { get; set; }
        //public double R500 { get; set; }
        //public double R750 { get; set; }
        //public double R1000 { get; set; }
        //public double R1500 { get; set; }
        //public double R2000 { get; set; }
        //public double R3000 { get; set; }
        //public double R4000 { get; set; }
        //public double R6000 { get; set; }
        //public double R8000 { get; set; }
        //אוזן שמאל
        //public double L250 { get; set; }
        //public double L500 { get; set; }
        //public double L750 { get; set; }
        //public double L1000 { get; set; }
        //public double L1500 { get; set; }
        //public double L2000 { get; set; }
        //public double L3000 { get; set; }
        //public double L4000 { get; set; }
        //public double L6000 { get; set; }
        //public double L8000 { get; set; }
    }
}
