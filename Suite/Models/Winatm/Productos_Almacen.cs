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
    
    public partial class Productos_Almacen
    {
        public int ProdAlm_Id { get; set; }
        public int mProducto_Id { get; set; }
        public string Almacen_Id { get; set; }
        public string ProdAlm_Um { get; set; }
        public string ProdAlm_Control { get; set; }
        public decimal ProdAlm_Existencia { get; set; }
        public decimal ProdAlm_CantPred { get; set; }
        public string Prodalm_Seccion { get; set; }
        public string ProdAlm_Estante { get; set; }
        public string ProdAlm_Casilla { get; set; }
        public Nullable<int> Balancista_id { get; set; }
        public Nullable<System.DateTime> ProdAlm_FechaAct { get; set; }
        public Nullable<int> Actividad_id { get; set; }
        public Nullable<decimal> ProdAlm_precmn { get; set; }
        public Nullable<decimal> ProdAlm_precmd { get; set; }
        public string ProdAlm_Subelmn { get; set; }
        public string ProdAlm_SubElmd { get; set; }
        public Nullable<int> ProdAlm_CodClasifP { get; set; }
        public Nullable<int> ProdAlm_NormaConsumo { get; set; }
        public Nullable<bool> ProdAlm_NoActivo { get; set; }
        public Nullable<decimal> ProdAlm_CicloReap { get; set; }
    
        public virtual Almacenes Almacenes { get; set; }
        public virtual PC_Actividades PC_Actividades { get; set; }
        public virtual PC_Balancistas PC_Balancistas { get; set; }
        public virtual PC_ClasificacionP PC_ClasificacionP { get; set; }
    }
}
