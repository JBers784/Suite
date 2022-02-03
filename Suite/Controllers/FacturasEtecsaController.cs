using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Suite.Models.Comunes;
using ModuloComunicaciones;
using ModuloEconomia;
using Suite.Models;

namespace Suite.Controllers
{
    public class FacturasEtecsaController : Controller
    {
        private LogErrores logError = new LogErrores();
        FacSeComEntities entities = new FacSeComEntities();

        public ActionResult Search(string term)
        {
            try
            {
                SicencoEntities sicenco = new SicencoEntities();
                using (sicenco)
                {
                    return Json(sicenco.CCostos.Where(p => (p.Cuenta_Id + p.CCosto_Id + p.CCosto_Descrip).ToLower().Contains(term.ToLower()) && p.CCosto_Activado == true).Select(p => p.Cuenta_Id + p.CCosto_Id + " " + p.CCosto_Descrip).ToList(), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception error)
            {
                logError.Insertar("FacturasEtecsaController Search", error.ToString());
            }
            return View();
        }
        //=======================TRUNKING============================
        // GET: FacturasTrunking
        public ActionResult FacturaTrunking()
        {
            List<Web_FacturaTrunking_Result> view = new List<Web_FacturaTrunking_Result>();

            ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            ViewBag.ccostos = "";
            return View(view);
        }

        // POST: FacturasTrunking
        [HttpPost]
        public ActionResult FacturaTrunking(string mes, string anno, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
                {
                    return RedirectToAction("FacturaTrunking");
                }

                ViewBag.mes = new SelectList(Fecha.Meses(), "Value", "Text", mes);
                ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
                ViewBag.ccostos = ccostos;
                ccostos = ccostos.Substring(0, 3) + "-" + ccostos.Substring(3, 5);
                List<Web_FacturaTrunking_Result> view = entities.Web_FacturaTrunking(int.Parse(mes), int.Parse(anno), ccostos).ToList();
                if (view.Count > 0)
                {
                    ViewBag.tabla = true;
                }
                return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("FacturasEtecsaController FacturaTrunking", error.ToString());
            }

            return RedirectToAction("FacturaTrunking");
        }
        //=======================TELEFONOS FIJOS============================

        // GET: Facturas Telefonos Fijos
        public ActionResult FacturaTelefonoFijo()
        {
            List<Web_FacturaTelFijo_Result> view = new List<Web_FacturaTelFijo_Result>();

            ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            ViewBag.ccostos = "";
            return View(view);
        }
        // POST: Telefonos Fijos
        [HttpPost]
        public ActionResult FacturaTelefonoFijo(string mes, string anno, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
                {
                    return RedirectToAction("FacturaTelefonoFijo");
                }

                ViewBag.mes = new SelectList(Fecha.Meses(), "Value", "Text", mes);
                ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
                ViewBag.ccostos = ccostos;
                //string numero = ccostos.Replace(" ", "").Substring(2, 6);
                Servicios telf = entities.Servicios.Where(x => (x.IdTipo == 1 && x.Numero.Replace(" ", "") == ccostos)).FirstOrDefault();
                if (telf != null)
                {
                    var facttelf = entities.Web_FacturaTelFijoNo(int.Parse(mes), int.Parse(anno), ccostos).ToList();
                    List<Web_FacturaTelFijo_Result> viewtelf = new List<Web_FacturaTelFijo_Result>();
                    Web_FacturaTelFijo_Result resp = new Web_FacturaTelFijo_Result();
                    foreach (var item in facttelf)
                    {
                        resp = new Web_FacturaTelFijo_Result()
                        {
                            mfac = item.mfac,
                            noft = item.noft,
                            cent = item.cent,
                            telf = item.telf,
                            docn = item.docn,
                            dia = item.dia,
                            mes = item.mes,
                            dest = item.dest,
                            slla = item.slla,
                            hora = item.hora,
                            clav = item.clav,
                            mins = item.mins,
                            segs = item.segs,
                            puls = item.puls,
                            impt = item.impt,
                            cargo = item.cargo,
                            mon = item.mon,
                            Entrada = item.Entrada,
                            ubicacion = item.ubicacion
                        };
                        viewtelf.Add(resp);
                    }



                    if (viewtelf.Count > 0)
                    {
                        ViewBag.tabla = true;
                    }
                    return View(viewtelf);
                }
                ccostos = ccostos.Substring(0, 3) + "-" + ccostos.Substring(3, 5);

                List<Web_FacturaTelFijo_Result> view = entities.Web_FacturaTelFijo(int.Parse(mes), int.Parse(anno), ccostos).ToList();
                if (view.Count > 0)
                {
                    ViewBag.tabla = true;
                }
                return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("FacturasEtecsaController FacturaTelefonoFijo", error.ToString());
            }

            return RedirectToAction("FacturaTelefonoFijo");
        }

        //=======================TELEFONOS CELULARES============================

        // GET: Facturas Telefonos Celulares
        public ActionResult FacturaTelefonoCelular()
        {
            List<Web_FactCelulares_Result> view = new List<Web_FactCelulares_Result>();
            ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            ViewBag.ccostos = "";
            return View(view);
        }
        // POST: Telefonos Celulares
        [HttpPost]
        public ActionResult FacturaTelefonoCelular(string mes, string anno, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
                {
                    return RedirectToAction("FacturaTelefonoCelular");
                }

                ViewBag.mes = new SelectList(Fecha.Meses(), "Value", "Text", mes);
                ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
                ViewBag.ccostos = ccostos;
                Servicios cell = entities.Servicios.Where(x => (x.IdTipo == 4 && x.Numero == ccostos)).FirstOrDefault();
                if (cell != null)
                {
                    var factcelular = entities.Web_FactCelularesNo(int.Parse(mes), int.Parse(anno), ccostos).FirstOrDefault();
                    List<Web_FactCelulares_Result> viewcell = new List<Web_FactCelulares_Result>();
                    Web_FactCelulares_Result resp = new Web_FactCelulares_Result()
                    {
                        Numero = factcelular.Numero,
                        //Ubicacion,
                        Custodio = factcelular.Custodio,
                        //CCosto,
                        //DescCCosto,
                        //Subdir,
                        //DescSubdir,
                        NumFact = factcelular.NumFact,
                        NumCelular = factcelular.NumCelular,
                        Llamadas_Recib = factcelular.Llamadas_Recib,
                        Llamadas_Orig = factcelular.Llamadas_Orig,
                        //Llamadas_Pico,
                        //Llamadas_NoPico,
                        Costos_Recib = factcelular.Costos_Recib,
                        Costos_Orig = factcelular.Costos_Orig,
                        //Costos_Pico,
                        //Costos_NoPico,
                        Durac_Recib = factcelular.Durac_Recib,
                        Durac_Orig = factcelular.Durac_Orig,
                        //Durac_Pico,
                        //Durac_NoPico,
                        Llamadas_Internac = factcelular.Llamadas_Internac,
                        Llamadas_Nac = factcelular.Llamadas_Nac,
                        Costos_Internac = factcelular.Costos_Internac,
                        Costos_Nac = factcelular.Costos_Nac,
                        Durac_Internac = factcelular.Durac_Internac,
                        Durac_Nac = factcelular.Durac_Nac,
                        SMS_Recib = factcelular.SMS_Recib,
                        SMS_Orig = factcelular.SMS_Orig,
                        //SMS_Pico,
                        //SMS_NoPico,
                        CostosSMS_Recib = factcelular.CostosSMS_Recib,
                        CostosSMS_Orig = factcelular.CostosSMS_Orig,
                        //CostosSMS_Pico,
                        //CostosSMS_NoPico,
                        SMS_LargaD = factcelular.SMS_LargaD,
                        SMS_LargaD_Costos = factcelular.SMS_LargaD_Costos,
                        MMS_Recib = factcelular.MMS_Recib,
                        MMS_Orig = factcelular.MMS_Orig,
                        //MMS_Pico,
                        //MMS_NoPico,
                        CostosMMS_Recib = factcelular.CostosMMS_Recib,
                        CostosMMS_Orig = factcelular.CostosMMS_Orig,
                        //CostosMMS_Pico,
                        //CostosMMS_NoPico,
                        //CostosGPRS_Pico,
                        //CostosGPRS_NoPico,
                        DiasUso = factcelular.DiasUso,
                        Total = factcelular.Total,
                        Entrada = factcelular.Entrada,
                        Fecha = factcelular.Fecha,
                        PlanMin = factcelular.PlanMin
                    };
                    viewcell.Add(resp);


                    if (viewcell.Count > 0)
                    {
                        ViewBag.tabla = true;
                    }
                    return View(viewcell);

                }
                ccostos = ccostos.Substring(0, 3) + "-" + ccostos.Substring(3, 5);

                List<Web_FactCelulares_Result> view = entities.Web_FactCelulares(int.Parse(mes), int.Parse(anno), ccostos).ToList();
                if (view.Count > 0)
                {
                    ViewBag.tabla = true;
                }
                return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("FacturasEtecsaController FacturaTelefonoCelular", error.ToString());
            }

            return RedirectToAction("FacturaTelefonoCelular");
        }


    }
}
