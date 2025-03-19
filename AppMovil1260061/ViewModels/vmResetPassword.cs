using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Firebase.Auth;
using AppMovil1260061.Connection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovil1260061.ViewModels
{
    class vmResetPassword : BaseViewModel
    {
        #region Variables
        string txtEmail;
        #endregion

        #region Objetos
        public string TxtEmail
        {
            get { return txtEmail; }
            set { SetValue(ref txtEmail, value); }
        }
        #endregion

        #region Procesos
        private async Task ResetearContraseña()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Enviando Correo");
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConexionFirebase.Apykey));
                await authProvider.SendPasswordResetEmailAsync(TxtEmail);
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Aviso", "Correo Enviado", "Aceptar");
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Aviso", "Correo Enviado. Correo Invalido", "Aceptar");
            }
        }
        #endregion

        #region Comandos
        public Command ResetPassword { get; }
        #endregion

        #region Constructor
        public vmResetPassword()
        {
            ResetPassword = new Command(async () => await ResetearContraseña());
        }
        #endregion
    }
}
