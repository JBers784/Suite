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
    
    public partial class ParteDiarioCMed
    {
        public string IdCentro { get; set; }
        public decimal Tt { get; set; }
        public string Afect { get; set; }
    
        public virtual CodCentrosMedicion CodCentrosMedicion { get; set; }
    }
}
