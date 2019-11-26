using System;
using System.Collections.Generic;
using System.Text;
using BuSimulatorApp.Services;
using Xamarin.Essentials;
namespace BuSimulatorApp.Models
{
    public class InternetConexion : IConexionInternet
    {
        NetworkAccess current = Connectivity.NetworkAccess;
        IEnumerable<ConnectionProfile> profiles = Connectivity.ConnectionProfiles;
        public bool VerificarInternet()
        {
            if (this.current == NetworkAccess.Internet)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public bool VerificarWifi()
        {
            if (this.profiles.Equals(ConnectionProfile.WiFi))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
