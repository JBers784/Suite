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
    
    public partial class MovTarjCombCaja
    {
        public string te_No { get; set; }
        public System.DateTime Fecha { get; set; }
        public string TipoMov { get; set; }
        public string Comentarios { get; set; }
        public string eq_NumOperacional { get; set; }
        public Nullable<int> ccosto_id { get; set; }
    
        public virtual TarjetasExternas TarjetasExternas { get; set; }
    }
}
