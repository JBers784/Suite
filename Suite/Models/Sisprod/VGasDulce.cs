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
    
    public partial class VGasDulce
    {
        public string IdInstalacion { get; set; }
        public string CodDestino { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Venta { get; set; }
    
        public virtual CodDestinos CodDestinos { get; set; }
        public virtual CodInstalaciones CodInstalaciones { get; set; }
    }
}
