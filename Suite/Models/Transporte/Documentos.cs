using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ModuloTransporte;

namespace Suite.Models.Transporte
{
    public class Documentos
    {
        //[Required(ErrorMessage = "Complete este Campo")]
        public string equipo { get; set; }

        public string doc { get; set; }
        public DateTime  expedida { get; set; }
        public DateTime  vence { get; set; }

        public string  ccosto { get; set; }

        public string equipomodelo { get; set; }
        public string annoFabricacion { get; set; }

        public Documentos()
        {
                   }


        public Documentos (string equipo, string doc, DateTime  expedida, DateTime  vence, string ccosto, string descmodelo, string annoFabricacion)
        {
            this.equipo  = equipo ;
            this.doc = doc;
            this.expedida  = expedida ;
            this.vence = vence;
            this.ccosto = ccosto;
            equipomodelo  = descmodelo ;
            this.annoFabricacion = annoFabricacion;
        }

        public List<Documentos> DocumentosxEquipo(string matricula)
        {
            SitransEntities entities = new SitransEntities();
            List<Documentos> res = new List<Documentos>();
                var consulta = (from control in entities.ControlDocEquipos
                                join equip in entities.Equipos on control.eq_NumOperacional equals equip.eq_NumOperacional
                                join ccosto in entities.CentrosCostos on equip.ccosto_Id equals ccosto.ccosto_id  
                                join mundodoc in entities.mundo_Documentos on control.mdoc_id equals mundodoc.mdoc_id
                                join mundoeq in entities.mundo_Equipos on equip.meq_Id  equals mundoeq.meq_Id 
                                where ((equip.eq_matricula == matricula))
                                orderby mundodoc.mdoc_Desc ascending
                                select new
                                {
                                    equip.eq_matricula,
                                    mundodoc.mdoc_Desc,
                                    equip.eq_AñoFabricacion,
                                    control.cde_FechaExp,
                                    control.cde_FechaVence,
                                    ccosto.ccosto_codcencos,
                                    ccosto.ccosto_descrip,
                                    mundoeq.meq_Desc,
                                    mundoeq.meq_Modelo 
                                    

                                }).ToList();

                foreach (var item in consulta)
                {
                    res.Add(new Documentos (item.eq_matricula , item.mdoc_Desc , item.cde_FechaExp ,item.cde_FechaVence ,"["+item.ccosto_codcencos +"] "+item.ccosto_descrip  ,item .meq_Desc+" "+item.meq_Modelo , item.eq_AñoFabricacion));
                }
                return res;
        }
    }
}