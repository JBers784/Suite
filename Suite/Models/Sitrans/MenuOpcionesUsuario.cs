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
    
    public partial class MenuOpcionesUsuario
    {
        public string Login { get; set; }
        public string mnu_Nombre { get; set; }
        public bool RW { get; set; }
    
        public virtual MenuOpciones MenuOpciones { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}