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
    
    public partial class Historico_Precios
    {
        public int mProducto_Id { get; set; }
        public int HistPrecio_Ir { get; set; }
        public System.DateTime HistPrecio_FechaEntrada { get; set; }
        public decimal HistPrecio_Valor { get; set; }
        public int HistPrecio_Id { get; set; }
        public Nullable<decimal> HistPrecio_PrecioUsd { get; set; }
        public Nullable<decimal> HistPrecio_PrecioMnc { get; set; }
        public Nullable<System.DateTime> HistPrecio_FechaCero { get; set; }
    }
}