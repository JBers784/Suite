//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suite.Models.Sicenco
{
    using System;
    using System.Collections.Generic;
    
    public partial class Presupuesto_SubElemento
    {
        public string SubElem_Id { get; set; }
        public string CCosto_id { get; set; }
        public decimal PresSubElem_ValorPlan { get; set; }
        public Nullable<decimal> PresSubElem_ValorReal { get; set; }
        public Nullable<decimal> PresSubElem_ValorPredesp { get; set; }
        public Nullable<int> CCosto_idN { get; set; }
    
        public virtual SubElementos SubElementos { get; set; }
    }
}