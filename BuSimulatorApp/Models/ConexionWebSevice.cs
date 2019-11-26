using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using BuSimulatorApp.Services;

namespace BuSimulatorApp.Models
{
    public class ConexionWebSevice : IConexionWebService
    {
        #region Propiedades
        public const string URL = "http://192.168.1.7:80/BusesBackend/index.php";
        public const string URLBUSCAR = "http://192.168.1.7:80/BusesBackend/BuscarPHP";
        #endregion
        #region Cliente Http
        public HttpClient getCliente()
        {
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");
            cliente.DefaultRequestHeaders.Add("Connection", "close");
            return cliente;
        }
        #endregion
        #region CRUD
        public async Task<IEnumerable<ListaRutasModel>> getRutas()
        {
            HttpClient cliente = getCliente();
            var resultado = await cliente.GetAsync($"{URL}/Rutas/getRutas");
            if (resultado.IsSuccessStatusCode)
            {
                string contenido = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ListaRutasModel>>(contenido);
            }
            else
            {
                return Enumerable.Empty<ListaRutasModel>();
            }
        }
        public async Task<IEnumerable<ListaParaditasModel>> getParadas()
        {
            HttpClient cliente = getCliente();
            var resultado = await cliente.GetAsync($"{URL}/Paradas/getParadas");
            if (resultado.IsSuccessStatusCode)
            {
                string contenido = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ListaParaditasModel>>(contenido);
            }
            else
            {
                return Enumerable.Empty<ListaParaditasModel>();
            }
        }
        public async Task<IEnumerable<ListaParaditasModel>> getParadasWereRuta(string nombreRuta)
        {
            HttpClient cliente = getCliente();
            var resultado = await cliente.GetAsync($"{URLBUSCAR}/BuscarParadaPorRuta.php?nombre_ruta={nombreRuta}");
            if (resultado.IsSuccessStatusCode)
            {
                string contenido = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ListaParaditasModel>>(contenido);
            }
            else
            {
                return Enumerable.Empty<ListaParaditasModel>();
            }
        }
        public async Task<IEnumerable<ListaParaditasModel>> getRutasWhereParada(string nombreParada)
        {
            HttpClient cliente = getCliente();
            var resultado = await cliente.GetAsync($"{URLBUSCAR}/BuscarRutasPorParada.php?nombre_parada={nombreParada}");
            if (resultado.IsSuccessStatusCode)
            {
                string contenido = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ListaParaditasModel>>(contenido);
            }
            else
            {
                return Enumerable.Empty<ListaParaditasModel>();
            }
        }
        public async Task<IEnumerable<ListaHorariosModel>> getHorariosWereRuta(string nombreParada, string nombreRuta)
        {
            HttpClient cliente = getCliente();
            var resultado = await cliente.GetAsync($"{URLBUSCAR}/BuscarHorariosPorParada.php?nombre_parada={nombreParada}&nombre_ruta={nombreRuta}");
            if (resultado.IsSuccessStatusCode)
            {
                string contenido = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ListaHorariosModel>>(contenido);
            }
            else
            {
                return Enumerable.Empty<ListaHorariosModel>();
            }
        }
        public async Task<IEnumerable<ComentarioModel>> getComentarios()
        {
            HttpClient cliente = getCliente();
            var resultado = await cliente.GetAsync($"{URL}/Comentarios/getComentarios");
            if (resultado.IsSuccessStatusCode)
            {
                string contenido = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ComentarioModel>>(contenido);
            }
            else
            {
                return Enumerable.Empty<ComentarioModel>();
            }
        }
        public async Task<dynamic> EnviarComentario(ComentarioModel comentario)
        {
            HttpClient client = getCliente();
            string json = JsonConvert.SerializeObject(comentario);
            try
            {
                var contenido = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await client.PostAsync($"{URL}/Comentarios/guardarComentario", contenido);
            }
            catch (HttpRequestException ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", $"{ex.Message}", "OK");
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return "";
        }
        #endregion
    }
}
