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
    
    public partial class DatosGasNoAsociado
    {
        public byte IdGrupo { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Flare { get; set; }
    
        public virtual CodGruposNoAsociados CodGruposNoAsociados { get; set; }
    }
}
