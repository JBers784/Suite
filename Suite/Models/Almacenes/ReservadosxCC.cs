using ModuloAlmacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.Almacenes
{
    public class ReservadosxCC
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public string NombreAlmacen { get; set; }
        public decimal Asignados { get; set; }
        public decimal PredespachadoCc { get; set; }
      
        public ReservadosxCC() { }
            public List<ReservadosxCC> Listar(string ctaccosto)
            {
             AlmacenesEntities entities = new AlmacenesEntities();
             List<ReservadosxCC> resp = new List<ReservadosxCC>();
            try
            {
                if (!string.IsNullOrEmpty(ctaccosto))
                { 
                     resp = (from munprod in entities.Mundo_Productos
                            join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
                            join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
                            join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
                            join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
                            join distprod in entities.DistProd_CCosto on prodalmc.ProdAlm_Id equals distprod.ProdAlm_Id
                            where ((distprod.CtaCCosto).Trim() == ctaccosto)
                            orderby almec.Almacen_Descrip,munprod.mProducto_Descrip ascending
                            select new ReservadosxCC
                            {
                                Codigo = subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido,
                                Descripcion = munprod.mProducto_Descrip,
                                Existencia = prodalmc.ProdAlm_Existencia,
                                NombreAlmacen = almec.Almacen_Descrip,
                                Asignados = distprod.DProdCC_Cantidad,
                                PredespachadoCc = distprod.DProdCC_CantPred
                            }).ToList() ;
                }
            }
            catch { }
            return resp ;
            }
    }
  
}