using AppFinal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppFinal.Views
{
    public class AddContacts : ContentPage
    {
        private Entry _nameEntry;
        private Entry _emailEntry;
        private Entry _phoneEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public AddContacts()
        {
            this.Title = "Agregar Contacto";
            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Nombre del contacto";
            stackLayout.Children.Add( _nameEntry );

            _emailEntry = new Entry();
            _emailEntry.Keyboard = Keyboard.Text;
            _emailEntry.Placeholder = "Correo electronico";
            stackLayout.Children.Add(_emailEntry );

            _phoneEntry = new Entry();
            _phoneEntry.Keyboard = Keyboard.Numeric;
            _phoneEntry.Placeholder = "Numero de contacto";
            stackLayout.Children.Add(_phoneEntry);   

            _saveButton = new Button();
            _saveButton.Text = "Agregar";
            _saveButton.Clicked += _saveButton_clicked;
            stackLayout.Children.Add ( _saveButton );

            Content = stackLayout;



        }

        private async void _saveButton_clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection( _dbPath );
            db.CreateTable <Contactos>();

            var maxPK = db.Table<Contactos>().OrderByDescending(c => c.Id).FirstOrDefault ();
            Contactos contactos = new Contactos()

            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Name = _nameEntry.Text,
                Email = _emailEntry.Text,
                Phone = _phoneEntry.Text

            };

            db.Insert(contactos);
            await DisplayAlert(null, contactos.Name + "Guardado", "Ok");
            await Navigation.PopAsync();

        }
    }
}