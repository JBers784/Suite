//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suite.Models.Sitrans
{
    using System;
    using System.Collections.Generic;
    
    public partial class KmsArrastres
    {
        public decimal ka_Id { get; set; }
        public string eq_NumOperacional { get; set; }
        public float ka_Kms { get; set; }
        public System.DateTime ka_Fecha { get; set; }
    
        public virtual Equipos Equipos { get; set; }
    }
}