using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ModuloTransporte;

namespace Suite.Models.Transporte
{
    public class Combustible
    {
        SitransEntities entities = new SitransEntities();

        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechadocini { get; set; }

        [Required(ErrorMessage = "Complete este Campo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechadocfin { get; set; }

        public DateTime fechadoc { get; set; }

        //[Required(ErrorMessage = "Complete este Campo")]
        public string matricula { get; set; }

        public string notargeta { get; set; }
        public decimal saldoFinalTarjetaLtros { get; set; }
        public decimal saldoFinalTarjetaDinero { get; set; }
        public string ccostoid { get; set; }
        public string ccostodesc { get; set; }

        public decimal litros { get; set; }

        public string servicentro { get; set; }

        public Combustible() {

            fechadocini = DateTime.Parse("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            fechadocfin = DateTime.Now;
        }

        public Combustible( DateTime fechadoc, string matricula, string notargeta, string ccostoid, string ccostodesc, decimal litros, string servicentro, DateTime fechadocfin)
        {
            
            this.fechadoc = fechadoc;
            this.matricula = matricula;
            this.notargeta = notargeta;
            this.ccostoid = ccostoid;
            this.ccostodesc = ccostodesc;
            this.litros = litros;
            this.servicentro = servicentro;
            CombustibleenTargeta(notargeta,fechadocfin);
        }

        public int MatricOccosto(string matriculaoccosto)
        {
            
            if ((from c in entities.CentrosCostos where(c.ccosto_codcencos.ToLower().Contains(matriculaoccosto.ToLower())) select c).FirstOrDefault() != null)
            {
                return 1;
            }
            if ((from c in entities.Equipos where (c.eq_matricula.ToLower().Contains(matriculaoccosto.ToLower())) select c).FirstOrDefault() != null)
            {
                return 2;
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matricOccosto">1 es CCostos 2 es matricula 0 es vacio</param>
        /// <param name="matriculaoccosto">#de la matricula o el ccosto</param>
        /// <param name="fechainidoc"></param>
        /// <param name="fechafindoc"></param>
        /// <returns></returns>
        public List<Combustible> CombustiblexTargeta (int matricOccosto, string matriculaoccosto, DateTime? fechainidoc, DateTime? fechafindoc)
        {
                     
            List<Combustible> res = new List<Combustible>();
            if (matricOccosto == 1)
            {
                var consulta = (from comb in entities.ConsCombMotBT
                                join ccosto in entities.CentrosCostos on comb.ccosto_id equals ccosto.ccosto_id
                                join equip in entities.Equipos on comb.eq_NumOperacional equals equip.eq_NumOperacional
                                join ld in entities.LugarDescarga on comb.ldesc_ID equals ld.ldesc_ID
                                where ((ccosto.ccosto_codcencos.ToLower().Contains(matriculaoccosto.ToLower())) & (comb.cm_FechaDoc >= fechainidoc) & (comb.cm_FechaDoc <= fechafindoc))
                                orderby equip.eq_matricula, comb.cm_FechaDoc ascending
                                //group equip by equip.eq_matricula into grupo
                                select new
                                {
                                    comb.cm_FechaDoc,
                                    equip.eq_matricula,
                                    comb.te_No,
                                    ccosto.ccosto_codcencos,
                                    comb.CentrosCostos.ccosto_descrip,
                                    comb.cm_Litros,
                                    ld.ldesc_Nombre

                                }).ToList();

                foreach (var item in consulta)
                {
                    res.Add(new Combustible( item.cm_FechaDoc, item.eq_matricula, item.te_No, item.ccosto_codcencos, item.ccosto_descrip, item.cm_Litros, item.ldesc_Nombre, (DateTime)fechafindoc));
                }
                return res;
            }
            if (matricOccosto == 2)
            {
                var consulta = (from comb in entities.ConsCombMotBT
                            join ccosto in entities.CentrosCostos on comb.ccosto_id equals ccosto.ccosto_id 
                            join equip in entities.Equipos on comb.eq_NumOperacional equals equip.eq_NumOperacional
                            join ld in entities.LugarDescarga on comb.ldesc_ID equals ld.ldesc_ID
                            where ((equip.eq_matricula.ToLower().Contains(matriculaoccosto.ToLower())) & (comb.cm_FechaDoc >= fechainidoc) & (comb.cm_FechaDoc <= fechafindoc))
                            orderby comb.cm_FechaDoc ascending
                                select new
                            {
                                comb.cm_FechaDoc,
                                equip.eq_matricula,
                                comb.te_No,
                                ccosto.ccosto_codcencos,
                                comb.CentrosCostos.ccosto_descrip,
                                comb.cm_Litros,
                                ld.ldesc_Nombre

                            }).ToList();
                foreach (var item in consulta)
                {
                    res.Add(new Combustible( item.cm_FechaDoc, item.eq_matricula, item.te_No, item.ccosto_codcencos, item.ccosto_descrip, item.cm_Litros, item.ldesc_Nombre, (DateTime)fechafindoc));
                }
                return res;
            }

            return res;
        }

        public void CombustibleenTargeta(string notarjeta, DateTime? fecha)
        {
            var saldoLtros =(from submayor in entities.SubmayorTarjetasExternas  
                           join tarjetasExternas in entities.TarjetasExternas on submayor.te_No equals tarjetasExternas.te_No
                           where submayor.ste_FechaDoc <= fecha && tarjetasExternas.te_No == notarjeta
                           orderby submayor.ste_Fecha descending
                           select new
                           {
                             saldoLtros = submayor.ste_SaldoLts,
                             saldodinero = submayor.ste_Saldo_

                            }).FirstOrDefault();
            if (saldoLtros != null)
            {
                saldoFinalTarjetaLtros = saldoLtros.saldoLtros;
                saldoFinalTarjetaDinero = saldoLtros.saldodinero;
            }
           

        }
    }
}