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
    
    public partial class AsignacionesMotores
    {
        public int am_Id { get; set; }
        public string motor_NumSerie { get; set; }
        public System.DateTime am_Fecha { get; set; }
        public int am_Litros { get; set; }
        public string eq_NumOperacional { get; set; }
    
        public virtual Equipos Equipos { get; set; }
        public virtual Motores Motores { get; set; }
    }
}