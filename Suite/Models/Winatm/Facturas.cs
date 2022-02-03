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
    
    public partial class Facturas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Facturas()
        {
            this.DetFacturas = new HashSet<DetFacturas>();
            this.SalAlm_Factura = new HashSet<SalAlm_Factura>();
        }
    
        public int Fact_Id { get; set; }
        public int Fact_NoDoc { get; set; }
        public System.DateTime Fact_Fecha { get; set; }
        public string Cliente_Id { get; set; }
        public int TPago_Id { get; set; }
        public int Opera_Id { get; set; }
        public string Fact_Cheque { get; set; }
        public int TGasto_id { get; set; }
        public string Fact_Observ { get; set; }
        public Nullable<decimal> CliCodigo { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetFacturas> DetFacturas { get; set; }
        public virtual Operadores Operadores { get; set; }
        public virtual Tipo_Gastos Tipo_Gastos { get; set; }
        public virtual Tipo_pago Tipo_pago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalAlm_Factura> SalAlm_Factura { get; set; }
    }
}
