using System;
using System.Collections.Generic;
using System.Text;

namespace BuSimulatorApp.Models
{
    public class ListaHorariosModel
    {
        public string nombre_bus { get; set; }
        public string horario_ida { get; set; }
        public string horario_regreso { get; set; }
        public string nombre_motorista { get; set; }
        public string placa { get; set; }
        public string imgPath { get; set; }
        public string rutaImagen => string.Format("{0}", $"http://192.168.1.7:80/BusesBackend/FotosRutas/{imgPath}");
    }
}
