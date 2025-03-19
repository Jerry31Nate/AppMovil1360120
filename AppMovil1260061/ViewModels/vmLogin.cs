using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Auth;
using AppMovil1260061.Models;
using AppMovil1260061.Views;
using AppMovil1260061.Connection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace AppMovil1260061.ViewModels
{
    class vmLogin : BaseViewModel
    {
        #region variables
        string txtEmail;
        string txtPassword;
        #endregion

        #region objetos
        public string TxtEmail
        {
            get { return txtEmail; }
            set { txtEmail = value; OnPropertyChanged(); }
        }
        public string TxtPassword
        {
            get { return txtPassword; }
            set { SetValue(ref txtPassword, value); }
        }
        #endregion

        #region Procesos

        private async Task ValidarLogin()
        {
            bool respuesta = await IniciarSesion();
            if (respuesta == true)
            {
                Application.Current.MainPage = new NavigationPage(new vMenuPrincipal());
                UserDialogs.Instance.HideLoading();
            }
        }
        private async Task<bool> IniciarSesion()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Instalando Virus");
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConexionFirebase.Apykey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(TxtEmail, TxtPassword);
                var token = JsonConvert.SerializeObject(auth);
                Preferences.Set("token", token);
                return true;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Error", ex.Message, "Aceptar");
                return false;
            }
        }
        #endregion

        #region Comandos
        public Command LoginComando { get; }
        #endregion

        #region Constructor
        public vmLogin()
        {
            LoginComando = new Command(async () => await ValidarLogin());
        }
        #endregion
    }
}
