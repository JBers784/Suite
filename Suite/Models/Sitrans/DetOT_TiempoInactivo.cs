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
    
    public partial class DetOT_TiempoInactivo
    {
        public long ot_Id { get; set; }
        public byte mpar_Id { get; set; }
        public System.DateTime dotti_Fecha { get; set; }
        public short dotti_Horas { get; set; }
        public byte dotti_Min { get; set; }
    
        public virtual mundo_Paralizaciones mundo_Paralizaciones { get; set; }
    }
}
