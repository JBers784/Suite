using ModuloRecHumanos;
using ModuloEconomia;
using Suite.Models.RecHumanos;
using Suite.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Suite.Models;

namespace Suite.Controllers
{
    public class RecHumanosController : Controller
    {
        private LogErrores logError = new LogErrores();
        private CapitalHumanoEntities db = new CapitalHumanoEntities();
        private SicencoEntities entitiesSicenco = new SicencoEntities();
        public ActionResult SearchNombre(string term)
        {
            using (db)
            {

                return Json(db.Datos_Personales.Where(p => p.dp_NombreApellidos.ToLower().Contains(term.ToLower())).Select(p => p.dp_NombreApellidos).Take(20).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult SearchCargo(string term)
        //{
        //    using (db)
        //    {
        //        return Json(db.Cargo.Where(p => p.DescripCargo.ToLower().Contains(term.ToLower())).Select(p => p.DescripCargo).Take(15).ToList(), JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult SearchArea(string term)
        {
            try
            {


                using (db)
                {
                    return Json(db.Area.Where(p => p.DescripArea.ToLower().Contains(term.ToLower()) && !(p.Excluida)).Select(p => p.DescripArea).Take(15).ToList(), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController SearchArea", error.ToString());
                return View();
            }
        }


        // GET: RecHumanos
        //=====================================Datos Personales de un trabajador==============
        public ActionResult DatosPersonales()
        {
            DatosPersonales Trabaj = new DatosPersonales();
            List<DatosPersonales> listaDatosPersonales = new List<DatosPersonales>();
            return View(listaDatosPersonales);
        }

        [HttpPost]
        public ActionResult DatosPersonales(DatosPersonales model, FormCollection form)
        {
            try
            {
                string carId = (from c in db.Datos_Personales where (c.dp_NombreApellidos == model.NombAp) select c.CIdentidad).FirstOrDefault();
                List<DatosPersonales> listaDatosPersonales = model.Listar(carId);
                ViewBag.tabla = true;
                if (!(listaDatosPersonales.Count > 0))
                {
                    ViewBag.tabla = null;
                }
                return View(listaDatosPersonales);
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController DatosPersonales", error.ToString());
            }

            return RedirectToAction("DatosPersonales");
        }

        // GET: PreparacionRecibida
        //=====================================Datos de la preparación recibida para un Cargo==============
        public ActionResult PrepRecibida()
        {
            PrepRecibida Cursos = new PrepRecibida();
            List<PrepRecibida> listaCursos = new List<PrepRecibida>();
            return View(listaCursos);
        }

        [HttpPost]
        public ActionResult PrepRecibida(PrepRecibida model, FormCollection form)
        {
            try
            {
                string carId = (from c in db.Datos_Personales where (c.dp_NombreApellidos == model.Nombre) select c.CIdentidad).FirstOrDefault();
                List<PrepRecibida> listaCursos = model.ListaC(carId);
                ViewBag.tabla = true;
                if (!(listaCursos.Count > 0))
                {
                    ViewBag.tabla = null;
                }
                return View(listaCursos);
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController PrepRecibida", error.ToString());
                return RedirectToAction("PrepRecibida");
            }


        }

        // GET: P4Area
        //=====================================Datos del P4 de un Área==============
        public ActionResult P4Area()
        {
            P4Area PlantillaP4 = new P4Area();
            List<P4Area> listaPlantilla = new List<P4Area>();
            return View(listaPlantilla);
        }

        [HttpPost]
        public ActionResult P4Area(P4Area model, FormCollection form)
        {
            try
            {
                string areaId = (from c in db.Area where (c.DescripArea.ToLower().Contains(model.DescArea.ToLower())) && !(c.Excluida) select c.Cod_Area).FirstOrDefault();

                List<P4Area> listaPlantilla = model.Listar(areaId);
                ViewBag.tabla = true;
                if (!(listaPlantilla.Count > 0))
                {
                    ViewBag.tabla = null;
                }
                return View(listaPlantilla);
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController P4Area", error.ToString());
                return RedirectToAction("P4Area");
            }
        }

        // GET: Tarjeta de Salario
        //=====================================Datos Tarjeta de Salario==============
        public ActionResult TarjSalario()
        {
            List<TarjetaSalarioWeb_Result> view = new List<TarjetaSalarioWeb_Result>();
            ViewBag.ci = "";
            return View(view);
        }
        // POST: Tarjeta de Salario
        [HttpPost]
        public ActionResult TarjSalario(TarjetaSalarioWeb_Result model, FormCollection form)
        {
            try
            {
                string carnetIdent = (from c in db.Datos_Personales where (c.dp_NombreApellidos.ToLower().Contains(model.Nombre.ToLower())) select c.CIdentidad).FirstOrDefault();
                var view = entitiesSicenco.TarjetaSalarioWeb(carnetIdent).ToList();
                if (view.Count > 0)
                {
                    ViewBag.tabla = true;
                }
                return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController TarjSalario", error.ToString());
                return RedirectToAction("TarjSalario");
            }
        }

        // GET: Jubilación
        //=====================================Datos Jubilación==============
        public ActionResult Jubilacion()
        {
            List<JubilacionWeb_Result> view = new List<JubilacionWeb_Result>();
            ViewBag.ci = "";
            return View(view);
        }
        // POST: Jubilación
        [HttpPost]
        public ActionResult Jubilacion(JubilacionWeb_Result model, FormCollection form)
        {
            try
            {
                string carnetIdent = (from c in db.Datos_Personales where (c.dp_NombreApellidos.ToLower().Contains(model.Nombre.ToLower())) select c.CIdentidad).FirstOrDefault();
                var view = entitiesSicenco.JubilacionWeb(carnetIdent).ToList();
                if (view.Count > 0)
                {
                    ViewBag.tabla = true;
                }
                return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController Jubilacion", error.ToString());
                return RedirectToAction("Jubilacion");
            }
        }

        // GET: Cumpleaños
        //=====================================Cumpleaños========================================================
        public ActionResult Cumpleaños()
        {
            List<Cumpleaños> comlist = new List<Cumpleaños>();
            return View(comlist);

        }
        // Post: Cumpleaños
        [HttpPost]
        public ActionResult Cumpleaños(Cumpleaños model)
        {
            try
            {
                if (model.fechaini == null)
                {
                    model.fechaini = DateTime.Parse("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                }
                if (model.fechafin == null)
                {
                    model.fechafin = DateTime.Now;
                }
                ViewBag.tabla = true;
                Cumpleaños com = new Cumpleaños();
                List<Cumpleaños> comlist = com.CumpleañosxFecha(model.fechaini, model.fechafin);

                return View(comlist);
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController Cumpleaños", error.ToString());
                return RedirectToAction("Cumpleaños");
            }

        }

        // GET: Submayor de Vacaciones
        //=====================================Submayor de Vacaciones=================================================
        public ActionResult SubMayorVacaciones()
        {
            List<SubMayorVacaciones> view = new List<SubMayorVacaciones>();

            //ViewBag.mes = Fecha.Meses();
            //ViewBag.anno = Fecha.Annos(8);
            ViewBag.ccostos = "";
            return View(view);
        }
        // Post: Economia
        [HttpPost]
        public ActionResult SubMayorVacaciones(string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
                {
                    return RedirectToAction("SubMayorVacaciones");
                }
                //ViewBag.mes = new SelectList(Fecha.Meses(), "Value", "Text", mes);
                //ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
                ViewBag.ccostos = ccostos;
                string ccostos2 = ccostos.Substring(0, 6);
                ViewBag.tabla = true;
                SubMayorVacaciones vacaciones = new SubMayorVacaciones();
                List<SubMayorVacaciones> view = vacaciones.ReporteVacaciones(ccostos2);
                return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("RecHumanosController SubMayorVacaciones", error.ToString());
                return RedirectToAction("SubMayorVacaciones");
            }

        }
    }
}