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
    
    public partial class SubmayorPeaje
    {
        public string te_No { get; set; }
        public System.DateTime ste_Fecha { get; set; }
        public int ccosto_id { get; set; }
        public decimal ste_Debe { get; set; }
        public decimal ste_Haber { get; set; }
        public decimal ste_Saldo_ { get; set; }
        public string ste_NoTerminal { get; set; }
        public string ste_NoComprobante { get; set; }
        public string ste_Login { get; set; }
        public string eq_NumOperacional { get; set; }
        public string ste_Observ { get; set; }
    
        public virtual CentrosCostos CentrosCostos { get; set; }
        public virtual Equipos Equipos { get; set; }
        public virtual TarjetasPeaje TarjetasPeaje { get; set; }
    }
}