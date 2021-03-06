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
    
    public partial class Choferes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Choferes()
        {
            this.DistBonosCombEq = new HashSet<DistBonosCombEq>();
            this.EquiposAccidentes = new HashSet<EquiposAccidentes>();
            this.HojaRuta = new HashSet<HojaRuta>();
            this.RecaudaOmnibus = new HashSet<RecaudaOmnibus>();
            this.RegistroParqueos = new HashSet<RegistroParqueos>();
            this.rptCombHabKmsVehAdm = new HashSet<rptCombHabKmsVehAdm>();
        }
    
        public short c_Id { get; set; }
        public string c_Nombre { get; set; }
        public string c_NoLicConduccion { get; set; }
        public string c_CI { get; set; }
        public Nullable<System.DateTime> c_FVencNoLic { get; set; }
        public Nullable<System.DateTime> c_FUltimoChequeoMed { get; set; }
        public Nullable<System.DateTime> c_FUltimaRecalificacion { get; set; }
        public bool c_Inactivos { get; set; }
        public byte[] Foto { get; set; }
        public short dir_ID { get; set; }
    
        public virtual Direcciones Direcciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DistBonosCombEq> DistBonosCombEq { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquiposAccidentes> EquiposAccidentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HojaRuta> HojaRuta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecaudaOmnibus> RecaudaOmnibus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroParqueos> RegistroParqueos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rptCombHabKmsVehAdm> rptCombHabKmsVehAdm { get; set; }
    }
}
