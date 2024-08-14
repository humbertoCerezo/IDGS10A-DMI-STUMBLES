using AppFinal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppFinal.Views
{
    public class vercontactos : ContentPage
    {

        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public vercontactos()
        {
            this.Title = "Contactos Guardados";

            var db =new SQLiteConnection (_dbPath);

            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Contactos>().OrderBy(x=>x.Name).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;


        }
    }
}