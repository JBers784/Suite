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
    
    public partial class mundo_MarcasNeumaticos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mundo_MarcasNeumaticos()
        {
            this.mundo_neumaticos = new HashSet<mundo_neumaticos>();
        }
    
        public short mmneum_Id { get; set; }
        public short mp_Id { get; set; }
        public string mmneum_Marca { get; set; }
    
        public virtual mundo_Paises mundo_Paises { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mundo_neumaticos> mundo_neumaticos { get; set; }
    }
}
