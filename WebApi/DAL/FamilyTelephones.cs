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
    
    public partial class FamilyTelephones
    {
        public string Telephone_number { get; set; }
        public int FamilyId { get; set; }
    
        public virtual Families Families { get; set; }
    }
}
