using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using BuSimulatorApp.Models;

namespace BuSimulatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParadaDetallePage : ContentPage
    {
        ConexionWebSevice conexion = new ConexionWebSevice();
        ListaParaditasModel select;
        public ParadaDetallePage(ListaParaditasModel paradaSeleccionada)
        {
            InitializeComponent();
            Title = paradaSeleccionada.nombre_parada;
            this.select = paradaSeleccionada;
            lbltitulo.Text = $"RUTAS QUE PASAN POR '{paradaSeleccionada.nombre_parada}'";
            //listaViewRutas.ItemsSource = paradaSeleccionada.listaRutas;
            MapaModel.Instancia.setPosicion(
                mapaParadaSeleccionada, paradaSeleccionada.latitud, paradaSeleccionada.longitud, 0.55
            );
            MapaModel.Instancia.addMarcador(
                mapaParadaSeleccionada, PinType.Place, paradaSeleccionada.nombre_parada, paradaSeleccionada.latitud, paradaSeleccionada.longitud
            );
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var rutitas = await conexion.getRutasWhereParada(this.select.nombre_parada);
            if (rutitas != null)
            {
                listaViewRutas.ItemsSource = rutitas;
            }
        }

        private async void listaViewRutas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListaParaditasModel item = e.SelectedItem as ListaParaditasModel;
            await Navigation.PushAsync(new RutaDetallePage(item.nombre_ruta));
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