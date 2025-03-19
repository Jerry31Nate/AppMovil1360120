using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovil1260061.ViewModels;

namespace AppMovil1260061.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class vRegistrarProducto : ContentPage
	{
		public vRegistrarProducto ()
		{
			InitializeComponent ();
			BindingContext = new vmProductos();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}