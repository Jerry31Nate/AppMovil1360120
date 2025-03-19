using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil1260061.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vInicio : ContentPage
    {
        public vInicio()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vLogin());
        }
    }
}