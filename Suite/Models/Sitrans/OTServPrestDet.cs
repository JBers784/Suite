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
    
    public partial class OTServPrestDet
    {
        public long OTID { get; set; }
        public byte ServiciosID { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Tarifa { get; set; }
    
        public virtual mundo_Servicios mundo_Servicios { get; set; }
        public virtual OTServiciosPrestados OTServiciosPrestados { get; set; }
    }
}
