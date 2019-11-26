using System;
using System.Collections.Generic;
using System.Text;
using BuSimulatorApp.Models;
namespace BuSimulatorApp.Models
{
    public class ListaRecorridosModel
    {
        public string nombre_parada { get; set; }
        public List<ListaRutasModel> listaRutas { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }
}
