using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModuloComunicaciones;

namespace Suite.Models.Comunicaciones
{
    public class FactTelefonoCelular : Web_FactCelulares_Result
    {
        public DateTime? Fecha { get; set; }
        public FactTelefonoCelular Listar(DateTime? fecha)
        {
            if (fecha == null || fecha >= DateTime.Now)
            {
                fecha = DateTime.Now.AddDays(-1);
            }
            FacSeComEntities entities = new FacSeComEntities();
            var consulta = entities.Web_FactCelulares(fecha.Value.Month - 2, fecha.Value.Year, "822-41579").FirstOrDefault();
            FactTelefonoCelular resp = new FactTelefonoCelular
            {
                Numero  = consulta.Numero ,
                Ubicacion  = consulta.Ubicacion ,
                Custodio  = consulta.Custodio ,
                CCosto  = consulta.CCosto ,
                DescCCosto  = consulta.DescCCosto ,
                Subdir  = consulta.Subdir ,
                DescSubdir  = consulta.DescSubdir ,
                NumFact  = consulta.NumFact ,
                NumCelular  = consulta.NumCelular ,
                Llamadas_Recib  = consulta.Llamadas_Recib ,
                Llamadas_Orig  = consulta.Llamadas_Orig ,
                Llamadas_Pico  = consulta.Llamadas_Pico ,
                Llamadas_NoPico  = consulta.Llamadas_NoPico ,
                Costos_Recib  = consulta.Costos_Recib ,
                Costos_Orig  = consulta.Costos_Orig ,
                Costos_Pico  = consulta.Costos_Pico ,
                Costos_NoPico  = consulta.Costos_NoPico ,
                Durac_Recib =consulta .Durac_Recib ,
                Durac_Orig =consulta .Durac_Orig ,
                Durac_Pico =consulta .Durac_Pico ,
                Durac_NoPico =consulta .Durac_NoPico ,
                Llamadas_Internac =consulta .Llamadas_Internac ,
                Llamadas_Nac =consulta .Llamadas_Nac ,
                Costos_Internac =consulta .Costos_Internac ,
                Costos_Nac =consulta .Costos_Nac ,
                Durac_Internac =consulta .Durac_Internac ,
                Durac_Nac =consulta .Durac_Nac ,
                SMS_Recib =consulta .SMS_Recib ,
                SMS_Orig =consulta .SMS_Orig ,
                SMS_Pico =consulta .SMS_Pico ,
                SMS_NoPico =consulta .SMS_NoPico ,
                CostosSMS_Recib =consulta .CostosSMS_Recib ,
                CostosSMS_Orig =consulta .CostosSMS_Orig ,
                CostosSMS_Pico =consulta .CostosSMS_Pico ,
                CostosSMS_NoPico =consulta .CostosSMS_NoPico ,
                SMS_LargaD =consulta .SMS_LargaD ,
                SMS_LargaD_Costos =consulta .SMS_LargaD_Costos ,
                MMS_Recib =consulta .MMS_Recib ,
                MMS_Orig =consulta .MMS_Orig ,
                MMS_Pico =consulta .MMS_Pico ,
                MMS_NoPico =consulta .MMS_NoPico ,
                CostosMMS_Recib =consulta .CostosMMS_Recib ,
                CostosMMS_Orig =consulta .CostosMMS_Orig ,
                CostosMMS_Pico =consulta .CostosMMS_Pico ,
                CostosMMS_NoPico =consulta .CostosMMS_NoPico ,
                CostosGPRS_Pico =consulta .CostosGPRS_Pico ,
                CostosGPRS_NoPico =consulta .CostosGPRS_NoPico ,
                DiasUso =consulta .DiasUso ,
                Total =consulta .Total ,
                Entrada = consulta.Entrada,
                Fecha =consulta .Fecha ,
                PlanMin =consulta .PlanMin  
            };
            return resp;
        }

    }
}