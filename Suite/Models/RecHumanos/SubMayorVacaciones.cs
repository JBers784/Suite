using ModuloEconomia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.RecHumanos
{
    public class SubMayorVacaciones
    {
        public string Nombre { get; set; }
        public string NumCobro { get; set; }
        public decimal? Tiempo { get; set; }
        public decimal? Importe { get; set; }

        public SubMayorVacaciones() { }

        public List<SubMayorVacaciones> ReporteVacaciones( string ccosto)
        {
            SicencoEntities db = new SicencoEntities();
            var submayor = db.Report_SubmayorVacacionesS5PWeb(ccosto).ToList(); ;

            List<SubMayorVacaciones> resp = new List<SubMayorVacaciones> ();
            foreach (var item in submayor)
            {
                SubMayorVacaciones temp = new SubMayorVacaciones()
                {
                    Nombre = item.Nombre,
                    NumCobro = item.NCobro,
                    Tiempo = Decimal.Round(item.Tiempo ?? 0, 3),
                    Importe = Decimal.Round(item.Importe ?? 0, 2)
                };
                resp.Add(temp);
            }
            return resp;
        }


    }
}