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
    
    public partial class mundo_Brigadas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mundo_Brigadas()
        {
            this.DetOT_ManoObra = new HashSet<DetOT_ManoObra>();
            this.mundo_Obreros = new HashSet<mundo_Obreros>();
        }
    
        public byte mtaller_id { get; set; }
        public byte mBrig_id { get; set; }
        public string mBrig_Desc { get; set; }
        public bool BrigExcluida { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetOT_ManoObra> DetOT_ManoObra { get; set; }
        public virtual mundo_Talleres mundo_Talleres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mundo_Obreros> mundo_Obreros { get; set; }
    }
}
