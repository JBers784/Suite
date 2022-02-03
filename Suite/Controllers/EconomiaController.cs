using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloEconomia;
using Suite.Models;
using Suite.Models.Comunes;
using Suite.Models.Economia;

namespace Suite.Controllers
{
    public class EconomiaController : Controller
    {
        SicencoEntities entities = new SicencoEntities();
        private LogErrores logError = new LogErrores();
        // GET: Economia
        public ActionResult PresGastoxCc()
        {
          
                List<Report_PGSisconTereWeb_Result> view = new List<Report_PGSisconTereWeb_Result>();
            
            ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            ViewBag.ccostos = "";
            return View(view);
            
        }
        // Post: Economia
        [HttpPost]
        public ActionResult PresGastoxCc(string mes, string anno, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
              return RedirectToAction("PresGastoxCc");
            }
            ViewBag.mes = new SelectList(Fecha.Meses(), "Value", "Text", mes);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            ViewBag.ccostos = ccostos;
            string ccostos2 = ccostos.Substring(3, 5);
            ViewBag.tabla = true;
            List<Report_PGSisconTereWeb_Result> view = entities.Report_PGSisconTereWeb(int.Parse(mes), ccostos2, int.Parse(anno)).ToList();
            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController PresGastoxCcPost", error.ToString());
            }
            return RedirectToAction("PresGastoxCc");

        }
//===============================================================================================================================
        // GET: Subelementos
        public ActionResult Subelementos()
        {
          
                List<WebPGSiscont1_Result> view = new List<WebPGSiscont1_Result>();

            ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            ViewBag.ccostos = "";
            return View(view);
           
        }
        // Post: Subelementos
        [HttpPost]
        public ActionResult Subelementos(string mes, string anno, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("Subelementos");
            }
            ViewBag.mes = new SelectList(Fecha.Meses(), "Value", "Text", mes);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 8);
            ViewBag.tabla = true;
            List<WebPGSiscont1_Result> view = entities.WebPGSiscont1(int.Parse(mes), ccostos, int.Parse(anno)).ToList();
            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController SubelementosPost", error.ToString());
            }
            return RedirectToAction("Subelementos");
        }

        //----------------------------------------Centros de costos-----------------------------------------------------
        //public ActionResult SearchCc(string term)
        //{
        //    term = term.ToLower();
        //   var ccostos = Economia.Ccostos();           
        //   return Json(ccostos.Where(p => p.Text.ToLower().Contains(term) ).Select(p => p.Text).ToList(), JsonRequestBehavior.AllowGet);

        //}
        //public ActionResult SearchCtacc(string term)
        //{
        //    term = term.ToLower();
        //    var ccostos = Economia.CtaCcostos();
        //    return Json(ccostos.Where(p => p.Text.ToLower().Contains(term)).Select(p => p.Text).ToList(), JsonRequestBehavior.AllowGet);

        //}
        public ActionResult SearchCC(string term)
        {
            try
            {
                S5PrincipalEntities siscont = new S5PrincipalEntities();
            using (siscont)
            {
                return Json(siscont.SCCOBJCOSTO.Where(p => (p.OCostCodigo + p.OCostDescrip).ToLower().Contains(term.ToLower())).Select(p => p.OCostCodigo + " " + p.OCostDescrip).ToList(), JsonRequestBehavior.AllowGet);
            }
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController SearchCC", error.ToString());
            }
            return View();
        }
        public ActionResult SearchCCUH(string term)
        {
            try
            {
                S5PrincipalEntities siscont = new S5PrincipalEntities();
                using (siscont)
                {
                    return Json(siscont.SCCOBJCOSTO.Where(p => (p.OCostDescrip).ToLower().Contains(term.ToLower()) ).Select(p => p.OCostCodigo).ToList(), JsonRequestBehavior.AllowGet);
            }
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController SearchCCUH", error.ToString());
            }
            return View();
        }
        //===============================================================================================================================
        // GET: Custodios de Útiles y Herramientas por Centro de Costos
        public ActionResult CustodiosUHxCC()
        {
          
            List<Report_UtilesHerramientasCCosto_Result > view = new List<Report_UtilesHerramientasCCosto_Result>();
            //ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            ViewBag.ccostos = "";
            return View(view);
           
        }
        // Post: Custodios de Útiles y Herramientas
        [HttpPost]
        public ActionResult CustodiosUHxCC(string anno, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("CustodiosUHxCC");
            }
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 6);
            ViewBag.tabla = true;
            List<Report_UtilesHerramientasCCosto_Result> view = entities.Report_UtilesHerramientasCCosto ( int.Parse(anno), ccostos).ToList();
            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController CustodiosUHxCCPost", error.ToString());
            }
            return RedirectToAction("CustodiosUHxCC");
        }

        //===============================================================================================================================
        // GET: Inventarios de Medios Básicos por  por Centro de Costos
        public ActionResult MedBasicosxCC()
        {
         
            List<Report_MedBasCCto_Result> view = new List<Report_MedBasCCto_Result>();
            ViewBag.ccostos = "";
            return View(view);
           
        }
        // Post: Custodios de Útiles y Herramientas
        [HttpPost]
        public ActionResult MedBasicosxCC( string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("MedBasicosxCC");
            }
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 6);
            ViewBag.tabla = true;
            List<Report_MedBasCCto_Result> view = entities.Report_MedBasCCto( ccostos, "T").ToList();
            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController MedBasicosxCCPost", error.ToString());
            }
            return RedirectToAction("MedBasicosxCC");
        }

        //===============================================================================================================================
        // GET: Inventarios de Útiles y Herramientas todos
        public ActionResult UtilesHerramientasFiltro()
        {
           
            List<InventariosUtilesHerrWeb_Result > view = new List<InventariosUtilesHerrWeb_Result>();
            ViewBag.ccostos = "";
            ViewBag.custodio = "";
            ViewBag.descutil = "";
            return View(view);           
           
        }
        // Post: Inventarios de Útiles y Herramientas todos
        [HttpPost]
        public ActionResult UtilesHerramientasFiltro(string ccostos,string custodio,string descutil)
        {
            try
            {
                ViewBag.ccostos = ccostos;
            ViewBag.custodio = custodio;
            ViewBag.descutil = descutil;
            ccostos = ccostos.Trim();
            custodio = custodio.Trim();
            descutil = descutil.Trim();
            ViewBag.tabla = true;
            List<InventariosUtilesHerrWeb_Result> view = entities.InventariosUtilesHerrWeb (ccostos,"","",custodio,descutil).ToList();
            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController UtilesHerramientasFiltroPost", error.ToString());
            }
            return RedirectToAction("UtilesHerramientasFiltro");
        }

        //===============================================================================================================================
        // GET: Inventarios de Medios Básicos todos
        public ActionResult MediosBasicosFiltro()
        {
            List<InventariosMedBasicosWeb_Result> view = new List<InventariosMedBasicosWeb_Result>();
            ViewBag.ccostos = "";
            ViewBag.codMBas = "";
            ViewBag.descMB = "";
            return View(view);
           
        }
        // Post: Inventarios de Medios Básicos todos
        [HttpPost]
        public ActionResult MediosBasicosFiltro(string ccostos, string codMBas, string descMB)
        {
            try
            {
                ViewBag.ccostos = ccostos;
            ViewBag.codMBas = codMBas;
            ViewBag.descMB = descMB;
            ccostos = ccostos.Trim();
            codMBas = codMBas.Trim();
            descMB = descMB.Trim();
            ViewBag.tabla = true;
            List<InventariosMedBasicosWeb_Result> view = entities.InventariosMedBasicosWeb(ccostos, descMB, codMBas).ToList();
            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController MediosBasicosFiltroPost", error.ToString());
            }
            return RedirectToAction("MediosBasicosFiltro");
        }

        // GET: Economia
        public ActionResult Tirillas()
        {
            Visitantes visitante = new Visitantes() { Desktop = 0, Mobile = 0 };
            if (Request.Browser["IsMobileDevice"] == "true")
            {
                visitante.Mobile = 1;
            }
            else
            {
                visitante.Desktop = 1;
            }

            Visitantes.Actualizar(visitante);

            List<Tirillas> view = new List<Tirillas>();
            ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);          
            ViewBag.ccostos = "";
            return View(view);
          
        }
        // Post: Economia
        [HttpPost]
        public ActionResult Tirillas(int mes, int anno, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("Tirillas");
            }
            ViewBag.mes = new SelectList(Fecha.Meses(), "Value", "Text", mes);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            ViewBag.ccostos = ccostos;
            string ccostos2 = ccostos.Substring(0, 6);
            ViewBag.tabla = true;
            Tirillas tirillas = new Tirillas();
            List<Tirillas> view = tirillas.Salario(mes, anno, ccostos2);
            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("EconomiaController TirillasPost", error.ToString());
            }
            return RedirectToAction("Tirillas");

        }
    }
}