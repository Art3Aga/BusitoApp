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
    public partial class ComentariosPage : ContentPage
    {
        ConexionWebSevice conexion = new ConexionWebSevice();
        public ComentariosPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var comentarios = await conexion.getComentarios();
            if(comentarios != null)
            {
                listviewComentarios.ItemsSource = comentarios;
            }
        }
        private void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;
            view.TranslationX = -100;
            view.TranslateTo(0, 0, 250, Easing.SinIn);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ComentarPage() { Title = "Nuevo Comentario"});
        }
    }
}