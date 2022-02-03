using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ModuloRecHumanos;

namespace Suite.Models.RecHumanos
{
    public class Cumpleaños
    {
        CapitalHumanoEntities entities = new CapitalHumanoEntities();

        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechaini { get; set; }

        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechafin { get; set; }

        public string dia { get; set; }
        public string mes { get; set; }
        public string NombAp { get; set; }
        public string Area { get; set; }
        public string ci { get; set; }

        public Cumpleaños()
        {

            fechaini = DateTime.Parse("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            fechafin = DateTime.Now;
        }

        public Cumpleaños(string dia, string mes, string NombAp, string Area, string ci)
        {

            this.dia = dia;
            this.mes = mes;
            this.NombAp = NombAp;
            this.Area = Area;
            this.ci = ci;
        }

        public List<Cumpleaños> CumpleañosxFecha(DateTime? fechaini, DateTime? fechafin)
        {

            List<Cumpleaños> res = new List<Cumpleaños>();
            var consulta = (from datospers in entities.Datos_Personales
                            join trabajad in entities.Trabajador on datospers.CIdentidad equals trabajad.CIdentidad into f
                            from trabajad in f.DefaultIfEmpty()
                            join plantpers in entities.Plantilla_Personal on trabajad.Num_Cobro equals plantpers.Num_Cobro
                            join area in entities.Area on plantpers.Cod_Area equals area.Cod_Area
                            //where (double.Parse(datospers.CIdentidad.Substring(3, 2)) <= fechafin.Value.Month) && (double.Parse(datospers.CIdentidad.Substring(3, 2)) >= fechaini.Value.Month) &&
                            //      (double.Parse(datospers.CIdentidad.Substring(5, 2)) <= fechafin.Value.Day) && (double.Parse(datospers.CIdentidad.Substring(5, 2)) >= fechaini.Value.Day)
                            orderby datospers.CIdentidad.Substring(4, 2) ascending, datospers.CIdentidad.Substring(2, 2) ascending, datospers.dp_NombreApellidos ascending
                            select new
                            {
                                dia = datospers.CIdentidad.Substring(4, 2),
                                mes = datospers.CIdentidad.Substring(2, 2),
                                NombAp = datospers.dp_NombreApellidos,
                                Area = area.DescripArea,
                                ci = datospers.CIdentidad
                            }).ToList().Where(x => (int.Parse(x.mes) <= fechafin.Value.Month &&  int.Parse(x.mes) >= fechaini.Value.Month && 
                                                    int.Parse(x.dia) <= fechafin.Value.Day && int.Parse(x.dia) >= fechaini.Value.Day));
            foreach (var item in consulta)
            {
                res.Add(new Cumpleaños(item.dia, item.mes, item.NombAp, item.Area, item.ci));
            }
            return res;
        }
    }
}