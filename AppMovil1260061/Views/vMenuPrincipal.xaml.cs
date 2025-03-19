using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovil1260061.ViewModels;


namespace AppMovil1260061.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vMenuPrincipal : Xamarin.Forms.TabbedPage
    {
        public vMenuPrincipal()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            BindingContext = new vmMenuPrincipal();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vLogin());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vRegistrarProducto());
        }
    }
}