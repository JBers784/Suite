//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suite.Models.Winatm
{
    using System;
    using System.Collections.Generic;
    
    public partial class PC_DemandaPNoAlmacen
    {
        public int año { get; set; }
        public int ProdAlm_id { get; set; }
        public int Balancista_id { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public string Desc_Prod { get; set; }
        public string UM { get; set; }
        public Nullable<decimal> Precio { get; set; }
    }
}
