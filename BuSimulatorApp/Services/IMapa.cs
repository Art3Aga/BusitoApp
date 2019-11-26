using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
namespace BuSimulatorApp.Services
{
    public interface IMapa
    {
        void cambiarStyleMapa(MapType tipoMapa, Map mapa);
        void addMarcador(Map mapa, PinType tipoPin, string nombre, double latitud, double longitud);
        void setPosicion(Map mapa, double lati, double longi, double zoom);
        int getZoom(Map mapa);
        void setZoom(Map map, int zoom);
    }
}
