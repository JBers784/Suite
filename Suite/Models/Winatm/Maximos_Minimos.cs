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
    
    public partial class Maximos_Minimos
    {
        public int mProducto_Id { get; set; }
        public decimal MaxMin_Minimo { get; set; }
        public decimal MaxMin_Maximo { get; set; }
        public Nullable<decimal> MaxMin_PtoReorden { get; set; }
        public Nullable<int> MaxMin_InvOptimo { get; set; }
        public Nullable<int> MaxMin_InvExceso { get; set; }
    }
}