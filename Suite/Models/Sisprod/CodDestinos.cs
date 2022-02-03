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
    
    public partial class CodDestinos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CodDestinos()
        {
            this.BuquesTransito = new HashSet<BuquesTransito>();
            this.PlanEntGas = new HashSet<PlanEntGas>();
            this.PlanVGas = new HashSet<PlanVGas>();
            this.PlanVPet = new HashSet<PlanVPet>();
            this.VPetInstalac = new HashSet<VPetInstalac>();
            this.VPetPailas = new HashSet<VPetPailas>();
            this.VPetPozos = new HashSet<VPetPozos>();
            this.VGasDulce = new HashSet<VGasDulce>();
            this.VGasGasod = new HashSet<VGasGasod>();
            this.VGasPozos = new HashSet<VGasPozos>();
        }
    
        public string CodDestino { get; set; }
        public string DescDestino { get; set; }
        public string CodTipoDestino { get; set; }
        public decimal FactorConsumo { get; set; }
        public string CodProvincia { get; set; }
        public Nullable<int> CodCentral { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuquesTransito> BuquesTransito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanEntGas> PlanEntGas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanVGas> PlanVGas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanVPet> PlanVPet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPetInstalac> VPetInstalac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPetPailas> VPetPailas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPetPozos> VPetPozos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VGasDulce> VGasDulce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VGasGasod> VGasGasod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VGasPozos> VGasPozos { get; set; }
    }
}