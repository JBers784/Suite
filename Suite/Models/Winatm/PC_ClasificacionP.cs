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
    
    public partial class PC_ClasificacionP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PC_ClasificacionP()
        {
            this.Productos_Almacen = new HashSet<Productos_Almacen>();
        }
    
        public int CodClasifP { get; set; }
        public string DescClasifP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productos_Almacen> Productos_Almacen { get; set; }
    }
}
