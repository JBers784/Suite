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
    
    public partial class AM_Alcance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AM_Alcance()
        {
            this.AM_Indicadores = new HashSet<AM_Indicadores>();
        }
    
        public string Alcance_id { get; set; }
        public string Alcance_desc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AM_Indicadores> AM_Indicadores { get; set; }
    }
}