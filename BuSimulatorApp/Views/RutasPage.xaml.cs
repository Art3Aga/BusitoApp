using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Cards;
using System.Net.Http;
using Newtonsoft.Json;
using BuSimulatorApp.Models;
using BuSimulatorApp.Services;

namespace BuSimulatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RutasPage : ContentPage
    {
        ConexionWebSevice conexion = new ConexionWebSevice();
        //InternetConexion InternetConexion = new InternetConexion();
        public RutasPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //listaViewRutas.ItemsSource = FirebaseModel.Instancia.allBuses().AsObservableCollection<ListaRutasModel>();
            //List<ListaRutasModel> buses = await FirebaseModel.Instancia.GetBuses();
            var rutas = await conexion.getRutas();
            if (rutas != null)
            {
                listaViewRutas.ItemsSource = rutas;
            }

        }

        private async void listaViewRutas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListaRutasModel item = e.SelectedItem as ListaRutasModel;
            await Navigation.PushAsync(new RutaDetallePage(item.nombre_ruta));
        }

        private async void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busitos = await conexion.getRutas();
            List<ListaRutasModel> busqueda = busitos.Where(item => item.nombre_ruta.Contains(txtBuscar.Text)).ToList();
            listaViewRutas.ItemsSource = busqueda;
        }

        private void btnVerRecorrido_Clicked(object sender, EventArgs e)
        {

        }

        private void listaViewRutas_CardTapped(object sender, TappedEventArgs e)
        {
            //var item = e.Parameter as ListaBusesModel;
            var item = ((SfCardLayout)sender);
            var select = ((ListaRutasModel)item.CardTappedCommandParameter);
            //Console.WriteLine($"SELECIONADO: =======> {sender.ToString()}");
            //Console.WriteLine($"SELECIONAD222O: =======> {e.Parameter.ToString()}");
            //ListaRutasModel item = e.Parameter as ListaRutasModel;
            //Console.WriteLine($"ITEM SELECCIONADO : ================== {item}");
            //var item = e.Parameter as ListaRutasModel;
            //await Navigation.PushAsync(new RutaDetallePage(item));
        }

        private async void listaViewRutas_Refreshing(object sender, EventArgs e)
        {
            listaViewRutas.IsRefreshing = true;
            var busitos = await conexion.getRutas();
            if (busitos != null)
            {
                listaViewRutas.ItemsSource = busitos;
                listaViewRutas.IsRefreshing = false;
            }
        }

        private async void btnVerDetalle_Clicked(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender);
            var rutaSeleccionada = ((ListaRutasModel)item.CommandParameter);
            await Navigation.PushModalAsync(new VerInfoRuta() { BindingContext = rutaSeleccionada });
        }

        private void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;
            view.TranslationX = -100;
            view.TranslateTo(0, 0, 250, Easing.SinIn);
        }
    }
}