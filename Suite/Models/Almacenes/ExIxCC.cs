using ModuloAlmacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.Almacenes
{
    public class ExIxCC
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string UM { get; set; }
        public string NombreAlmacen { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal importe { get; set; }
        public decimal salalmid { get; set; }
        public int NoVsal { get; set; }
        public DateTime FechaVsal { get; set; }

        public ExIxCC() { }
        public List<ExIxCC> Listar(string ctaccosto, int mes, int año)
        {
            AlmacenesEntities entities = new AlmacenesEntities();
            List<ExIxCC> resp = new List<ExIxCC>();
            try
            {
                if (!string.IsNullOrEmpty(ctaccosto))
                {
                    resp = (from munprod in entities.Mundo_Productos
                            join espprod in entities.EspecificoProductos on munprod.Especifico_Id equals espprod.Especifico_Id
                            join subprod in entities.SubGenericosProductos on espprod.SubGProd_Id equals subprod.SubGProd_Id
                            join prodalmc in entities.Productos_Almacen on munprod.mProducto_Id equals prodalmc.mProducto_Id
                            join almec in entities.Almacenes on prodalmc.Almacen_Id equals almec.Almacen_Id
                            join saldetprod in entities.DetSalAlm on prodalmc.ProdAlm_Id equals saldetprod.ProdAlm_Id
                            join salprod in entities.Salidas_Almacen on saldetprod.SalAlm_Id equals salprod.SalAlm_id
                            where ((salprod.CtaCCosto).Trim() == ctaccosto) && (salprod.SalAlm_Fecha.Year == año) && (munprod.mProducto_Status == "I") //&& (salprod.SalAlm_Fecha.Month == mes)
                            orderby almec.Almacen_Descrip, munprod.mProducto_Descrip, salprod.SalAlm_id ascending
                            select new ExIxCC
                            {
                                Codigo = subprod.Generico_Id + subprod.SubGProd_Codigo + espprod.Especifico_Codigo + munprod.mProducto_Surtido,
                                Descripcion = munprod.mProducto_Descrip,
                                UM = prodalmc.ProdAlm_Um,
                                NombreAlmacen = almec.Almacen_Descrip,
                                cantidad = saldetprod.SalAlm_Cantidad,
                                precio = saldetprod.SalAlm_Precio,
                                importe = saldetprod.SalAlm_Cantidad * saldetprod.SalAlm_Precio,
                                salalmid = saldetprod.SalAlm_Id,
                                NoVsal = salprod.SalAlm_NoVS,
                                FechaVsal = salprod.SalAlm_Fecha
                            }).ToList();
                }
            }
            catch { }
            return resp;
        }

    }
}