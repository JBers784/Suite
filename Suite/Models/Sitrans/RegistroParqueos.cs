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
    
    public partial class RegistroParqueos
    {
        public int RegParq_NoDoc { get; set; }
        public string eq_NumOperacional { get; set; }
        public string RegParq_Tipo { get; set; }
        public string RegParq_EmitidoPor { get; set; }
        public System.DateTime RegParq__FechaExp { get; set; }
        public System.DateTime RegParq__FechaVence { get; set; }
        public short c_Id { get; set; }
        public string RegParq__DirPartChofer { get; set; }
        public string RegParq__CargoChofer { get; set; }
        public short p_ID { get; set; }
    
        public virtual Choferes Choferes { get; set; }
        public virtual Equipos Equipos { get; set; }
        public virtual mundo_ParqueoAutorizo mundo_ParqueoAutorizo { get; set; }
    }
}
