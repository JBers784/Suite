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
    
    public partial class Conceptos_Ajustes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conceptos_Ajustes()
        {
            this.Ajustes = new HashSet<Ajustes>();
        }
    
        public byte ConcepAjuste_Id { get; set; }
        public string ConcepAjuste_Descrip { get; set; }
        public Nullable<byte> ConcepAjuste_IdS5 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ajustes> Ajustes { get; set; }
    }
}
