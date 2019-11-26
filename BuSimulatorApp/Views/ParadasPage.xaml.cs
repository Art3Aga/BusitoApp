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
    public partial class ParadasPage : ContentPage
    {
        ConexionWebSevice conexion = new ConexionWebSevice();
        public ParadasPage()
        {
            InitializeComponent();
            //listaViewParadas.ItemsSource = listaParadas;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var paraditas = await conexion.getParadas();
            if (paraditas != null)
            {
                listaViewParadas.ItemsSource = paraditas;
            }
        }

        private async void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var paraditas = await conexion.getParadas();
            List<ListaParaditasModel> busqueda = paraditas.Where(
                item => item.nombre_parada.Contains(txtBuscar.Text)).ToList();
            listaViewParadas.ItemsSource = busqueda;
        }

        private async void listaViewParadas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListaParaditasModel item = e.SelectedItem as ListaParaditasModel;
            await Navigation.PushAsync(new ParadaDetallePage(item));
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