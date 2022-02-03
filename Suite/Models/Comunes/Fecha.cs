using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suite.Models.Comunes
{
    public static class Fecha
    {
        public static IEnumerable<SelectListItem> Meses()
        {
            
            List<SelectListItem> meses = new List<SelectListItem>();
            meses.Add(new SelectListItem { Text = "Enero", Value = "01" });
            meses.Add(new SelectListItem { Text = "Febrero", Value = "02" });
            meses.Add(new SelectListItem { Text = "Marzo", Value = "03" });
            meses.Add(new SelectListItem { Text = "Abril", Value = "04" });
            meses.Add(new SelectListItem { Text = "Mayo", Value = "05" });
            meses.Add(new SelectListItem { Text = "Junio", Value = "06" });
            meses.Add(new SelectListItem { Text = "Julio", Value = "07" });
            meses.Add(new SelectListItem { Text = "Agosto", Value = "08" });
            meses.Add(new SelectListItem { Text = "Septiembre", Value = "09" });
            meses.Add(new SelectListItem { Text = "Octubre", Value = "10" });
            meses.Add(new SelectListItem { Text = "Noviembre", Value = "11" });
            meses.Add(new SelectListItem { Text = "Diciembre", Value = "12" });
            return meses;
        }

        public static IEnumerable<SelectListItem> Annos(int actualmenos)
        {
            List<SelectListItem> annos = new List<SelectListItem>();
            for (int i = 0; i <= actualmenos; i++)
            {
                annos.Add((new SelectListItem { Text = (DateTime.Now.Year - i).ToString(), Value = (DateTime.Now.Year-i).ToString() }));
            }
            return annos;
        }
    }
}