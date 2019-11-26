using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using BuSimulatorApp.Models;
namespace BuSimulatorApp.Services
{
    public interface IFirebase
    {
        IObservable<Firebase.Database.Streaming.FirebaseEvent<ListaRutasModel>> allBuses();
        //Task<List<ListaRutasModel>> GetBuses();
    }
}
