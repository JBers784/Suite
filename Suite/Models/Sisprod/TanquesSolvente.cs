//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suite.Models.Sisprod
{
    using System;
    using System.Collections.Generic;
    
    public partial class TanquesSolvente
    {
        public System.DateTime Fecha { get; set; }
        public string IdInstalacion { get; set; }
        public short IdTanque { get; set; }
        public string IdSrv { get; set; }
        public Nullable<decimal> Nivel { get; set; }
        public Nullable<decimal> Densidad { get; set; }
        public Nullable<decimal> Temperatura { get; set; }
    
        public virtual CodSrv CodSrv { get; set; }
        public virtual CodTanquesDiluente CodTanquesDiluente { get; set; }
    }
}