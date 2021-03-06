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
    
    public partial class CodInstalaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CodInstalaciones()
        {
            this.AfectUnidadesGeneradoras = new HashSet<AfectUnidadesGeneradoras>();
            this.CodProdPlantasGas = new HashSet<CodProdPlantasGas>();
            this.ConfigTrasiegoGas = new HashSet<ConfigTrasiegoGas>();
            this.ConfigTrasiegosInstalac = new HashSet<ConfigTrasiegosInstalac>();
            this.ConfigTrasiegosInstalac1 = new HashSet<ConfigTrasiegosInstalac>();
            this.DatosUnidadesGeneradoras = new HashSet<DatosUnidadesGeneradoras>();
            this.InsumosRecol = new HashSet<InsumosRecol>();
            this.ParamTHD = new HashSet<ParamTHD>();
            this.VPetInstalac = new HashSet<VPetInstalac>();
            this.VPetPailas = new HashSet<VPetPailas>();
            this.VGasDulce = new HashSet<VGasDulce>();
            this.UsuariosApp = new HashSet<UsuariosApp>();
        }
    
        public string IdInstalacion { get; set; }
        public string DescInstalacion { get; set; }
        public string CodTipoInstalacion { get; set; }
        public string CodTaller { get; set; }
        public string Estado { get; set; }
        public byte IdUEB { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AfectUnidadesGeneradoras> AfectUnidadesGeneradoras { get; set; }
        public virtual CodTipoInstalacion CodTipoInstalacion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodProdPlantasGas> CodProdPlantasGas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfigTrasiegoGas> ConfigTrasiegoGas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfigTrasiegosInstalac> ConfigTrasiegosInstalac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfigTrasiegosInstalac> ConfigTrasiegosInstalac1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosUnidadesGeneradoras> DatosUnidadesGeneradoras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InsumosRecol> InsumosRecol { get; set; }
        public virtual OperActuales OperActuales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParamTHD> ParamTHD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPetInstalac> VPetInstalac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPetPailas> VPetPailas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VGasDulce> VGasDulce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosApp> UsuariosApp { get; set; }
    }
}
