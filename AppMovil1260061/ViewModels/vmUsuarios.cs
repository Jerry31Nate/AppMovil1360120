using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Auth;
using AppMovil1260061.Models;
using AppMovil1260061.Data;
using System.Threading.Tasks;
using AppMovil1260061.Connection;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace AppMovil1260061.ViewModels
{
    public class vmUsuarios : BaseViewModel
    {
        #region Variables
        string txtFullName;
        string txtEmail;
        string txtPhone;
        string txtUserName;
        string txtImage;
        string txtPassword;
        #endregion

        #region Objetos
        public string TxtFullName
        {
            get { return txtFullName; }
            set { SetValue(ref txtFullName, value); }
        }
        public string TxtEmail
        {
            get { return txtEmail; }
            set { SetValue(ref txtEmail, value); }
        }
        public string TxtPhone
        {
            get { return txtPhone; }
            set { SetValue(ref txtPhone, value); }
        }
        public string TxtUserName
        {
            get { return txtUserName; }
            set { SetValue(ref txtUserName, value); }
        }
        public string TxtImage
        {
            get { return txtImage; }
            set { SetValue(ref txtImage, value); }
        }
        public string TxtPassword
        {
            get { return txtPassword; }
            set { SetValue(ref txtPassword, value); }
        }
        #endregion

        #region Procesos
        private async Task InsertarUsuario()
        {
            var funcion = new dUsuarios();
            var parametro = new mUsuarios();
            parametro.FullName = TxtFullName;
            parametro.Email = TxtEmail;
            parametro.Phone = TxtPhone;
            parametro.UserName = TxtUserName;
            parametro.Image = TxtImage;
            UserDialogs.Instance.ShowLoading("Registrando Usuario");
            var respuesta = await funcion.RegistrarUsuario(parametro);
            if (respuesta==true)
            {
                await AccesoAuth(TxtEmail, TxtPassword);
            }
            
        }

        private async Task AccesoAuth(string email, string password)
        {
               var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConexionFirebase.Apykey));
               var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
               UserDialogs.Instance.HideLoading();
               await DisplayAlert("Registro", "Usuario registrado con éxito", "Ok");
        }
        #endregion

        #region comandos
        public Command InsertarUsuarioCommand { get;}
        #endregion

        #region constructor
        public vmUsuarios(INavigation navigation)
        {
            Navigation = navigation;
            InsertarUsuarioCommand = new Command(async () => await InsertarUsuario());
        }
        #endregion

    }
}