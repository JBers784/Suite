//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suite.Models.Sisprod
{
    using System;
    using System.Collections.Generic;
    
    public partial class CodSrv
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CodSrv()
        {
            this.PlanSolventes = new HashSet<PlanSolventes>();
            this.Srv = new HashSet<Srv>();
            this.TanquesSolvente = new HashSet<TanquesSolvente>();
        }
    
        public string IdSrv { get; set; }
        public string DescSrv { get; set; }
        public decimal Densidad { get; set; }
        public string UM { get; set; }
        public string CodCUP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanSolventes> PlanSolventes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Srv> Srv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TanquesSolvente> TanquesSolvente { get; set; }
    }
}
