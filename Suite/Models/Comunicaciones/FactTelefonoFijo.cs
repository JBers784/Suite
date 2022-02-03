using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModuloComunicaciones;


namespace Suite.Models.Comunicaciones
{
    public class FactTelefonoFijo: Web_FacturaTelFijo_Result 

    {
        public DateTime? Fecha { get; set; }
        public FactTelefonoFijo Listar(DateTime? fecha)
        {
            if (fecha == null || fecha >= DateTime.Now)
            {
                fecha = DateTime.Now.AddDays(-1);
            }
            FacSeComEntities entities = new FacSeComEntities();
            var consulta = entities.Web_FacturaTelFijo(fecha.Value.Month - 2, fecha.Value.Year, "822-41579").FirstOrDefault();
            FactTelefonoFijo resp = new FactTelefonoFijo
            {
                mfac  = consulta.mfac ,
                noft  = consulta.noft ,
                cent  = consulta.cent ,
                telf  = consulta.telf ,
                docn  = consulta.docn ,
                dia  = consulta.dia ,
                mes = consulta.mes ,
                dest  = consulta.dest ,
                slla = consulta.slla ,
                hora  = consulta.hora ,
                clav  = consulta.clav ,
                mins  = consulta.mins ,
                segs  = consulta.segs ,
                puls  = consulta.puls ,
                impt = consulta.impt ,
                cargo = consulta.cargo ,
                mon = consulta.mon ,
                Entrada = consulta.Entrada ,
                ubicacion = consulta.ubicacion 
            };
            return resp;
        }

    }
}