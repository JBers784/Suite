using ModuloAlmacenes;
using ModuloEconomia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.Almacenes
{
    public class Distribucion
    {
        public string Ccosto { get; set; }
        public decimal Asignados { get; set; }
        public decimal PredespachadoCc { get; set; }

        public Distribucion () { }
        public List<Distribucion> Listado(string codigoProducto, string almacId)
        {
            AlmacenesEntities entities = new AlmacenesEntities();
            SicencoEntities sicentities = new SicencoEntities();

            var temp = (from munprod in entities.Mundo_Productos
                        join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
                        join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
                        join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
                        join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
                        join distprod in entities.DistProd_CCosto on prodalmc.ProdAlm_Id equals distprod.ProdAlm_Id
                        //join ccosto in sicentities.CCostos on (distprod.CtaCCosto).Trim() equals (ccosto.Cuenta_Id).Trim() + (ccosto.CCosto_Id).Trim()
                        where ((subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido).Trim() == codigoProducto && prodalmc.Almacen_Id == almacId)
                        //orderby ccosto.CCosto_Descrip ascending
                        select new
                        {
                            Ccosto = distprod.CtaCCosto, /*+ " - " + ccosto.CCosto_Descrip,*/
                            Asignados = distprod.DProdCC_Cantidad,
                            PredespachadoCc = distprod.DProdCC_CantPred
                        }).ToList();
            var temp2 = (from c in temp
                         join ccosto in sicentities.CCostos on (c.Ccosto).Trim() equals (ccosto.Cuenta_Id).Trim() + (ccosto.CCosto_Id).Trim()
                         select new Distribucion
                         {
                             Ccosto = c.Ccosto + " - " + ccosto.CCosto_Descrip,
                             Asignados = c.Asignados,
                             PredespachadoCc = c.PredespachadoCc
                         }).ToList();
            if (temp2.Count > 0)
            {
                return temp2;
            }
            return new List<Distribucion>();
        }
    }
}