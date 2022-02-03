using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModuloEconomia;

namespace Suite.Models.Economia
{
    public class Tirillas
    {
        public string RecibPago { get; set; }
        public int? Reporte { get; set; }
        public int? Corte { get; set; }
        public short? Mes { get; set; }
        public int Anno { get; set; }
        public string CentroPago { get; set; }
        public string NumCobro { get; set; }
        public string NombreCompleto { get; set; }
        public decimal? VacDias { get; set; }
        public decimal? VacImporte { get; set; }
        public decimal? Horastrabajadas { get; set; }
        public decimal? Tarifa { get; set; }
        public decimal? SalEsc { get; set; }
        public decimal? Cpagos { get; set; }
        public decimal? Padic { get; set; }
        public decimal? DevBruto { get; set; }
        public decimal? PorcCont { get; set; }
        public decimal? Cess { get; set; }
        public decimal? PorcImp { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Retenc { get; set; }
        public decimal? DescPdiv { get; set; }
        public decimal? Ajuste { get; set; }
        public decimal? DevNeto { get; set; }
        public decimal? CuentaCob { get; set; }
        public string FormaCobro { get; set; }

        //public Tirillas() { }

        public List<Tirillas> Salario(int mes, int anno, string ccosto)
        {
            LogErrores logError = new LogErrores();
            SicencoEntities db = new SicencoEntities();
            List<Tirillas> resp = new List<Tirillas>();
            //try
            //{          
                
            var historico = db.Report_ResumenSalarioS5PWebHistSiscont(mes, anno, ccosto).ToList();
            var ultimo = db.Report_ResumenSalarioS5PWebActualSiscont(mes, anno, ccosto).ToList();

            foreach (var item in ultimo)
            {
                Tirillas temp = new Tirillas()
                {
                    RecibPago = item.TipoNomina,
                    Reporte = item.NoReporte,
                    Corte = 1,
                    Mes = item.mes,
                    Anno = anno,
                    CentroPago = item.CPagoCodigo + " " + item.CPagoDescripcion,
                    NumCobro = item.NoCobro,
                    NombreCompleto = item.NombApel,
                    VacDias = Decimal.Round(item.DiasAcumVac ?? 0, 3),
                    VacImporte = Decimal.Round(item.SalAcVac ?? 0, 2),
                    Horastrabajadas = Decimal.Round(item.TiempoTrab ?? 0, 2),
                    Tarifa = Decimal.Round(item.tarifa ?? 0, 5),
                    SalEsc = Decimal.Round(item.SalEscala ?? 0, 2),
                    Cpagos = Decimal.Round(item.SalCPagos ?? 0, 2),
                    Padic = Decimal.Round(item.SalPagoAd ?? 0, 2),
                    DevBruto = Decimal.Round(item.SalBruto ?? 0, 2),
                    PorcCont = Decimal.Round(item.HistResuContAplicado ?? 0, 2),
                    Cess = Decimal.Round(item.Sal5Porc ?? 0, 2),
                    Retenc = Decimal.Round(item.SalRetenciones ?? 0, 2),
                    DescPdiv = Decimal.Round(item.SalDivisa ?? 0, 2),
                    Ajuste = Decimal.Round(item.SalAjusteMonet ?? 0, 2),
                    DevNeto = Decimal.Round(item.SalNeto ?? 0, 2),
                    PorcImp = Decimal.Round(item.HistResuImpAplicado ?? 0, 2),
                    CuentaCob = Decimal.Round(item.HistResuCtaCobrar ?? 0, 2),
                    Impuesto = Decimal.Round(item.HistResuImp ?? 0, 2),
                    FormaCobro = item.TrabFormaCobro

                };
                resp.Add(temp);
            }
            foreach (var item in historico)
            {
                Tirillas temp = new Tirillas()
                {
                    RecibPago = item.TipoNomina,
                    Reporte = item.NoReporte,
                    Corte = 1,
                    Mes = item.mes,
                    Anno = anno,
                    CentroPago = item.CPagoCodigo + " " + item.CPagoDescripcion,
                    NumCobro = item.NoCobro,
                    NombreCompleto = item.NombApel,
                    VacDias = Decimal.Round(item.DiasAcumVac ?? 0, 3),
                    VacImporte = Decimal.Round(item.SalAcVac ?? 0, 2),
                    Horastrabajadas = Decimal.Round(item.TiempoTrab ?? 0, 2),
                    Tarifa = Decimal.Round(item.tarifa ?? 0, 5),
                    SalEsc = Decimal.Round(item.SalEscala ?? 0, 2),
                    Cpagos = Decimal.Round(item.SalCPagos ?? 0, 2),
                    Padic = Decimal.Round(item.SalPagoAd ?? 0, 2),
                    DevBruto = Decimal.Round(item.SalBruto ?? 0, 2),
                    PorcCont = Decimal.Round(item.HistResuContAplicado ?? 0, 2),
                    Cess = Decimal.Round(item.Sal5Porc ?? 0, 2),
                    Retenc = Decimal.Round(item.SalRetenciones ?? 0, 2),
                    DescPdiv = Decimal.Round(item.SalDivisa ?? 0, 2),
                    Ajuste = Decimal.Round(item.SalAjusteMonet ?? 0, 2),
                    DevNeto = Decimal.Round(item.SalNeto ?? 0, 2),
                    PorcImp = Decimal.Round(item.HistResuImpAplicado ?? 0, 2),
                    CuentaCob = Decimal.Round(item.HistResuCtaCobrar ?? 0, 2),
                    Impuesto = Decimal.Round(item.HistResuImp ?? 0, 2),
                    FormaCobro = item.TrabFormaCobro
                };
                resp.Add(temp);
            }
            resp = resp.OrderByDescending(x => x.NombreCompleto).ToList();
            //}
            //catch (Exception error)
            //{
            //    logError.Insertar("Tirillas Salario", error.ToString());
            //}
            return resp;

        }

    }
}