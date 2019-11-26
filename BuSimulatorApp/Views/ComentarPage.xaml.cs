using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuSimulatorApp.Models;
using BuSimulatorApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuSimulatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComentarPage : ContentPage
    {
        ComentarioModel comentario = new ComentarioModel();
        ConexionWebSevice conexion = new ConexionWebSevice();
        public ComentarPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            comentario.texto = txtcomentario.Text;
            comentario.nombre_usuario = txtnombre.Text;
            comentario.fecha = $"{DateTime.Now.ToString("MM/dd/yyyy")} {DateTime.Now.ToString("HH:mm")}";
            await conexion.EnviarComentario(comentario);
            DependencyService.Get<IToast>().ToastLong($"{txtnombre.Text} su comentario a sido publicado correctamente\nLos Administradores de la aplicacion leerán el comentario");
            txtnombre.Text = "";
            txtcomentario.Text = "";
            await Navigation.PopModalAsync();
        }
    }
}