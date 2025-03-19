using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMovil1260061.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil1260061.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vLogin : ContentPage
    {
        public vLogin ()
        {
            InitializeComponent();
            BindingContext = new vmLogin();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vRecuperar());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vRegistrarUsuarios());
        }
    }
}