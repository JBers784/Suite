using ModuloTransporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suite.Models.Transporte
{
    public class NeumaticosBaterias
    {
        public string matricula { get; set; }
        public string bPais { get; set; }
        public string bMarca { get; set; }
        public string bNoBat { get; set; }
        public string bVol { get; set; }
        public string bAmp { get; set; }
        public string bFecha { get; set; }
        public string bNorma { get; set; }
        public string bTiempo { get; set; }
        public string nMarca { get; set; }
        public string nModelo { get; set; }
        public string nNoNeumatico { get; set; }
        public string nFechaAsignacion { get; set; }
        public string nKmsNorma { get; set; }
        public string nKmsAcum { get; set; }
        public string nDesvKms { get; set; }
        public string Npais { get; set; }

        public NeumaticosBaterias()
        { }
        public List<NeumaticosBaterias> ListaNeumaticosBaterias(string matricula)
        {
            SitransEntities entities = new SitransEntities();
            List<NeumaticosBaterias> resp = new List<NeumaticosBaterias>();
            //adicionar los neumaticos
            List<Neumaticos> neumaticos = (from equipo in entities.Equipos
                              where equipo.eq_matricula.ToLower() == matricula.ToLower() select equipo).FirstOrDefault().Neumaticos.ToList();
            if (neumaticos.Count>0)
            {
                List<NeumaticosBaterias> neumaticosdata = (from n in neumaticos
                                      join mundoneumatico in entities.mundo_neumaticos on n.mneum_Id equals mundoneumatico.mneum_Id
                                      join mundoMarcasNeumaticos in entities.mundo_MarcasNeumaticos on mundoneumatico.mmneum_Id equals mundoMarcasNeumaticos.mmneum_Id
                                      join mundopaises in entities.mundo_Paises on mundoMarcasNeumaticos.mp_Id equals mundopaises.mp_Id
                                     
                                      select new NeumaticosBaterias
                                      {
                                          nMarca = mundoMarcasNeumaticos.mmneum_Marca,
                                          nModelo = mundoneumatico.mneum_Modelo +"/"+mundoneumatico.mneum_Medida,
                                          nNoNeumatico = n.neum_PC,
                                          
                                          nKmsNorma = mundoneumatico.mneum_Norma.ToString(),
                                          nKmsAcum = n.neum_Kms.ToString(),
                                          nDesvKms = (mundoneumatico.mneum_Norma - n.neum_Kms).ToString(),
                                          Npais = mundopaises.mp_Pais
                                      }).ToList();
                for (int i = 0; i < neumaticosdata.Count(); i++)
                {
                    Equipos equipo = neumaticos[i].Equipos.First();
                    string neumatId = neumaticos[i].neum_PC;
                    neumaticosdata[i].nFechaAsignacion = (from a in entities.AsignacionesNeumaticos where (a.eq_NumOperacional == equipo.eq_NumOperacional && a.neum_PC == neumatId) select a.an_Fecha).FirstOrDefault().ToString();
                }
                foreach (var item in neumaticosdata)
                {
                    resp.Add(item);
                }

            }

            //adicionar las baterias
            List<Baterias> baterias = (from equipo in entities.Equipos
                                           where equipo.eq_matricula.ToLower() == matricula.ToLower()
                                           select equipo).FirstOrDefault().Baterias.ToList();
            if (baterias.Count > 0)
            {
                List<NeumaticosBaterias> bateriasdata = (from b in baterias
                                                         join mundobateria in entities.mundo_Baterias on b.mbat_Id equals mundobateria.mbat_Id
                                                         join mundoMarcasbateria in entities.mundo_MarcasBateria on mundobateria.mmbat_Id equals mundoMarcasbateria.mmbat_Id
                                                         join mundopaises in entities.mundo_Paises on mundoMarcasbateria.mp_Id equals mundopaises.mp_Id
                                                         where !(from c in entities.BajasBaterias select c.bat_PC).Contains(b.bat_PC)
                                                           select new NeumaticosBaterias
                                                           {
                                                               bPais = mundopaises.mp_Pais,
                                                               bMarca = mundoMarcasbateria.mmbat_Marca,                                                              
                                                               bNoBat = b.bat_PC,
                                                               bVol = mundobateria.mbat_Voltaje.ToString(),
                                                               bAmp = mundobateria.mbat_Amperaje.ToString(),
                                                               bFecha = b.bat_FechaAlta.ToShortDateString(),
                                                               bNorma = mundobateria.mbat_Norma.ToString(),
                                                               bTiempo = (mundobateria.mbat_Norma - Math.Abs((b.bat_FechaAlta.Month - DateTime.Now.Month) + 12 * (b.bat_FechaAlta.Year - DateTime.Now.Year))).ToString()


            }).ToList();
                foreach (var item in bateriasdata)
                {
                    resp.Add(item);
                }

            }           


            return resp;
        }
    }
   
}