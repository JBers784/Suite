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
    
    public partial class Salidas_Almacen
    {
        public int SalAlm_id { get; set; }
        public int SalAlm_NoVS { get; set; }
        public string Almacen_Id { get; set; }
        public System.DateTime SalAlm_Fecha { get; set; }
        public string CtaCCosto { get; set; }
        public int opera_id { get; set; }
        public string SalAlm_Estado { get; set; }
        public Nullable<int> Prelacion { get; set; }
        public Nullable<int> CtaCCostoN { get; set; }
    }
}
