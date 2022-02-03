using ModuloAlmacenes;
using ModuloEconomia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.Almacenes
{
    public class ProductosxCc: PadreAlmacenes
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public decimal? Predespachado { get; set; }
        public decimal Disponible { get; set; }
        public List<Distribucion> Distribucion { get; set; }

        public ProductosxCc () { }

        public ProductosxCc Listar(string codigoProducto, string almacId)
        {
            AlmacenesEntities entities = new AlmacenesEntities();
            ProductosxCc resp = new ProductosxCc();
            ProductosxCc consulta = (from munprod in entities.Mundo_Productos
             join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
             join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
             join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
             join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
             where (subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido) == codigoProducto && prodalmc.Almacen_Id == almacId
             orderby almec.Almacen_Descrip ascending, prodalmc.ProdAlm_Existencia descending
             select new ProductosxCc
             {
                 Codigo = subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido,
                 Descripcion = munprod.mProducto_Descrip,
                 Existencia = prodalmc.ProdAlm_Existencia,
                 Predespachado = prodalmc.ProdAlm_CantPred,
                 Disponible = prodalmc.ProdAlm_Existencia - prodalmc.ProdAlm_CantPred

             }).FirstOrDefault();
            if (consulta != null)
            {
                resp.Codigo = consulta.Codigo;
                resp.Descripcion = consulta.Descripcion;
                resp.Existencia = consulta.Existencia;
                resp.Predespachado = consulta.Predespachado;
                resp.Disponible = consulta.Disponible;
                Distribucion dist = new Distribucion();
                resp.Distribucion = dist.Listado(codigoProducto, almacId);
                return resp;
            }
            else
            {
                consulta = (from munprod in entities.Mundo_Productos
                            join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
                            join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
                            join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
                            join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
                            where (subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido) == codigoProducto
                            orderby almec.Almacen_Descrip ascending, prodalmc.ProdAlm_Existencia descending
                            select new ProductosxCc
                            {
                                Codigo = subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido,
                                Descripcion = munprod.mProducto_Descrip,
                                Existencia = prodalmc.ProdAlm_Existencia,
                                Predespachado = prodalmc.ProdAlm_CantPred,
                                Disponible = prodalmc.ProdAlm_Existencia - prodalmc.ProdAlm_CantPred

                            }).FirstOrDefault();
                if (consulta != null)
                {
                    resp.Codigo = consulta.Codigo;
                    resp.Descripcion = consulta.Descripcion;
                    resp.Existencia = consulta.Existencia;
                    resp.Predespachado = consulta.Predespachado;
                    resp.Disponible = consulta.Disponible;
                    Distribucion dist = new Distribucion();
                    resp.Distribucion = dist.Listado(codigoProducto, almacId);
                    
                }
               
            }
            return resp;

        }
        
    }

   
}