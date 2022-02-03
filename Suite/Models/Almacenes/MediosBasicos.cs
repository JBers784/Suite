using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloAlmacenes;

namespace Suite.Models.Almacenes
{
    public class MediosBasicos 
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public string Um { get; set; }
        public string NombreAlmacen { get; set; }
       

        public MediosBasicos() { }

        public MediosBasicos(string Codigo, string Descripcion, decimal Existencia, string Um, string NombreAlmacen)
        {
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
            this.Existencia = Existencia;
            this.Um = Um;
            this.NombreAlmacen = NombreAlmacen;
         }

        public List<MediosBasicos> ListaMB()
        {
            AlmacenesEntities entities = new AlmacenesEntities();
            List<MediosBasicos> resp = new List<MediosBasicos>();
            var consulta = (from munprod in entities.Mundo_Productos
                            join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
                            join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
                            join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
                            join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
                            where (munprod.mProducto_Status == "B" && prodalmc.ProdAlm_Existencia != 0)
                            orderby almec.Almacen_Descrip ascending, prodalmc.ProdAlm_Existencia descending
                            select new 
                            {
                                Codigo = subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido,
                                Descripcion = munprod.mProducto_Descrip,
                                Existencia = prodalmc.ProdAlm_Existencia,
                                Um = prodalmc.ProdAlm_Um,
                                NombreAlmacen = almec.Almacen_Descrip
                            }).ToList();

            foreach (var item in consulta)
            {
                resp.Add(new MediosBasicos(item.Codigo , item.Descripcion , item.Existencia, item.Um,  item.NombreAlmacen));
            }
            return resp;
        }

    }
}