

using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace Suite.Models.Comunes
{
    public class Visitantes
    {
        public int Mobile { get; set; }
        public int Desktop { get; set; }

        public static string Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Suite\Contador\Contador.json");

        const string sessionvar = "checkCounter";
        public Visitantes() { }


        public static Visitantes Leer()
        {
            Visitantes visitas = new Visitantes() { Desktop = 0, Mobile = 0 };
            try
            {
                using (StreamReader jsonStream = File.OpenText(Path))
                {
                    var json = jsonStream.ReadToEnd();
                    Visitantes lectura = JsonConvert.DeserializeObject<Visitantes>(json);

                    if (lectura != null)
                    {
                        visitas = lectura;
                    }
                }
            }
            catch (Exception e)
            {
                return new Visitantes();
            }
            return visitas;
        }
        public static bool Actualizar( Visitantes visitante)
        {

            //Si existe variable de estado asociada al visitante: TERMINAR return false
            if (HttpContext.Current.Session[sessionvar] != null) { return false; }
            //Crear la variable de sesion....
            HttpContext.Current.Session[sessionvar] = (byte)0;

            Visitantes resp = Leer();
            resp.Mobile += visitante.Mobile;
            resp.Desktop += visitante.Desktop;
            string json = JsonConvert.SerializeObject(resp);
            File.WriteAllText(Path, json);
            return true;
        }
    }
}