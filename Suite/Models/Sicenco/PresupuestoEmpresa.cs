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
    
    public partial class PresupuestoEmpresa
    {
        public int año { get; set; }
        public int Mes { get; set; }
        public string Subelem_idMN { get; set; }
        public string Subelem_idDi { get; set; }
        public Nullable<decimal> PlanMn { get; set; }
        public Nullable<decimal> PlanDi { get; set; }
        public Nullable<decimal> RealMn { get; set; }
        public Nullable<decimal> RealDi { get; set; }
        public Nullable<decimal> PredespMn { get; set; }
        public Nullable<decimal> PredespDi { get; set; }
    }
}