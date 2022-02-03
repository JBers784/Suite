using Suite.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
           
            return View();
        }
        public ActionResult Modulos()
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
            return View();
        }
    }
        
}