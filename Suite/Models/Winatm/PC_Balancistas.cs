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
    
    public partial class PC_Balancistas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PC_Balancistas()
        {
            this.PC_PlanCompras = new HashSet<PC_PlanCompras>();
            this.PC_ProdNOAlmacen = new HashSet<PC_ProdNOAlmacen>();
            this.Productos_Almacen = new HashSet<Productos_Almacen>();
        }
    
        public int Balanc_id { get; set; }
        public string Balanc_Login { get; set; }
        public string Balanc_desc { get; set; }
        public string ccosto { get; set; }
        public string Pass { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> telefono { get; set; }
        public string Ip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_PlanCompras> PC_PlanCompras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_ProdNOAlmacen> PC_ProdNOAlmacen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productos_Almacen> Productos_Almacen { get; set; }
    }
}
