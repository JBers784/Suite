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
    
    public partial class ConfigTrasiegosInstalac
    {
        public string IdOrigen { get; set; }
        public string IdDestino { get; set; }
        public string TipoTrasiego { get; set; }
    
        public virtual CodInstalaciones CodInstalaciones { get; set; }
        public virtual CodInstalaciones CodInstalaciones1 { get; set; }
    }
}
