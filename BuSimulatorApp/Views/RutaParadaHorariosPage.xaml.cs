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
    public partial class RutaParadaHorariosPage : ContentPage
    {
        public RutaParadaHorariosPage(ListaRutasModel rutaSeleccionada)
        {
            InitializeComponent();
            Title = $"{rutaSeleccionada.nombre_ruta}";
            //listaViewHorarios.ItemsSource = rutaSeleccionada.horario;
            lbltitulo.Text = $"HORARIOS {Title}";
        }

        private void listaViewHorarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //lbltitulo.TranslateTo(0, lbltitulo.TranslationY + 200, 250);
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