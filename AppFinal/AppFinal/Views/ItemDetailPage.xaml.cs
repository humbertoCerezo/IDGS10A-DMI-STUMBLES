using AppFinal.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppFinal.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}