using System;
using System.Collections.Generic;
using System.Text;

namespace BuSimulatorApp.Models
{
    public class ListaRutasModel
    {
        //public List<ListaBusesModel> horario { get; set; }
        //public List<ListaParadasModel> listaParadas { get; set; }
        public string nombre_ruta { get; set; }
        public string precio { get; set; }
        public string nombre_abreviado { get; set; }
        public string imgPath { get; set; }
        public string rutaimagen => string.Format("{0}", $"http://192.168.1.7:80/BusesBackend/FotosRutas/{imgPath}");
        public int unidades { get; set; }
        public string hora_inicio { get; set; }
        public string hora_final { get; set; }
    }
}
