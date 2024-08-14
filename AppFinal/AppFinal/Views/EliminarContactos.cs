using AppFinal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AppFinal.Views
{
    public class EliminarContactos : ContentPage
    {
        private Xamarin.Forms.ListView _listView;
        private Xamarin.Forms.Button _button;

        Contactos _contactos = new Contactos();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public EliminarContactos()
        {
            this.Title = "Editar Contactos";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stacklayout = new StackLayout();

            _listView = new Xamarin.Forms.ListView();
            _listView.ItemsSource = db.Table<Contactos>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stacklayout.Children.Add(_listView);

            _button = new Xamarin.Forms.Button();
            _button.Text = "Eliminar";
            _button.Clicked += _button_Clicked;
            stacklayout.Children.Add(_button);


            Content = stacklayout;
        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _contactos = (Contactos)e.SelectedItem;
           
        }
        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Contactos>().Delete(x => x.Id == _contactos.Id);
            await Navigation.PopAsync();

        }
    }
}