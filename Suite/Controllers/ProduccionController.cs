using Suite.Models;
using Suite.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suite.Controllers
{
    public class ProduccionController : Controller
    {
        private LogErrores logError = new LogErrores();
        // GET: Produccion de Petróleo
        public ActionResult ProdPetroleo()
        {
            ProdPetroleo produccion = new ProdPetroleo();
            ViewBag.fechadefiltro = DateTime.Now.AddDays(-1).ToShortDateString();
            return View(produccion.Listar(DateTime.Now.AddDays(-1).Date));
        }
        // Post: Produccion de Petróleo
        [HttpPost]
        public ActionResult ProdPetroleo(ProdPetroleo model)
        {
            try
            {
                DateTime salida = DateTime.Now.AddDays(-1);
                if (model.Fecha == null || model.Fecha.Value.Date >= DateTime.Now.Date)
                {
                    ViewBag.fechadefiltro = salida.ToShortDateString();
                    return View(model.Listar(salida.Date));
                }

                DateTime.TryParse(model.Fecha.ToString(), out salida);
                ViewBag.fechadefiltro = salida.ToShortDateString();
                return View(model.Listar(salida.Date));
            }
            catch (Exception error)
            {
                logError.Insertar("ProduccionController ProdPetroleo", error.ToString());
            }

            return RedirectToAction("ProdPetroleo");
        }
        // GET: Produccion de Gas
        public ActionResult ProdGas()
        {
            Prodgas prodgas = new Prodgas();
            ViewBag.fechadefiltro = DateTime.Now.AddDays(-1).ToShortDateString();
            return View(prodgas.Listar(DateTime.Now.AddDays(-1).Date));
        }
        // Post: Produccion de Gas
        [HttpPost]
        public ActionResult ProdGas(Prodgas model)
        {
            try
            {
                DateTime salida = DateTime.Now.AddDays(-1);
                if (model.Fecha == null || model.Fecha.Value.Date >= DateTime.Now.Date)
                {
                    ViewBag.fechadefiltro = salida.ToShortDateString();
                    return View(model.Listar(salida.Date));
                }

                DateTime.TryParse(model.Fecha.ToString(), out salida);
                ViewBag.fechadefiltro = salida.ToShortDateString();
                return View(model.Listar(salida.Date));
            }
            catch (Exception error)
            {
                logError.Insertar("ProduccionController ProdGas", error.ToString());
            }

            return RedirectToAction("ProdGas");
        }
        // GET: Produccion de Petróleo Equivalente
        public ActionResult ProdPetroEquiv()
        {
            ProdPetroEquiv petroEquiv = new ProdPetroEquiv();
            ViewBag.fechadefiltro = DateTime.Now.AddDays(-1).ToShortDateString();
            return View(petroEquiv.Listar(DateTime.Now.AddDays(-1).Date));
        }
        // Post: Produccion de Petróleo Equivalente
        [HttpPost]
        public ActionResult ProdPetroEquiv(ProdPetroEquiv model)
        {
            try
            {
                DateTime salida = DateTime.Now.AddDays(-1);
                if (model.Fecha == null || model.Fecha.Value.Date >= DateTime.Now.Date)
                {
                    ViewBag.fechadefiltro = salida.ToShortDateString();
                    return View(model.Listar(salida.Date));
                }

                DateTime.TryParse(model.Fecha.ToString(), out salida);
                ViewBag.fechadefiltro = salida.ToShortDateString();
                return View(model.Listar(salida.Date));
            }
            catch (Exception error)
            {
                logError.Insertar("ProduccionController ProdPetroEquiv", error.ToString());
            }

            return RedirectToAction("ProdPetroEquiv");
        }
        // GET: Produccion de VentaPetroleo
        public ActionResult ProdVentaPet()
        {
            ProdVentaPet ventaPet = new ProdVentaPet();
            ViewBag.fechadefiltro = DateTime.Now.AddDays(-1).ToShortDateString();
            return View(ventaPet.Listar(DateTime.Now.AddDays(-1).Date));
        }
        // Post: Produccion de VentaPetroleo
        [HttpPost]
        public ActionResult ProdVentaPet(ProdVentaPet model)
        {
            try
            {
                DateTime salida = DateTime.Now.AddDays(-1);
            if (model.Fecha == null || model.Fecha.Value.Date >= DateTime.Now.Date)
            {
                ViewBag.fechadefiltro = salida.ToShortDateString();
                return View(model.Listar(salida.Date));
            }

            DateTime.TryParse(model.Fecha.ToString(), out salida);
            ViewBag.fechadefiltro = salida.ToShortDateString();
            return View(model.Listar(salida.Date));
            }
            catch (Exception error)
            {
                logError.Insertar("ProduccionController ProdVentaPet", error.ToString());
            }

            return RedirectToAction("ProdVentaPet");
        }
    }
}