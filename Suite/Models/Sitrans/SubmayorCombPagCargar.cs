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
    
    public partial class SubmayorCombPagCargar
    {
        public string mcomb_Id { get; set; }
        public System.DateTime scpc_Fecha { get; set; }
        public decimal scpc_Entradas { get; set; }
        public decimal scpc_Salidas { get; set; }
        public decimal scpc_SaldoLts { get; set; }
        public decimal scpc_Debe { get; set; }
        public decimal scpc_Haber { get; set; }
        public decimal scpc_Saldo_ { get; set; }
        public string scpc_NoComprobante { get; set; }
        public string scpc_Login { get; set; }
        public string scpc_Observ { get; set; }
    
        public virtual mundo_Combustibles mundo_Combustibles { get; set; }
        public virtual mundo_Combustibles mundo_Combustibles1 { get; set; }
    }
}