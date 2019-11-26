using System;
using System.Collections.Generic;
using System.Text;

namespace BuSimulatorApp.Models
{
    public class ListaParadasModel
    {
        public string nombre_parada { get; set; }
        public List<ListaBusesModel> horarios { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }
}
