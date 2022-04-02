using SatStackerMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SatStackerMobile.Views
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