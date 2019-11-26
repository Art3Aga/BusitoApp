using System;
using System.Collections.Generic;
using System.Text;
using BuSimulatorApp.Services;
using Xamarin.Forms.Maps;

namespace BuSimulatorApp.Models
{
    public sealed class MapaModel : IMapa
    {
        public static MapaModel Instancia { get; } = new MapaModel();
        private MapaModel() { }

        public void addMarcador(Map mapa, PinType tipoPin, string nombre, double latitud, double longitud)
        {
            var pin = new Pin
            {
                Type = tipoPin,
                Label = nombre,
                Position = new Position(latitud, longitud)
            };
            mapa.Pins.Add(pin);

        }

        public void cambiarStyleMapa(MapType tipoMapa, Map mapa)
        {
            mapa.MapType = tipoMapa;
        }

        public void setPosicion(Map mapa, double lati, double longi, double zoom)
        {
              mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lati, longi),Distance.FromKilometers(zoom)));
        }

        public int getZoom(Map mapa)
        {
            var LatLng = (mapa.VisibleRegion.LatitudeDegrees + mapa.VisibleRegion.LongitudeDegrees) / 2.0f;
            int zoom = (int)Math.Floor(Math.Log(360 / LatLng, 2));
            return zoom;
        }

        public void setZoom(Map map, int zoom)
        {
            var latlongdeg = 360 / (Math.Pow(2, zoom));
            map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdeg, latlongdeg));
        }
    }
}
