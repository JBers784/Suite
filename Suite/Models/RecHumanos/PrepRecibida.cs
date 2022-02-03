using ModuloRecHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.RecHumanos
{
    public class PrepRecibida
    {
        public string Ci { get; set; }
        public string Nombre { get; set; }
        public string Accion { get; set; }
        public string Evaluacion { get; set; }
        public string Institucion { get; set; }
        public string Observacion { get; set; }
        public string numCobro { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }

        public PrepRecibida() { }
        public List<PrepRecibida> ListaC(string ci)
        {
            CapitalHumanoEntities entities = new CapitalHumanoEntities();
            List<PrepRecibida> resp = new List<PrepRecibida>();
            try
            {
                if (!string.IsNullOrEmpty(ci))
                {
                    resp = (from preprecib in entities.PreparacionRecibida 
                            join evalcapacit in entities.EvaluacionesCapacitacion on preprecib.evcap_Id        equals evalcapacit.evcap_Id 
                            join instituc    in entities.Institucion              on preprecib.Institucion_Id  equals instituc.Institucion_Id 
                            join datospers   in entities.Datos_Personales         on preprecib.CIdentidad      equals datospers.CIdentidad 
                            join trabaj      in entities.Trabajador               on datospers.CIdentidad      equals trabaj.CIdentidad 
                            join plantpers   in entities.Plantilla_Personal       on trabaj.Num_Cobro          equals plantpers.Num_Cobro 
                            join Carea       in entities.Area                     on plantpers.Cod_Area        equals Carea.Cod_Area
                            join Ccargo in entities.Cargo on plantpers.Cod_Cargo equals Ccargo.Cod_Cargo
                            where datospers.CIdentidad == ci
                            orderby preprecib.pr_FechaIni descending
                            select new PrepRecibida
                            {
                                Ci = datospers.CIdentidad,
                                Nombre = datospers.dp_NombreApellidos,
                                Accion = preprecib.pr_Accion ,
                                FechaIni  = preprecib.pr_FechaIni ,
                                FechaFin= preprecib.pr_FechaFin,
                                Evaluacion  = evalcapacit.evcap_Desc ,
                                Institucion  = instituc.Institucion_Desc ,
                                numCobro = trabaj.Num_Cobro,
                                area = Carea.DescripArea,
                                cargo = Ccargo.DescripCargo,
                                Observacion = preprecib.pr_Observaciones 
                            }).ToList();
                }
            }
            catch { }
            return resp;
        }

    }
}