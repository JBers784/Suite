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
    
    public partial class Salidas_Almacenes
    {
        public long SalAlm_Id { get; set; }
        public int SalAlm_NoVS { get; set; }
        public string SalAlm_AlmacenId { get; set; }
        public System.DateTime SalAlm_Fecha { get; set; }
        public int SalAlm_NoOT { get; set; }
        public int ccosto_id { get; set; }
    
        public virtual CentrosCostos CentrosCostos { get; set; }
    }
}