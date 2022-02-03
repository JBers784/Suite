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
    
    public partial class Recepcion
    {
        public int Recepcion_Id { get; set; }
        public int Prerec_Id { get; set; }
        public System.DateTime Recepcion_Fecha { get; set; }
        public Nullable<int> TipoFact_Id { get; set; }
        public decimal Recepcion_Porciento { get; set; }
        public decimal Recepcion_Descuento { get; set; }
        public decimal Recepcion_Recargo { get; set; }
        public string Recepcion_Estado { get; set; }
        public int Opera_Id { get; set; }
    
        public virtual Operadores Operadores { get; set; }
        public virtual Prerecepcion Prerecepcion { get; set; }
        public virtual Tipo_factura Tipo_factura { get; set; }
    }
}
