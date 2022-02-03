using Suite.Models;
using Suite.Models.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Suite.Controllers
{
    public class TransporteController : Controller
    {
        private LogErrores logError = new LogErrores();
        private ModuloTransporte.SitransEntities db = new ModuloTransporte.SitransEntities();
        public ActionResult Searchmatricula(string term)
        {
            try
            {
                using (db)
            {
                return Json(db.Equipos.Where(p => p.eq_matricula.ToLower().Contains(term.ToLower()) && p.eq_Baja == false && p.eq_Propiedad == "EP").Select(p => p.eq_matricula).ToList(), JsonRequestBehavior.AllowGet);
            }
            }
            catch (Exception error)
            {
                logError.Insertar("TransporteController Searchmatricula", error.ToString());
                return View();
            }
        }
        public ActionResult SearchCC(string term)
        {
            try
            {
                using (db)
                {
                    return Json(db.CentrosCostos.Where(p => (p.ccosto_codcencos + p.ccosto_descrip).ToLower().Contains(term.ToLower()) && p.ccosto_Inactivo == false).Select(p => p.ccosto_codcencos + " " + p.ccosto_descrip).ToList(), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception error)
            {
                logError.Insertar("TransporteController Searchmatricula", error.ToString());
                return View();
            }
        }

        //===================================================Combustibles==============================================================
        // GET: Combustible
        [HttpGet]
        public ActionResult Combustible()
        {
            List<Combustible> comlist = new List<Combustible>();           
            return View(comlist);
        }
        // POST: Combustible
        [HttpPost]
        public ActionResult Combustible( Combustible model)
        {
            try
            {
                if (model.fechadocini == null )
            {
                model.fechadocini = DateTime.Parse("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            }
            if (model.fechadocfin == null)
            {
                model.fechadocfin = DateTime.Now;
            }
            if (model.matricula == null)
            {
                return View(new List<Combustible>());
            }
            ViewBag.tabla = true;
            Combustible com = new Combustible();
            string matriculaoccosto;
            if (model.matricula.Count() > 9)
            {
                matriculaoccosto = model.matricula.Substring(0, 9);
            }
            else
            {
                matriculaoccosto = model.matricula.Replace(" ", "");
            }
            List<Combustible> comlist = com.CombustiblexTargeta(com.MatricOccosto(matriculaoccosto), matriculaoccosto, model.fechadocini, model.fechadocfin);
            //string tarjeta = "";
            //foreach (var item in comlist)
            //{
            //    if (item.notargeta != tarjeta)
            //    {
            //        tarjeta = item.notargeta;
            //    }
            //}
           
            //ViewBag.tarjetas = true;
            return View(comlist);
            }
            catch (Exception error)
            {
                logError.Insertar("TransporteController Combustible", error.ToString());
                return RedirectToAction("Combustible");
            }

        }
        //===================================================Hoja de Ruta==============================================================
        // GET: Hoja de Ruta
        [HttpGet]
        public ActionResult HojaRuta()
        {
            List<HojaRuta> hrlist = new List<HojaRuta>();
            return View(hrlist);
        }
        // POST: Hoja de Ruta
        [HttpPost]
        public ActionResult HojaRuta(HojaRuta model)
        {
            try
            {
                if (model.fechaini == null )
            {
                model.fechaini = DateTime.Parse("01/" + (DateTime.Now.Month - 1) + "/" + DateTime.Now.Year);
            }
            if (model.fechafin == null )
            {
                model.fechafin = DateTime.Now;
            }
            if (model.matricula == null)
            {
                return View(new List<HojaRuta>());
            }
            HojaRuta hr = new HojaRuta();
            ViewBag.kmsdisponibles = hr.Fx_KmDisponibles(model.matricula);
            ViewBag.TipoMant = hr.TipoMantenimiento(model.matricula);
            
            List<HojaRuta> hrlist = hr.Listado(model.matricula, model.fechaini, model.fechafin);
            return View(hrlist);
            }
            catch (Exception error)
            {
                logError.Insertar("TransporteController HojaRuta", error.ToString());
                return RedirectToAction("HojaRuta");
            }
        }
        //===================================================Orden de Trabajo===========================================================
        // GET: Orden de Trabajo
        [HttpGet]
        public ActionResult OrdenTrabajo()
        {
            List<OrdenesTrabajo> ot = new List<OrdenesTrabajo>();
            return View(ot);
        }
        // POST: Orden de Trabajo
        [HttpPost]
        public ActionResult OrdenTrabajo(OrdenesTrabajo model)
        {
            try
            {
                if (model.Fechaini == null)
            {
                model.Fechaini = DateTime.Parse("01/" + (DateTime.Now.Month - 1) + "/" + DateTime.Now.Year);
            }
            if (model.Fechafin == null)
            {
                model.Fechafin = DateTime.Now;
            }
            if (model.Matricula == null)
            {
                return View(new List<OrdenesTrabajo>());
            }
            OrdenesTrabajo ot = new OrdenesTrabajo();            
            ViewBag.tabla = true;
            List<OrdenesTrabajo> ots = ot.listar(model.Fechaini, model.Fechafin, model.Matricula);
            return View(ots);
            }
            catch (Exception error)
            {
                logError.Insertar("TransporteController OrdenTrabajo", error.ToString());
                return RedirectToAction("OrdenTrabajo");
            }
        }
        //===================================================Documentos================================================================
        // GET: Documentos
        [HttpGet]
        public ActionResult Documentos()
        {
            List<Documentos > doclist = new List<Documentos >();
            return View(doclist);
        }

        // POST: Documentos
        [HttpPost]
        public ActionResult Documentos( Documentos  model)
        {
            try
            {
                if (model.equipo  == null)
            {
                return View(new List<Documentos >());
            }            
            Documentos  doc = new Documentos();
            List<Documentos> doclist = doc.DocumentosxEquipo(model.equipo );
            if (!(doclist.Count > 0))
            {
                return View(new List<Documentos>());
            }
            ViewBag.tabla = true;
            return View(doclist);
            }
            catch (Exception error)
            {
                logError.Insertar("TransporteController Documentos", error.ToString());
                return RedirectToAction("Documentos");
            }

        }

        //===================================================Neumaticos y Baterias================================================================
        [HttpGet]
        public ActionResult NeumaticosBat()
        {            
            return View(new List<NeumaticosBaterias>());
        }

        // POST: Documentos
        [HttpPost]
        public ActionResult NeumaticosBat(string matricula)
        {
            try
            {
                if (string.IsNullOrEmpty(matricula))
            {
                return View(new List<NeumaticosBaterias>());
            }
            NeumaticosBaterias neumaticosBaterias = new NeumaticosBaterias();
            List<NeumaticosBaterias> listNeumaticosBaterias = neumaticosBaterias.ListaNeumaticosBaterias(matricula);
            if (!(listNeumaticosBaterias.Count > 0))
            {
                return View(new List<NeumaticosBaterias>());
            }
            ViewBag.tabla = true;
            return View(listNeumaticosBaterias);
            }
            catch (Exception error)
            {
                logError.Insertar("TransporteController NeumaticosBat", error.ToString());
                return RedirectToAction("NeumaticosBat");
            }

        }
    }
}
