//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requests
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
        public int NumRequest { get; set; }
        public Nullable<int> NumKlinait { get; set; }
    
        public virtual Klinaits Klinaits { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual Patients Patients { get; set; }
    }
}
