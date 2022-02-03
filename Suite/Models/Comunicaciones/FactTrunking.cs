using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloComunicaciones;

namespace Suite.Models.Comunicaciones
{
    public class FactTrunking : Web_FacturaTrunking_Result 
    {
        public DateTime? Fecha { get; set; }
        public FactTrunking Listar(DateTime? fecha)
        {
            if (fecha == null || fecha >= DateTime.Now)
            {
                fecha = DateTime.Now.AddDays(-1);
            }
            FacSeComEntities entities = new FacSeComEntities();
            var consulta = entities.Web_FacturaTrunking (fecha.Value.Month-2 , fecha.Value.Year ,"822-41579" ).FirstOrDefault();
            FactTrunking resp = new FactTrunking
            {
                NumFact = consulta.NumFact ,
                NumTrunking = consulta.NumTrunking ,
                TarifaFija  = consulta.TarifaFija ,
                MinRadio  = consulta.MinRadio ,
                ImptRadio  = consulta.ImptRadio ,
                MinTelef  = consulta.MinTelef ,
                ImptTelef  = consulta.ImptTelef ,
                MinPABX  = consulta.MinPABX ,
                ImptPABX  = consulta.ImptPABX ,
                ImptOtros  = consulta.ImptOtros ,
                Total  = consulta.Total ,
                Entrada  = consulta.Entrada ,
                CCosto  = consulta.CCosto ,
                NumCobro  = consulta.NumCobro ,
                dp_NombreApellidos  = consulta.dp_NombreApellidos 
 
            };
            return resp;
        }
    }
}