//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suite.Models.Sicenco
{
    using System;
    using System.Collections.Generic;
    
    public partial class OT_FacturaServicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OT_FacturaServicio()
        {
            this.OT_EquipoFactServ = new HashSet<OT_EquipoFactServ>();
        }
    
        public int fs_NoFact { get; set; }
        public Nullable<System.DateTime> fs_Fecha { get; set; }
        public string fs_Proveedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OT_EquipoFactServ> OT_EquipoFactServ { get; set; }
    }
}