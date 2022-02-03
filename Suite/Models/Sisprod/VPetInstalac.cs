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
    
    public partial class VPetInstalac
    {
        public System.DateTime Fecha { get; set; }
        public string IdInstalacion { get; set; }
        public string CodDestino { get; set; }
        public decimal Ventam3 { get; set; }
        public decimal Ventaton { get; set; }
        public decimal BswCent { get; set; }
        public decimal BswDest { get; set; }
        public decimal Temperatura { get; set; }
        public decimal API { get; set; }
        public decimal PorcAzufre { get; set; }
        public decimal Densidad { get; set; }
        public decimal Precio { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public decimal Viscosidad { get; set; }
        public decimal Sales { get; set; }
    
        public virtual CodDestinos CodDestinos { get; set; }
        public virtual CodInstalaciones CodInstalaciones { get; set; }
    }
}
