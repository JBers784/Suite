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
    
    public partial class TrasiegoPozos
    {
        public System.DateTime Fecha { get; set; }
        public string Pozo { get; set; }
        public string IdDestino { get; set; }
        public string IdPaila { get; set; }
        public string Conduce { get; set; }
        public decimal Trasiegom3 { get; set; }
        public decimal Trasiegoton { get; set; }
        public decimal Bsw { get; set; }
        public decimal API { get; set; }
        public decimal Densidad { get; set; }
    
        public virtual ConfigTrasiegosPozos ConfigTrasiegosPozos { get; set; }
    }
}
