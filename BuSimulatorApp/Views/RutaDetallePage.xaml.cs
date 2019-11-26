using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BuSimulatorApp.Models;

namespace BuSimulatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RutaDetallePage : ContentPage
    {
        string rutaSelect;
        ConexionWebSevice conexion = new ConexionWebSevice();
        string textoButton = "";
        public RutaDetallePage(string rutaSeleccionada)
        {
            InitializeComponent();
            this.rutaSelect = rutaSeleccionada;
            this.textoButton = $"Ver Mapa Recorrido de {rutaSeleccionada}";
            btnVerMapa.Text = this.textoButton;
            labelTitulo.Text = $"Recorrido que Realiza la \n{rutaSeleccionada}";
            //img.Source = ImageSource.FromUri(new Uri(rutaSeleccionada.imgPath));
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var paradas = await conexion.getParadasWereRuta(this.rutaSelect);
            if (paradas != null)
            {
                listViewParadas.ItemsSource = paradas;
            }
        }

        private async void btnVerMapa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapaRecorridoRutaPage(this.rutaSelect));
        }

        private async void listViewParadas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ListaParaditasModel;
            await Navigation.PushAsync(new HorariosPage(item));
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