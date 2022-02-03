using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ModuloProduccion;

namespace Suite.Models.Produccion
{
    public class ProdVentaPet:fWeb_VentasPetr_Result
    {
        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Fecha { get; set; }
        public ProdVentaPet Listar(DateTime? fecha)
        {
            if (fecha == null || fecha >= DateTime.Now)
            {
                fecha = DateTime.Now.AddDays(-1);
            }
            ProduccionEntity entities = new ProduccionEntity();
            var consulta = entities.fWeb_VentasPetr(fecha).FirstOrDefault();
            ProdVentaPet resp = new ProdVentaPet
            {
                PlanDiaCentroVPet = consulta.PlanDiaCentroVPet,
                RealDiaCentroVPet = consulta.RealDiaCentroVPet,
                PlanMesCentroVPet = consulta.PlanMesCentroVPet,
                RealMesCentroVPet = consulta.RealMesCentroVPet,
                PorcDiaCentroVPet = consulta.PorcDiaCentroVPet,
                DesvDiaCentroVPet = consulta.DesvDiaCentroVPet,
                PlanAnoCentroVPet = consulta.PlanAnoCentroVPet,
                RealAnoCentroVPet = consulta.RealAnoCentroVPet,
                PorcMesCentroVPet = consulta.PorcMesCentroVPet,
                DesvMesCentroVPet = consulta.DesvMesCentroVPet,
                PorcAnoCentroVPet = consulta.PorcAnoCentroVPet,
                DesvAnoCentroVPet = consulta.DesvAnoCentroVPet,
                PlanDiaMajVPet = consulta.PlanDiaMajVPet,
                RealDiaMajVPet = consulta.RealDiaMajVPet,
                PlanMesMajVPet = consulta.PlanMesMajVPet,
                RealMesMajVPet = consulta.RealMesMajVPet,
                PlanAnoMajVPet = consulta.PlanAnoMajVPet,
                RealAnoMajVPet = consulta.RealAnoMajVPet,
                PorcDiaMajVPet = consulta.PorcDiaMajVPet,
                DesvDiaMajVPet = consulta.DesvDiaMajVPet,
                PorcMesMajVPet = consulta.PorcMesMajVPet,
                DesvMesMajVPet = consulta.DesvMesMajVPet,
                PorcAnoMajVPet = consulta.PorcAnoMajVPet,
                DesvAnoMajVPet = consulta.DesvAnoMajVPet,
                PlanDiaEmpVPet = consulta.PlanDiaEmpVPet,
                RealDiaEmpVPet = consulta.RealDiaEmpVPet,
                PlanMesEmpVPet = consulta.PlanMesEmpVPet,
                RealMesEmpVPet = consulta.RealMesEmpVPet,
                PorcDiaEmpVPet = consulta.PorcDiaEmpVPet,
                DesvDiaEmpVPet = consulta.DesvDiaEmpVPet,
                PorcMesEmpVPet = consulta.PorcMesEmpVPet,
                DesvMesEmpVPet = consulta.DesvMesEmpVPet,
                PlanAnoEmpVPet = consulta.PlanAnoEmpVPet,
                RealAnoEmpVPet = consulta.RealAnoEmpVPet,
                PorcAnoEmpVPet = consulta.PorcAnoEmpVPet,
                DesvAnoEmpVPet = consulta.DesvAnoEmpVPet,
                Fecha = fecha

            };
            return resp;
        }
    }
}