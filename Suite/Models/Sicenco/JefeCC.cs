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
    
    public partial class JefeCC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JefeCC()
        {
            this.CCostos = new HashSet<CCostos>();
        }
    
        public int JefeCC_Id { get; set; }
        public string JefeCC_Descrip { get; set; }
        public byte[] JefeCC_Firma { get; set; }
        public byte[] JefeCC_Foto { get; set; }
        public string JefeCC_CtaUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CCostos> CCostos { get; set; }
    }
}
