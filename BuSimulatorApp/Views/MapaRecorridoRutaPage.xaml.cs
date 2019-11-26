using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BuSimulatorApp.Models;
using Xamarin.Forms.Maps;

namespace BuSimulatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaRecorridoRutaPage : ContentPage
    {
        ConexionWebSevice conexion = new ConexionWebSevice();
        //ListaRutasModel rutaSelect;
        bool isAbajo = false;
        string rutaSelect;
        //double latitudInicial = 0, longitudInicial = 0;
        List<ListaParadasModel> listaParadasRutaSeleccionada = new List<ListaParadasModel>();
        public MapaRecorridoRutaPage(string rutaSeleccionada)
        {
            InitializeComponent();
            lbltitulo.Text = $"RECORRIDO DE LA {rutaSeleccionada}";
            //this.rutaSelect = rutaSeleccionada;
            Title = rutaSeleccionada;
            this.rutaSelect = rutaSeleccionada;
            MapaModel.Instancia.setPosicion(mapaParadas, 13.483152, -88.175336, 1.3);
            /*foreach (ListaParadasModel item in rutaSeleccionada.listaParadas)
            {
                MapaModel.Instancia.addMarcador(
                    mapaParadas, PinType.SearchResult, item.nombre_parada, item.latitud, item.longitud
                );
            }
            listViewParadas.ItemsSource = rutaSeleccionada.listaParadas;*/
            btnDown.Source = ImageSource.FromFile("down.png");
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var paradas = await conexion.getParadasWereRuta(this.rutaSelect);
            if (paradas != null)
            {
                foreach (ListaParaditasModel item in paradas)
                {
                    MapaModel.Instancia.addMarcador(
                        mapaParadas, PinType.Place, item.nombre_parada, item.latitud, item.longitud
                    );
                }
                listViewParadas.ItemsSource = paradas;
            }
        }
        public void resizeStack(double height)
        {
            Device.BeginInvokeOnMainThread(() => 
            {
                stackParadas.HeightRequest = height;
                stackParadas.ForceLayout();
                this.ForceLayout();
            });
        }
        private void btnSatelite_Clicked(object sender, EventArgs e)
        {
            MapaModel.Instancia.cambiarStyleMapa(MapType.Satellite, mapaParadas);
        }

        private void btnStreets_Clicked(object sender, EventArgs e)
        {
            MapaModel.Instancia.cambiarStyleMapa(MapType.Street, mapaParadas);
        }

        private void btnHibryd_Clicked(object sender, EventArgs e)
        {
            MapaModel.Instancia.cambiarStyleMapa(MapType.Hybrid, mapaParadas);
        }

        private void btnPosicion_Clicked(object sender, EventArgs e)
        {
            MapaModel.Instancia.setPosicion(mapaParadas, 13.483152, -88.175336, 1.3);
        }

        private async void btnDown_Clicked(object sender, EventArgs e)
        {
            if (this.isAbajo == false)
            {
                await Task.WhenAll(stackParadas.TranslateTo(0, -170, 1000, Easing.CubicIn));
                this.isAbajo = true;
            }
            else
            {
                await Task.WhenAll(stackParadas.TranslateTo(0, 30, 1000, Easing.CubicIn));
                this.isAbajo = false;
            }
        }

        private void listViewParadas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ListaParaditasModel;
            MapaModel.Instancia.setPosicion(mapaParadas, item.latitud, item.longitud, 0.3);
        }

        private void stackParadas_Tapped(object sender, EventArgs e)
        {
            //double ancho = stackParadas.Width;
            //double alto = stackParadas.Height;
            //var animation = new Animation();
            //var stack = new Animation(s => stackParadas.TranslationY = s, stackParadas.TranslationY - 300, 200);
            //alto = 250;
            //stackParadas.TranslateTo(0, TranslationY - 500, 300);
            //Console.WriteLine($"ANCHO STACK ============= {stackParadas.Width}\nALTO STACK ============= {stackParadas.Height}");
            //animation.Add(0, 1, stack);
            //animation.Commit(this, "Slide", 16, 400, Easing.BounceIn);
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