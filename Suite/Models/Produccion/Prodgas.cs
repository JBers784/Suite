using ModuloProduccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Suite.Models.Produccion
{
    public class Prodgas : fWeb_ProdGas_Result
    {
        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Fecha { get; set; }

        public Prodgas()
        {
            Fecha = DateTime.Now.Date;
        }
        public Prodgas Listar(DateTime? fecha)
        {
            if (fecha == null || fecha >= DateTime.Now)
            {
                fecha = DateTime.Now.AddDays(-1);
            }
            ProduccionEntity entities = new ProduccionEntity();
            var consulta = entities.fWeb_ProdGas(fecha).FirstOrDefault();
            Prodgas resp = new Prodgas
            {
                PlanDiaCentroG = consulta.PlanDiaCentroG,
                RealDiaCentroG = consulta.RealDiaCentroG,
                PlanMesCentroG = consulta.PlanMesCentroG,
                RealMesCentroG = consulta.RealMesCentroG,
                PorcDiaCentroG = consulta.PorcDiaCentroG,
                DesvDiaCentroG = consulta.DesvDiaCentroG,
                PlanAnoCentroG = consulta.PlanAnoCentroG,
                RealAnoCentroG = consulta.RealAnoCentroG,
                PorcMesCentroG = consulta.PorcMesCentroG,
                DesvMesCentroG = consulta.DesvMesCentroG,
                PorcAnoCentroG = consulta.PorcAnoCentroG,
                DesvAnoCentroG = consulta.DesvAnoCentroG,
                PlanDiaMajG = consulta.PlanDiaMajG,
                RealDiaMajG = consulta.RealDiaMajG,
                PlanMesMajG = consulta.PlanMesMajG,
                RealMesMajG = consulta.RealMesMajG,
                PlanAnoMajG = consulta.PlanAnoMajG,
                RealAnoMajG = consulta.RealAnoMajG,
                PorcDiaMajG = consulta.PorcDiaMajG,
                DesvDiaMajG = consulta.DesvDiaMajG,
                PorcMesMajG = consulta.PorcMesMajG,
                DesvMesMajG = consulta.DesvMesMajG,
                PorcAnoMajG = consulta.PorcAnoMajG,
                DesvAnoMajG = consulta.DesvAnoMajG,
                PlanDiaEmpG = consulta.PlanDiaEmpG,
                RealDiaEmpG = consulta.RealDiaEmpG,
                PlanMesEmpG = consulta.PlanMesEmpG,
                RealMesEmpG = consulta.RealMesEmpG,
                PorcDiaEmpG = consulta.PorcDiaEmpG,
                DesvDiaEmpG = consulta.DesvDiaEmpG,
                PorcMesEmpG = consulta.PorcMesEmpG,
                DesvMesEmpG = consulta.DesvMesEmpG,
                PlanAnoEmpG = consulta.PlanAnoEmpG,
                RealAnoEmpG = consulta.RealAnoEmpG,
                PorcAnoEmpG = consulta.PorcAnoEmpG,
                DesvAnoEmpG = consulta.DesvAnoEmpG,
                Fecha = fecha

            };
            return resp;
        }
    }
}