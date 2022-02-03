using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ModuloProduccion;

namespace Suite.Models.Produccion
{
    public class ProdPetroEquiv:fWeb_ProdPetrEquiv_Result
    {
        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Fecha { get; set; }
        public ProdPetroEquiv Listar(DateTime? fecha)
        {
            if (fecha == null || fecha >= DateTime.Now)
            {
                fecha = DateTime.Now.AddDays(-1);
            }
            ProduccionEntity entities = new ProduccionEntity();
            var consulta = entities.fWeb_ProdPetrEquiv(fecha).FirstOrDefault();
            ProdPetroEquiv resp = new ProdPetroEquiv
            {
                PlanDiaCentroPE = consulta.PlanDiaCentroPE,
                RealDiaCentroPE = consulta.RealDiaCentroPE,
                PlanMesCentroPE = consulta.PlanMesCentroPE,
                RealMesCentroPE = consulta.RealMesCentroPE,
                PorcDiaCentroPE = consulta.PorcDiaCentroPE,
                DesvDiaCentroPE = consulta.DesvDiaCentroPE,
                PlanAnoCentroPE = consulta.PlanAnoCentroPE,
                RealAnoCentroPE = consulta.RealAnoCentroPE,
                PorcMesCentroPE = consulta.PorcMesCentroPE,
                DesvMesCentroPE = consulta.DesvMesCentroPE,
                PorcAnoCentroPE = consulta.PorcAnoCentroPE,
                DesvAnoCentroPE = consulta.DesvAnoCentroPE,
                PlanDiaMajPE = consulta.PlanDiaMajPE,
                RealDiaMajPE = consulta.RealDiaMajPE,
                PlanMesMajPE = consulta.PlanMesMajPE,
                RealMesMajPE = consulta.RealMesMajPE,
                PlanAnoMajPE = consulta.PlanAnoMajPE,
                RealAnoMajPE = consulta.RealAnoMajPE,
                PorcDiaMajPE = consulta.PorcDiaMajPE,
                DesvDiaMajPE = consulta.DesvDiaMajPE,
                PorcMesMajPE = consulta.PorcMesMajPE,
                DesvMesMajPE = consulta.DesvMesMajPE,
                PorcAnoMajPE = consulta.PorcAnoMajPE,
                DesvAnoMajPE = consulta.DesvAnoMajPE,
                PlanDiaEmpPE = consulta.PlanDiaEmpPE,
                RealDiaEmpPE = consulta.RealDiaEmpPE,
                PlanMesEmpPE = consulta.PlanMesEmpPE,
                RealMesEmpPE = consulta.RealMesEmpPE,
                PorcDiaEmpPE = consulta.PorcDiaEmpPE,
                DesvDiaEmpPE = consulta.DesvDiaEmpPE,
                PorcMesEmpPE = consulta.PorcMesEmpPE,
                DesvMesEmpPE = consulta.DesvMesEmpPE,
                PlanAnoEmpPE = consulta.PlanAnoEmpPE,
                RealAnoEmpPE = consulta.RealAnoEmpPE,
                PorcAnoEmpPE = consulta.PorcAnoEmpPE,
                DesvAnoEmpPE = consulta.DesvAnoEmpPE,
                Fecha = fecha

            };
            return resp;
        }
    }
}