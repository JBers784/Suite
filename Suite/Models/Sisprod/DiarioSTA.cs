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
    
    public partial class DiarioSTA
    {
        public System.DateTime Fecha { get; set; }
        public string IdPtoSum { get; set; }
        public byte IdSta { get; set; }
        public decimal Concent { get; set; }
        public decimal Litros { get; set; }
        public decimal PetBomb { get; set; }
    
        public virtual CodifSta CodifSta { get; set; }
        public virtual CodPtoSumSta CodPtoSumSta { get; set; }
    }
}