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
    
    public partial class BuquesTransito
    {
        public System.DateTime Fecha { get; set; }
        public string IdBuque { get; set; }
        public string CodDestino { get; set; }
        public decimal Ventam3 { get; set; }
        public decimal Ventaton { get; set; }
        public string act { get; set; }
        public string TerminaCargar { get; set; }
    
        public virtual CodBuques CodBuques { get; set; }
        public virtual CodDestinos CodDestinos { get; set; }
    }
}
