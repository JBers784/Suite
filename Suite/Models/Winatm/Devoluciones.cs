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
    
    public partial class Devoluciones
    {
        public int Dev_Id { get; set; }
        public int Dev_NoDev { get; set; }
        public string Almacen_Id { get; set; }
        public System.DateTime Dev_Fecha { get; set; }
        public int SalAlm_Id { get; set; }
        public Nullable<int> Prelacion { get; set; }
    
        public virtual Almacenes Almacenes { get; set; }
    }
}