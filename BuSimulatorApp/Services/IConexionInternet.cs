using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace BuSimulatorApp.Services
{
    public interface IConexionInternet
    {
        bool VerificarInternet();
        bool VerificarWifi();
    }
}
