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
    
    public partial class PC_Extraplan
    {
        public int ProdAlm_Id { get; set; }
        public int Año { get; set; }
        public Nullable<decimal> Iinic_Cant { get; set; }
        public Nullable<decimal> IComp_Cant { get; set; }
        public Nullable<decimal> ICons_Cant { get; set; }
        public Nullable<decimal> IFinal_Cant { get; set; }
        public string Cod_Gastos { get; set; }
        public string Cod_Compras { get; set; }
        public string Cod_805 { get; set; }
        public Nullable<byte> CodTCompras { get; set; }
        public Nullable<int> Balanc_Id { get; set; }
    }
}
