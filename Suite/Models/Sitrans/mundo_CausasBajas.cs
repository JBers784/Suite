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
    
    public partial class mundo_CausasBajas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mundo_CausasBajas()
        {
            this.BajasEquipos = new HashSet<BajasEquipos>();
        }
    
        public short mcb_Id { get; set; }
        public string mcb_Desc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BajasEquipos> BajasEquipos { get; set; }
    }
}
