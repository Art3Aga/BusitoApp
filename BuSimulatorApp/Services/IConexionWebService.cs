using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace BuSimulatorApp.Services
{
    public interface IConexionWebService
    {
        HttpClient getCliente();

    }
}
