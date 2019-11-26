using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using BuSimulatorApp.Services;
using Firebase.Database.Streaming;

namespace BuSimulatorApp.Models
{
    public sealed class FirebaseModel : IFirebase
    {
        public static FirebaseModel Instancia { get; } = new FirebaseModel();
        private FirebaseModel() { }
        FirebaseClient firebaseClient = new FirebaseClient("https://busimulator-83575.firebaseio.com/");
        public IObservable<FirebaseEvent<ListaRutasModel>> allBuses()
        {
            return firebaseClient.Child("buses").AsObservable<ListaRutasModel>();
        }

        public async Task<List<ListaRutasModel>> GetBuses()
        {
            return (await firebaseClient
              .Child("buses")
              .OnceAsync<ListaRutasModel>()).Select(item => new ListaRutasModel
              {
                  nombre_ruta = item.Object.nombre_ruta,
                  nombre_abreviado = item.Object.nombre_abreviado,
                  precio = item.Object.precio,
                  //listaParadas = item.Object.listaParadas,
              }).ToList();
        }
    }
}
