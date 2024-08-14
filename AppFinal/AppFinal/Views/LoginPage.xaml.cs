using AppFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            /* antes: this.BindingContext = new LoginViewModel(); */
        }

        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            string username = TxtUsuario.Text;
            string password = TxtPassword.Text;

            if (IsValidDate(username, password))
            {
                await DisplayAlert("Entrando", "Inicio exitoso", "Ok");

                await Navigation.PushAsync(new HomePage());

            }
            else
            {
                await DisplayAlert("Error", "Datos", "Invalidos");
            }

        }

        private bool IsValidDate(string username, string password)
        {
            return username == "mqino" && password == "1234";
        }
    }
}