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
    
    public partial class ConsumoCombustibleMotores
    {
        public string motor_NumSerie { get; set; }
        public string eq_NumOperacional { get; set; }
        public int ccosto_Id { get; set; }
        public string mcomb_Id { get; set; }
        public System.DateTime cm_Fecha { get; set; }
        public float cm_Litros { get; set; }
        public string Login { get; set; }
    
        public virtual CentrosCostos CentrosCostos { get; set; }
        public virtual Equipos Equipos { get; set; }
        public virtual Motores Motores { get; set; }
        public virtual mundo_Combustibles mundo_Combustibles { get; set; }
    }
}
