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
    
    public partial class MotoresComb
    {
        public string mComb_Id { get; set; }
        public string motor_NumSerie { get; set; }
        public float motorComb_PlanLitros { get; set; }
    
        public virtual Motores Motores { get; set; }
        public virtual mundo_Combustibles mundo_Combustibles { get; set; }
    }
}
