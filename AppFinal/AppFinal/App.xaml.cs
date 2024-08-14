using AppFinal.Services;
using AppFinal.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinal
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            /* Pagina principal antes HomePage (new HomePage());*/

            MainPage = new NavigationPage (new PrincipalPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
