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
    
    public partial class LugarCarga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LugarCarga()
        {
            this.DetallesHojaRuta = new HashSet<DetallesHojaRuta>();
        }
    
        public int LCarga_ID { get; set; }
        public string LCarga_Nombre { get; set; }
        public short ent_Id { get; set; }
        public bool LCarga_Inactivo { get; set; }
        public string Cod_DPA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesHojaRuta> DetallesHojaRuta { get; set; }
        public virtual Entidades Entidades { get; set; }
    }
}
