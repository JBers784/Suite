using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ModuloTransporte;

namespace Suite.Models.Transporte
{
    public class OrdenesTrabajo
    {
        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Fechaini { get; set; }

        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Fechafin { get; set; }

        public string Matricula { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Fecha { get; set; }

        public string NumOrdenTrabajo { get; set; }

        public string Materiales { get; set; }

        public string Um { get; set; }

        public decimal Cantidad { get; set; }

        public OrdenesTrabajo()
        {
            Fechaini = DateTime.Parse("01/" + (DateTime.Now.Month) + "/" + DateTime.Now.Year);
            Fechafin = DateTime.Now;
        }

        public OrdenesTrabajo(DateTime fecha, string numOrdenT, string materiales, string um, decimal cant, string matricula)
        {
            this.Fecha = fecha;
            NumOrdenTrabajo = numOrdenT;
            this.Materiales = materiales;
            this.Um = um;
            Cantidad = cant;
            this.Matricula = matricula;
        }

        public List<OrdenesTrabajo> listar(DateTime? fechainicial, DateTime? fechafinal, string matricula)
        {
            SitransEntities entities = new SitransEntities();
            List<OrdenesTrabajo> lista = new List<OrdenesTrabajo>();

            var consulta = (from ot in entities.OrdenesTrabajo
                            join equip in entities.Equipos on ot.eq_NumOperacional equals equip.eq_NumOperacional
                            join detot in entities.DetOT_Materiales on ot.ot_Id equals detot.ot_Id
                            join existaller in entities.ExistProd_Taller on detot.ept_Id equals existaller.ept_Id
                            where (detot.dotm_Fecha >= fechainicial) && (detot.dotm_Fecha <= fechafinal) && (equip.eq_matricula == matricula)
                            orderby detot.dotm_Fecha ascending
                            select new
                            {
                                numOt = ot.ot_NoOT + " - " + ot.ot_Mes + " - " + ot.ot_Año,
                                equip.eq_matricula,
                                detot.dotm_Fecha,
                                ot.mmant_Id,
                                existaller.ept_Desc,
                                existaller.ept_UM,
                                detot.dotm_Cantidad
                            })
                             
                             .ToList();
            if (consulta.Count > 0)
            {
                foreach (var ot in consulta)
                {

                    lista.Add(new OrdenesTrabajo(ot.dotm_Fecha, ot.numOt, ot.ept_Desc, ot.ept_UM, ot.dotm_Cantidad, ot.eq_matricula));
                }
                
            }


            return lista;

        }

    }
}