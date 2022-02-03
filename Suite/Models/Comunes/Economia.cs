using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloEconomia;

namespace Suite.Models.Comunes
{
    public static class Economia
    {        
        public static IEnumerable<SelectListItem> Ccostos()
        {
            SicencoEntities entities = new SicencoEntities();
            List<SelectListItem> cc = new List<SelectListItem>();
            var ccostos = (from c in entities.CCostos where c.CCosto_Activado == true orderby c.Subd_Id, c.CCosto_Id select c).ToList();
            for (int i = 0; i < ccostos.Count; i++)
            {
                cc.Add(new SelectListItem { Text = ccostos[i].CCosto_Id+" "+ ccostos[i].CCosto_Descrip, Value = ccostos[i].CCosto_Id });
            }

            return cc;
        }
        public static IEnumerable<SelectListItem> CtaCcostos()
        {
            SicencoEntities entities = new SicencoEntities();
            List<SelectListItem> cc = new List<SelectListItem>();
            var ccostos = (from c in entities.CCostos where c.CCosto_Activado == true orderby c.Subd_Id, c.CCosto_Id select c).ToList();
            for (int i = 0; i < ccostos.Count; i++)
            {
                cc.Add(new SelectListItem { Text = ccostos[i].Cuenta_Id+ccostos[i].CCosto_Id + " " + ccostos[i].CCosto_Descrip, Value = ccostos[i].Cuenta_Id + ccostos[i].CCosto_Id });
            }

            return cc;
        }
    }
}