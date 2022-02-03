using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloAlmacenes;

namespace Suite.Models.Almacenes
{
    public class PadreAlmacenes
    {
        public ModuloAlmacenes.Almacenes Almacen(string nombre)
        {
            AlmacenesEntities entities = new AlmacenesEntities();
            return (from c in entities.Almacenes where c.Almacen_Descrip.Replace(" ", "") == nombre select c).FirstOrDefault();
        }
        public IEnumerable<SelectListItem> ListaAlmacenes()
        {
            AlmacenesEntities entities = new AlmacenesEntities();
            List<SelectListItem> ddl = new List<SelectListItem>();
            var almacenes = (from c in entities.Almacenes select c).ToList();
            for (int i = 0; i < almacenes.Count; i++)
            {
                ddl.Add(new SelectListItem { Text = almacenes[i].Almacen_Descrip, Value = almacenes[i].Almacen_Id });
            }

            return ddl;
        }
    }
}