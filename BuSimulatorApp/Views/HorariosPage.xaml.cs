using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuSimulatorApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuSimulatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorariosPage : ContentPage
    {
        ConexionWebSevice conexion = new ConexionWebSevice();
        ListaParaditasModel paradaSelect;
        public HorariosPage(ListaParaditasModel paradaSeleccionada)
        {
            InitializeComponent();
            this.paradaSelect = paradaSeleccionada;
            Title = paradaSeleccionada.nombre_parada;
            labelTitulo.Text = $"Horarios en {paradaSeleccionada.nombre_parada}";
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var horarios = await conexion.getHorariosWereRuta(this.paradaSelect.nombre_parada, this.paradaSelect.nombre_ruta);
            if (horarios != null)
            {
                listviewHorarios.ItemsSource = horarios;
            }
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