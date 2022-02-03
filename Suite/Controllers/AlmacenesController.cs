using ModuloAlmacenes;
using ModuloEconomia;
using Suite.Models;
using Suite.Models.Almacenes;
using Suite.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Suite.Controllers
{
    public class AlmacenesController : Controller
    {
       private AlmacenesEntities db = new AlmacenesEntities();
       private LogErrores logError = new LogErrores();
        public ActionResult SearchDescProd(string term)
        {
            try
            {           
            using (db)
            {
                return Json(db.Mundo_Productos.Where(p => p.mProducto_Descrip.ToLower().Contains(term.ToLower())).Select(p => p.mProducto_Descrip).Take(15).ToList(), JsonRequestBehavior.AllowGet);
            }
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController SearchDescProd", error.ToString());
            }
            return View();
        }
        public ActionResult SearchCC(string term)
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
                logError.Insertar("AlmacenesController SearchCC", error.ToString());
            }
            return View();
        }
        //=====================================Existencia de Productos====================================================
        // GET: Productos
        public ActionResult Productos()
        {
          
                Productos prod = new Productos();
            List<Productos> listaProductos = new List<Productos>();
            ViewBag.listaalmacenes = prod.ListaAlmacenes();            
            return View(listaProductos);
          
        }
        [HttpPost]
        public ActionResult Productos(Productos model, FormCollection form)
        {
            try
            {
                var almacId = form.Get("Almacenes");
                Productos prod = new Productos();
                List<Productos> listaProductos = prod.Listar(model.Descripcion, almacId);
                var listaalmacenes = prod.ListaAlmacenes();
                ViewBag.listaalmacenes = new SelectList(listaalmacenes, "Value", "Text", almacId);
                ViewBag.tabla = true;
                if (!(listaProductos.Count > 0))
                {
                    ViewBag.tabla = null;
                }
                return View(listaProductos);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController ProductosPost", error.ToString());
            }
            return RedirectToAction("Productos");
        }
        //=====================================Distribución de Productos por Centros de Costos============================
        // GET: ProductosxCc
       
        public ActionResult ProductosxCc()
        {
           
                string codigoProducto = Request["codigoProducto"];
            string almacen = Request["nomAlmacen"];

            ProductosxCc prod = new ProductosxCc();
            Productos produc = new Productos();

            if (!String.IsNullOrEmpty(codigoProducto) && !String.IsNullOrEmpty(almacen))
            {   
                return ProductosxCc(codigoProducto, prod.Almacen(almacen).Almacen_Id);
            }
            
            ViewBag.listaalmacenes = produc.ListaAlmacenes();
            ViewBag.almacen = "--Seleccione un almacén--";
            return View(prod);
           
        }
        [HttpPost]
        public ActionResult ProductosxCc(string codigo,  string almacId)
        {
            try
            { 
            ProductosxCc prod = new ProductosxCc();  
            Productos product = new Productos();
            
            var view = prod.Listar(codigo, almacId);

            if (view.Codigo == null)
            {

                return ProductosxCc();
                
            }            
            ViewBag.tabla = true;
            var listaalmacenes = product.ListaAlmacenes();
            ViewBag.listaalmacenes = new SelectList(listaalmacenes, "Value", "Text", almacId);            

            return View(view);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController ProductosxCcPost", error.ToString());
            }
            return RedirectToAction("ProductosxCc");
        }
        //=====================================Existencia de Medios Básicos ==============================================
        // GET: MediosBasicos
        public ActionResult MediosBasicos()
        {
          
                MediosBasicos prod = new MediosBasicos();
                List<MediosBasicos> listaProductos = prod.ListaMB();
                ViewBag.tabla = true;
                return View(listaProductos);
           
        }

        //=====================================Existencia de Útiles y Herramientas =======================================
        // GET: MediosBasicos
        public ActionResult UtilesHerramientas()
        {
           
            UtilesHerramientas prod = new UtilesHerramientas();
            List<UtilesHerramientas> listaProductos = prod.ListaUH ();
            ViewBag.tabla = true;
            return View(listaProductos);
           
        }

        //===================================== Productos Reservados por Centros de Costos============================
        // GET: ReservadosxCc

        public ActionResult ReservadosxCC()
        {
           
                ReservadosxCC prod = new ReservadosxCC();
            List<ReservadosxCC> listaProductos = new List<ReservadosxCC>();
            //ViewBag.listaalmacenes = prod.NombreAlmacen();
            return View(listaProductos);
           
        }
        [HttpPost]
        public ActionResult ReservadosxCC(ReservadosxCC model, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("ReservadosxCC");
            }            
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 8);
            ReservadosxCC prod = new ReservadosxCC();
            List<ReservadosxCC> listaProductos = prod.Listar(ccostos);
            ViewBag.tabla = true;
            if (!(listaProductos.Count > 0))
            {
                ViewBag.tabla = null;
            }
            return View(listaProductos);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController ReservadosxCCPost", error.ToString());
            }
            return RedirectToAction("ReservadosxCC");
        }
        //===================================== Salida de Útiles y herramientas por Centros de Costos============================
        // GET: UHxCc

        public ActionResult UHxCC()
        {
            
            UHxCC prod = new UHxCC();
            List<UHxCC> listaProductos = new List<UHxCC>();
            //ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            return View(listaProductos);
           
        }
        [HttpPost]
        public ActionResult UHxCC(UHxCC model,string anno, string mes, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("UHxCC");
            }
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 8);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            UHxCC prod = new UHxCC();
            List<UHxCC> listaProductos = prod.Listar(ccostos, 1, int.Parse(anno));
            ViewBag.tabla = true;
            if (!(listaProductos.Count > 0))
            {
                ViewBag.tabla = null;
            }
            return View(listaProductos);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController UHxCCPost", error.ToString());
            }
            return RedirectToAction("UHxCC");
        }

        //===================================== Salida de Medios Básicos por Centros de Costos============================
        // GET: MBasxCc

        public ActionResult MBasxCC()
        {
           
                MBasxCC prod = new MBasxCC();
            List<MBasxCC> listaProductos = new List<MBasxCC>();
            //ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            return View(listaProductos);
           
        }
        [HttpPost]
        public ActionResult MBasxCC(MBasxCC model, string anno, string mes, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("MBasxCC");
            }
             ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 8);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            MBasxCC prod = new MBasxCC();
            List<MBasxCC> listaProductos = prod.Listar(ccostos, 1, int.Parse(anno));
            ViewBag.tabla = true;
            if (!(listaProductos.Count > 0))
            {
                ViewBag.tabla = null;
            }
            return View(listaProductos);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController MBasxCCPost", error.ToString());
            }
            return RedirectToAction("MBasxCC");
        }
        //===================================== Salida de Medios Protección Individual por Centros de Costos============================
        // GET: MPIxCc

        public ActionResult MPIxCC()
        {
          
            MPIxCC prod = new MPIxCC();
            List<MPIxCC> listaProductos = new List<MPIxCC>();
            //ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            return View(listaProductos);
           
        }
        [HttpPost]
        public ActionResult MPIxCC(MBasxCC model, string anno, string mes, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("MPIxCC");
            }
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 8);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            MPIxCC prod = new MPIxCC();
            List<MPIxCC> listaProductos = prod.Listar(ccostos, 1, int.Parse(anno));
            ViewBag.tabla = true;
            if (!(listaProductos.Count > 0))
            {
                ViewBag.tabla = null;
            }
            return View(listaProductos);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController MPIxCCPost", error.ToString());
            }
            return RedirectToAction("MPIxCC");
        }
        //===================================== Salida de Equipos x Instalar por Centros de Costos============================
        // GET: ExIxCC

        public ActionResult ExIxCC()
        {
          
            ExIxCC prod = new ExIxCC();
            List<ExIxCC> listaProductos = new List<ExIxCC>();
            //ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            return View(listaProductos);
           
        }
        [HttpPost]
        public ActionResult ExIxCC(ExIxCC model, string anno, string mes, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("ExIxCC");
            }
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 8);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            ExIxCC prod = new ExIxCC();
            List<ExIxCC> listaProductos = prod.Listar(ccostos, 1, int.Parse(anno));
            ViewBag.tabla = true;
            if (!(listaProductos.Count > 0))
            {
                ViewBag.tabla = null;
            }
            return View(listaProductos);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController ExIxCCPost", error.ToString());
            }
            return RedirectToAction("ExIxCC");
        }
        //===================================== Salida de Medios de Rotación por Centros de Costos============================
        // GET: MRotacxCC

        public ActionResult MRotacxCC()
        {
           
                MRotacxCC prod = new MRotacxCC();
            List<MRotacxCC> listaProductos = new List<MRotacxCC>();
            //ViewBag.mes = Fecha.Meses();
            ViewBag.anno = Fecha.Annos(8);
            return View(listaProductos);
           
        }
        [HttpPost]
        public ActionResult MRotacxCC(MRotacxCC model, string anno, string mes, string ccostos)
        {
            try
            {
                if (!(ccostos.Count() >= 8))
            {
                return RedirectToAction("MRotacxCC");
            }
            ViewBag.ccostos = ccostos;
            ccostos = ccostos.Substring(0, 8);
            ViewBag.anno = new SelectList(Fecha.Annos(8), "Value", "Text", anno);
            MRotacxCC prod = new MRotacxCC();
            List<MRotacxCC> listaProductos = prod.Listar(ccostos, 1, int.Parse(anno));
            ViewBag.tabla = true;
            if (!(listaProductos.Count > 0))
            {
                ViewBag.tabla = null;
            }
            return View(listaProductos);
            }
            catch (Exception error)
            {
                logError.Insertar("AlmacenesController MRotacxCCPost", error.ToString());
            }
            return RedirectToAction("MRotacxCC");
        }
    }
}