using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloAlmacenes;

namespace Suite.Models.Almacenes
{
    public class Productos:PadreAlmacenes
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public string NombreAlmacen { get; set; }
        public string Estatus { get; set; }
        public string Um { get; set; }

        public Productos() { }

        public  List<Productos> Listar(string descripcion, string almcId)
        {
            AlmacenesEntities entities = new AlmacenesEntities();
            List<Productos> resp = new List<Productos>();

            try
            {
                if (!string.IsNullOrEmpty(almcId))
                {
                    resp = (from munprod in entities.Mundo_Productos
                            join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
                            join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
                            join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
                            join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
                            where (almec.Almacen_Id == almcId && munprod.mProducto_Descrip.Contains(descripcion) && prodalmc.ProdAlm_Existencia > 0)
                            orderby almec.Almacen_Descrip ascending, prodalmc.ProdAlm_Existencia descending
                            select new Productos
                            {
                                Codigo = subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido,
                                Descripcion = munprod.mProducto_Descrip,
                                Existencia = prodalmc.ProdAlm_Existencia,
                                NombreAlmacen = almec.Almacen_Descrip,
                                Um= prodalmc.ProdAlm_Um,
                                Estatus = munprod.mProducto_Status == "H" ? "Útil y herramienta" :
                                munprod.mProducto_Status == "B" ? "Medio Básico" :
                                munprod.mProducto_Status == "I" ? "Equipo por Instalar" :
                                munprod.mProducto_Status == "R" ? "Medio de Rotación" :
                                "Sin Clasificar"

                            }).ToList();
                }
                else
                {
                    resp = (from munprod in entities.Mundo_Productos
                            join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
                            join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
                            join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
                            join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
                            where (munprod.mProducto_Descrip.Contains(descripcion) && prodalmc.ProdAlm_Existencia > 0)
                            orderby almec.Almacen_Descrip ascending, prodalmc.ProdAlm_Existencia  descending
                            select new Productos
                            {
                                Codigo = subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido,
                                Descripcion = munprod.mProducto_Descrip,
                                Existencia = prodalmc.ProdAlm_Existencia,
                                NombreAlmacen = almec.Almacen_Descrip,
                                Um = prodalmc.ProdAlm_Um,
                                Estatus = munprod.mProducto_Status == "H" ? "Útil y herramienta" :
                                munprod.mProducto_Status == "B" ? "Medio Básico" :
                                munprod.mProducto_Status == "I" ? "Equipo por Instalar" :
                                munprod.mProducto_Status == "R" ? "Medio de Rotación" :
                                "Sin Clasificar"

                            }).ToList();
                }
            }
            catch { }

            return resp;

        }

       

    }
}