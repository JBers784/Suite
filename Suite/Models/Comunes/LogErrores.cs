using Suite.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models
{
    public class LogErrores
    {
        public string Accion { get; set; }
        public string Error { get; set; }
        public System.DateTime Fecha { get; set; }

        public LogErrores() { }

        public void Insertar(string accionrealizandose, string errordado)
        {
            try
            {
                var log = new LogErrores
                {
                    Accion = accionrealizandose,
                    Error = errordado,
                    Fecha = DateTime.Now,                  
                };
               
                Correo.Email(log);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

}