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
    
    public partial class DistBonosCombEq
    {
        public long DistBonoComb_ID { get; set; }
        public string eq_NumOperacional { get; set; }
        public string noBonoComb { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public byte Cantidad { get; set; }
        public int ccosto_id { get; set; }
        public string mcomb_Id { get; set; }
        public short c_Id { get; set; }
        public bool Liquidado { get; set; }
        public Nullable<System.DateTime> FechaLiquidado { get; set; }
    
        public virtual CentrosCostos CentrosCostos { get; set; }
        public virtual Choferes Choferes { get; set; }
        public virtual Equipos Equipos { get; set; }
        public virtual mundo_Combustibles mundo_Combustibles { get; set; }
    }
}