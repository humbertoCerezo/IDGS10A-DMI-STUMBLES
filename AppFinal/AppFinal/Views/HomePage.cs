using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppFinal.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            
            this.Title = "Selecciona una Opcion";

            /* Codigo botton Agregar contacto */
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Agregar Soporte";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            /* Codigo botton ver contactos guardados */
            button = new Button();
            button.Text = "Ver Soportes en proceso";
            button.Clicked += Button_ver_Clicked;
            stackLayout.Children.Add(button);

            /* Codigo botton editar contactos guardados */
            button = new Button();
            button.Text = "Editar Soporte";
            button.Clicked += Button_editar_Clicked;
            stackLayout.Children.Add(button);

            /* Codigo botton eliminar contactos guardados */
            button = new Button();
            button.Text = "Eliminar Soporte Realizado ";
            button.Clicked += Button_eliminar_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;

        }

        private async void Button_eliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarContactos());
        }

        private async void Button_editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarContactos());
        }

        private async void Button_ver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vercontactos());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContacts());
        }
        /* Enlace del Codigo botton Agregar contacto */
    }
}