using AppMovil1260061.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SharedTransitions;

namespace AppMovil1260061
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new SharedTransitionNavigationPage(new Views.vInicio());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
