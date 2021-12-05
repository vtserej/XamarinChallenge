using System.ComponentModel;
using Xamarin.Forms;
using XamarinChallenge.ViewModels;

namespace XamarinChallenge.Views
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
