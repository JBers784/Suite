using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Suite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //  name: "Almacenes",
            //  url: "Almacenes/ProductosxCc/{codigoProducto}/{nomAlmacen}",
            //  defaults: new { controller = "Almacenes", action = "ProductosxCc", codigoProducto = UrlParameter.Optional, nomAlmacen = UrlParameter.Optional }
            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
