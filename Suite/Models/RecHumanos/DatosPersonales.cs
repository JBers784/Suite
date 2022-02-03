using ModuloRecHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.RecHumanos
{
    public class DatosPersonales
    {
        public string Ci { get; set; }
        public string NombAp { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string  NivEscol { get; set; }
        public string raza { get; set; }
        public string EstadoCivil { get; set; }
        public string numCobro { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public string CategoriaOc { get; set; }
        public DateTime FechaRama { get; set; }
        public DateTime FechaEmp { get; set; }
        public decimal salario { get; set; }


        public DatosPersonales() { }
        public List<DatosPersonales> Listar(string ci)
        {
            CapitalHumanoEntities entities = new CapitalHumanoEntities();
            List<DatosPersonales> resp = new List<DatosPersonales>();
            try
            {
                if (!string.IsNullOrEmpty(ci ))
                {
                    resp = (from datospers in entities.Datos_Personales 
                            //join trabajad  in entities.Trabajador          on datospers.CIdentidad equals trabajad.CIdentidad 
                            join trabajad  in entities.Trabajador          on datospers.CIdentidad  equals trabajad.CIdentidad into f from trabajad in f.DefaultIfEmpty()
                            join plantpers in entities.Plantilla_Personal  on trabajad.Num_Cobro   equals plantpers.Num_Cobro 
                            join cargo     in entities.Cargo               on plantpers.Cod_Cargo  equals cargo.Cod_Cargo 
                            join catocup   in entities.CategOcup           on cargo.Co_Codigo      equals catocup.Co_Codigo 
                            join area      in entities.Area                on plantpers.Cod_Area   equals area.Cod_Area
                            where datospers.CIdentidad == ci 
                            select new DatosPersonales
                            {
                                Ci = datospers.CIdentidad ,
                                NombAp = datospers.dp_NombreApellidos ,
                                Sexo = (datospers.dp_Sexo == "M") ? "Masculino" :
                                       (datospers.dp_Sexo == "F") ? "Femenino" :"",
                                Direccion  = datospers.dp_Direccion ,
                                NivEscol = (datospers.dp_NEscolar == "2") ? "2do grado" :
                                           (datospers.dp_NEscolar == "3") ? "3er grado" :
                                           (datospers.dp_NEscolar == "4") ? "4to grado" :
                                           (datospers.dp_NEscolar == "5") ? "5to grado" :
                                           (datospers.dp_NEscolar == "6") ? "6to grado" :
                                           (datospers.dp_NEscolar == "7") ? "7mo grado" :
                                           (datospers.dp_NEscolar == "8") ? "8vo grado" :
                                           (datospers.dp_NEscolar == "9") ? "9no grado" :
                                           (datospers.dp_NEscolar == "10") ? "10mo grado" :
                                           (datospers.dp_NEscolar == "11") ? "11no grado" :
                                           (datospers.dp_NEscolar == "12") ? "12mo grado" :
                                           (datospers.dp_NEscolar == "M") ? "Tec.Medio" :
                                           (datospers.dp_NEscolar == "O") ? "Ob.Calif." :
                                           (datospers.dp_NEscolar == "U") ? "Universitario" : "",
                                raza = (datospers.dp_Raza == "M") ? "Mestizo" :
                                       (datospers.dp_Raza == "B") ? "Blanco" :
                                       (datospers.dp_Raza == "N") ? "Negro" : "",
                                EstadoCivil = (datospers.dp_EstadoCivil == "C") ? "Casado" :
                                              (datospers.dp_EstadoCivil == "S") ? "Soltero" : "",
                                numCobro = trabajad.Num_Cobro ,
                                area = area.DescripArea ,
                                cargo = cargo .DescripCargo ,
                                CategoriaOc = catocup.CO_Descrip ,
                                FechaRama = trabajad.FRama ,
                                FechaEmp = trabajad.FEmpresa ,
                                salario = cargo.SalarioBasico 
                            }).ToList();
                }
            }
            catch { }
            return resp;
        }
    }
}