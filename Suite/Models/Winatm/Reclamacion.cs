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
    
    public partial class Reclamacion
    {
        public int Rec_Id { get; set; }
        public int Rec_NoReclamacion { get; set; }
        public int DetRecep_Id { get; set; }
        public byte TipoRec_Id { get; set; }
        public System.DateTime Rec_Fecha { get; set; }
        public string Rec_Estado { get; set; }
    
        public virtual Tipo_Reclamacion Tipo_Reclamacion { get; set; }
    }
}
