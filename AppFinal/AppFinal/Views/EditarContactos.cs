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
    public class EditarContactos : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _emailEntry;
        private Entry _phoneEntry;
        private Button _Button;

        Contactos _contactos = new Contactos();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditarContactos ()
        {

            this.Title = "Editar Contactos";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stacklayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Contactos>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stacklayout.Children.Add(_listView);



            _idEntry = new Entry();
            _idEntry.Placeholder = "Contacto";
            _idEntry.IsVisible = false;
            stacklayout.Children.Add( _idEntry );



            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Nombre del contacto";
            stacklayout.Children.Add(_nameEntry);

            _emailEntry = new Entry();
            _emailEntry.Keyboard = Keyboard.Text;
            _emailEntry.Placeholder = "Email";
            stacklayout.Children.Add(_emailEntry);

            _phoneEntry = new Entry();
            _phoneEntry.Keyboard = Keyboard.Text;
            _phoneEntry.Placeholder = "Numero de telefono";
            stacklayout.Children.Add(_phoneEntry);

            _Button = new Button();
            _Button.Text = "Actualizar";
            _Button.Clicked += _button_Clicked;
            stacklayout.Children.Add(_Button);

            Content = stacklayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Contactos contactos = new Contactos()
            {
                    Id = Convert.ToInt32(_idEntry.Text),
                    Name = _nameEntry.Text,
                    Email = _emailEntry.Text,
                    Phone = _phoneEntry.Text
            };

            db.Update( contactos );
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _contactos = (Contactos)e.SelectedItem;
            _idEntry.Text = _contactos.Id.ToString();
            _nameEntry.Text = _contactos.Name;
            _emailEntry.Text = _contactos.Email;
            _phoneEntry.Text = _contactos.Phone;
        }
    }
}