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
    
    public partial class InvFinalCombEqMes
    {
        public string eq_NumOperacional { get; set; }
        public short invComb_Año { get; set; }
        public byte invComb_Mes { get; set; }
        public decimal invComb_Cantidad { get; set; }
    
        public virtual Equipos Equipos { get; set; }
    }
}
