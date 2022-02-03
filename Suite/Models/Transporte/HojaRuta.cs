using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModuloTransporte;

namespace Suite.Models.Transporte
{
    public class HojaRuta
    {
        public string noHojaRuta { get; set; }

        public float km { get; set; }

        public decimal kmDisponibles { get; set; }

        public string matricula { get; set; }

        public string tipoMant { get; set; }

        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechaini { get; set; }

        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechafin { get; set; }

        public HojaRuta()
        {
            fechaini = DateTime.Parse("01/" + (DateTime.Now.Month) + "/" + DateTime.Now.Year);
            fechafin = DateTime.Now;
        }

        public HojaRuta(string noHojaRuta, float km)
        {
            this.noHojaRuta = noHojaRuta;
            this.km = km;          

        }

        public decimal Fx_KmDisponibles(string matricula)
        {
            SitransEntities entities = new SitransEntities();
            decimal resp = 0;
            var equipo = (from c in entities.Equipos where (c.eq_matricula == matricula) select c);
            if (equipo.Count() > 0)
            {
                resp = entities.Database.SqlQuery<decimal>(
                  "SELECT [dbo].[fx_KmsDispEq](@Matricula,@FechaLimite)",
                  new SqlParameter { ParameterName = "Matricula", Value = matricula },
                  new SqlParameter { ParameterName = "FechaLimite", Value = DateTime.Now }
               ).FirstOrDefault();
                return resp;

            }
            return resp;
        }

 
        public List<HojaRuta> Listado(string matricula, DateTime? fechainicial, DateTime? fechafinal)
        {
            SitransEntities entities = new SitransEntities();
            List<HojaRuta> resp = new List<HojaRuta>();
            var equipo = (from c in entities.Equipos where (c.eq_matricula == matricula) select c).FirstOrDefault();

            if (equipo != null)
            {
                var hojasRutas = (from c in entities.HojaRuta
                                  join detHr in entities.DetallesHojaRuta on c.HR_ID equals detHr.HR_ID
                                  where (c.eq_NumOperacional == equipo.eq_NumOperacional) && (detHr.dhr_Fecha >= fechainicial) && (detHr.dhr_Fecha <= fechafinal)
                                  orderby detHr.dhr_Fecha ascending
                                  select c).Distinct().ToList();
               
                if (hojasRutas.Count > 0)
                {
                    foreach (var item in hojasRutas)
                    {
                        var detHr = (from c in entities.DetallesHojaRuta
                                     where ((c.HR_ID == item.HR_ID))
                                     group c by c.HR_ID into g
                                     select new
                                     {
                                         kms = g.Sum(x => x.dhr_KmsRecorridos)
                                     }).First();
                        HojaRuta hr = new HojaRuta(item.hr_NoHR, detHr.kms);
                        resp.Add(hr);
                    }

                }
                else
                {


                    var hojasRutasAdmin = (
                        from c in entities.rptCombHabKmsVehAdm
                        where (c.eq_NumOperacional == equipo.eq_NumOperacional)
                        orderby c.NoRPT.Substring(7, 6) ascending
                        select c).ToList();

                    if (hojasRutasAdmin.Count > 0)
                    {
                        foreach (rptCombHabKmsVehAdm item in hojasRutasAdmin)
                        {

                            int mes = Int32.Parse(item.NoRPT.Substring(7, 2));
                            int anno = Int32.Parse(item.NoRPT.Substring(9, 4));
                            DateTime fecha = DateTime.Parse("01/" + mes + "/" + anno);

                            if (fecha >= fechainicial && fecha <= fechafin)
                            {
                               
                                    if (item.KmsRecTotal > 0)
                                    {
                                        HojaRuta hr = new HojaRuta(item.NoRPT, item.KmsRecTotal);
                                        resp.Add(hr);
                                    }
                               
                            }                           

                        }

                    }
                }
            }


            return resp;
        }

        public string TipoMantenimiento(string matricula)
        {
            try
            {

           
            SitransEntities entities = new SitransEntities();
                       
            Equipos equip = (from equipo in entities.Equipos  where (equipo.eq_Baja == false && equipo.eq_Propiedad == "EP" && equipo.eq_matricula == matricula)                            
                             select equipo).FirstOrDefault();
            if (equip == null)
            {
                return "No se encuentra el equipo";
            }
            //var motores = (from m in equip.Mantenimientos select m.Motores).Last();
            var mantinterno = (from mantenimientos in equip.Mantenimientos
                         join motores in entities.Motores on mantenimientos.motor_NumSerie equals motores.motor_NumSerie                         
                         join DetallesCiclosMantenimiento in entities.DetallesCiclosMantenimiento on motores.mundo_motores.mciclo_Id equals DetallesCiclosMantenimiento.mciclo_Id
                         where (motores.dcm_NoDeOrden == DetallesCiclosMantenimiento.dcm_NoDeOrden)
                         select new {
                             mantenimiento = DetallesCiclosMantenimiento.mmant_Id,
                             fecha = mantenimientos.mant_Fecha
                         }
                         ).ToList();
            var mantexterno = (from mantenimientosfuera in equip.Mtto_Fuera                              
                               join DetallesCiclosMantenimiento in entities.DetallesCiclosMantenimiento on mantenimientosfuera.mmant_Id equals DetallesCiclosMantenimiento.mmant_Id
                               //where (motoresfuera.dcm_NoDeOrden == DetallesCiclosMantenimiento.dcm_NoDeOrden)
                               select new
                               {
                                   mantenimiento = DetallesCiclosMantenimiento.mmant_Id,
                                   fecha = mantenimientosfuera.mttof_Fecha
                               }
                        ).ToList();

            if ((mantexterno.Count >0) && (mantexterno.LastOrDefault().fecha > mantinterno.LastOrDefault().fecha))
            {
                return mantexterno.LastOrDefault().mantenimiento;
            }
            else
            {
                return mantinterno.LastOrDefault().mantenimiento;
            }
            }
            catch (Exception e)
            {

                return "Error";
            }
           
        }

    }
}