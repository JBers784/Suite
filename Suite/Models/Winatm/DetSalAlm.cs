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
    
    public partial class DetSalAlm
    {
        public int SalAlm_Id { get; set; }
        public int ProdAlm_Id { get; set; }
        public decimal SalAlm_Cantidad { get; set; }
        public decimal SalAlm_Precio { get; set; }
        public decimal SalAlm_ExistAntes { get; set; }
        public decimal SalAlm_ExistTarjeta { get; set; }
        public decimal SalAlm_CantDevTmp { get; set; }
        public decimal SalAlm_CantDispDev { get; set; }
        public Nullable<decimal> SalAlm_PrecioUSD { get; set; }
        public Nullable<decimal> SalAlm_PrecioMNC { get; set; }
    }
}
