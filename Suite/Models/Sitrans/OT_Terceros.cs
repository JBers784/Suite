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
    
    public partial class OT_Terceros
    {
        public long ott_Id { get; set; }
        public byte mtaller_id { get; set; }
        public short ott_NoOT { get; set; }
        public int ott_Año { get; set; }
        public byte ott_Mes { get; set; }
        public Nullable<short> ent_Id { get; set; }
        public string ott_Matricula { get; set; }
        public string mmant_Id { get; set; }
        public Nullable<System.DateTime> ott_FechaEntrada { get; set; }
        public Nullable<System.DateTime> ott_FechaSalida { get; set; }
        public string ott_NombreOperador { get; set; }
        public string ott_Observaciones { get; set; }
        public string ott_Estado { get; set; }
        public Nullable<System.DateTime> ott_FechaTermina { get; set; }
    
        public virtual Entidades Entidades { get; set; }
        public virtual mundo_Mantenimientos mundo_Mantenimientos { get; set; }
        public virtual mundo_Talleres mundo_Talleres { get; set; }
    }
}
