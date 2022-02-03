using ModuloProduccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Suite.Models.Produccion
{
    public class ProdPetroleo : fWeb_ProdPetroleo_Result
    {
        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Fecha { get; set; }
        public ProdPetroleo Listar(DateTime? fecha)
        {
            if (fecha == null || fecha >= DateTime.Now)
            {
                fecha = DateTime.Now.AddDays(-1);
            }
            ProduccionEntity entities = new ProduccionEntity();
            var consulta = entities.fWeb_ProdPetroleo(fecha).FirstOrDefault();
            ProdPetroleo resp = new ProdPetroleo
            {
                PlanDiaCentroT = consulta.PlanDiaCentroT,
                RealDiaCentroT = consulta.RealDiaCentroT,
                PlanDiaCentroN = consulta.PlanDiaCentroN,
                RealDiaCentroN = consulta.RealDiaCentroN,
                PlanDiaCentroTot = consulta.PlanDiaCentroTot,
                RealDiaCentroTot = consulta.RealDiaCentroTot,
                PlanDiaMajT = consulta.PlanDiaMajT,
                RealDiaMajT = consulta.RealDiaMajT,
                PlanDiaMajN = consulta.PlanDiaMajN,
                RealDiaMajN = consulta.RealDiaMajN,
                PlanDiaMajTot = consulta.PlanDiaMajTot,
                RealDiaMajTot = consulta.RealDiaMajTot,
                PlanDiaEmpT = consulta.PlanDiaEmpT,
                RealDiaEmpT = consulta.RealDiaEmpT,
                PlanDiaEmpN = consulta.PlanDiaEmpN,
                RealDiaEmpN = consulta.RealDiaEmpN,
                PlanDiaEmpTot = consulta.PlanDiaEmpTot,
                RealDiaEmpTot = consulta.RealDiaEmpTot,
                PlanMesCentroT = consulta.PlanMesCentroT,
                RealMesCentroT = consulta.RealMesCentroT,
                PlanMesCentroN = consulta.PlanMesCentroN,
                RealMesCentroN = consulta.RealMesCentroN,
                PlanMesCentroTot = consulta.PlanMesCentroTot,
                RealMesCentroTot = consulta.RealMesCentroTot,
                PlanMesMajT = consulta.PlanMesMajT,
                RealMesMajT = consulta.RealMesMajT,
                PlanMesMajN = consulta.PlanMesMajN,
                RealMesMajN = consulta.RealMesMajN,
                PlanMesMajTot = consulta.PlanMesMajTot,
                RealMesMajTot = consulta.RealMesMajTot,
                PlanMesEmpT = consulta.PlanMesEmpT,
                RealMesEmpT = consulta.RealMesEmpT,
                PlanMesEmpN = consulta.PlanMesEmpN,
                RealMesEmpN = consulta.RealMesEmpN,
                PlanMesEmpTot = consulta.PlanMesEmpTot,
                RealMesEmpTot = consulta.RealMesEmpTot,
                PlanAnoCentroT = consulta.PlanAnoCentroT,
                RealAnoCentroT = consulta.RealAnoCentroT,
                PlanAnoCentroN = consulta.PlanAnoCentroN,
                RealAnoCentroN = consulta.RealAnoCentroN,
                PlanAnoCentroTot = consulta.PlanAnoCentroTot,
                RealAnoCentroTot = consulta.RealAnoCentroTot,
                PlanAnoMajT = consulta.PlanAnoMajT,
                RealAnoMajT = consulta.RealAnoMajT,
                PlanAnoMajN = consulta.PlanAnoMajN,
                RealAnoMajN = consulta.RealAnoMajN,
                PlanAnoMajTot = consulta.PlanAnoMajTot,
                RealAnoMajTot = consulta.RealAnoMajTot,
                PlanAnoEmpT = consulta.PlanAnoEmpT,
                RealAnoEmpT = consulta.RealAnoEmpT,
                PlanAnoEmpN = consulta.PlanAnoEmpN,
                RealAnoEmpN = consulta.RealAnoEmpN,
                PlanAnoEmpTot = consulta.PlanAnoEmpTot,
                RealAnoEmpTot = consulta.RealAnoEmpTot,
                Fecha = fecha

            };
            return resp;
        }

    }
}
