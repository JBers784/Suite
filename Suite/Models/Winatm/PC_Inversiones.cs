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
    
    public partial class PC_Inversiones
    {
        public int Balanc_id { get; set; }
        public int ProdAlm_id { get; set; }
        public Nullable<decimal> IInic_Cant { get; set; }
        public Nullable<decimal> IComp_Cant { get; set; }
        public Nullable<decimal> ICons_Cant { get; set; }
        public Nullable<decimal> IFinal_Cant { get; set; }
        public int año { get; set; }
        public Nullable<decimal> Tri1 { get; set; }
        public Nullable<decimal> Tri2 { get; set; }
        public Nullable<decimal> Tri3 { get; set; }
        public Nullable<decimal> Tri4 { get; set; }
        public string Tope { get; set; }
        public string Cod_Gastos { get; set; }
        public string Cod_805 { get; set; }
        public string CtaCcosto { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Cod_Compras { get; set; }
        public Nullable<byte> CodTCompras { get; set; }
    }
}
