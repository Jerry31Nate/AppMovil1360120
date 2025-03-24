using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Models;
using AppMovil1260061.ViewModels;
using AppMovil1260061.Data;
using Firebase.Database.Query;
using AppMovil1260061.Connection;
using System.Linq;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovil1260061.ViewModels
{
    public class vmClientes : BaseViewModel
    {
        #region Variables
        public string txtapellidosnombre;
        public string txtdni;
        public string txtfotocasa;
        public string txtdireccion;
        public string txttelefono;
        public string txtciudad;
        public string txtocupacion;
        public string txtcorreo;
        #endregion

        #region Objetos

        public string Txtapellidosnombre
        {
            get {  return txtapellidosnombre; }
            set { SetValue(ref txtapellidosnombre, value);}
        }
        public string Txtdni
        {
            get { return txtdni; }
            set { SetValue(ref txtdni, value); }
        }
        public string Txtfotocasa
        {
            get { return txtfotocasa; }
            set { SetValue(ref txtfotocasa, value); }
        }
        public string Txtdireccion
        {
            get { return txtdireccion; }
            set { SetValue(ref txtdireccion, value); }
        }
        public string Txttelefono
        {
            get { return txttelefono; }
            set { SetValue(ref txttelefono, value); }
        }
        public string Txtciudad
        {
            get { return txtciudad; }
            set { SetValue(ref txtciudad, value); }
        }
        public string Txtocupacion
        {
            get { return txtocupacion; }
            set { SetValue(ref txtocupacion, value); }
        }
        public string Txtcorreo
        {
            get { return txtcorreo; }
            set { SetValue(ref txtcorreo, value); }
        }
        #endregion

        #region Procesos

        private async Task InsertarCliente()
        {
            var funcion = new dClientes();
            var parametros = new mClientes();
            parametros.apellidosnombre = Txtapellidosnombre;
            parametros.ciudad = Txtciudad;
            parametros.correo = Txtcorreo;
            parametros.direccion = Txtdireccion;
            parametros.dni = Txtdni;
            parametros.fotocasa = Txtfotocasa;
            parametros.ocupacion = Txtocupacion;
            parametros.telefono = Txttelefono;
            var estadofuncion = await funcion.InsertarCliente(parametros);
            if (estadofuncion == true)
            {
                UserDialogs.Instance.ShowLoading("Registering Client");
                await Task.Delay(2000);
                await DisplayAlert("Success", "Registered Customer", "Accept");
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                UserDialogs.Instance.ShowLoading("Registering Client");
                await Task.Delay(2000);
                await DisplayAlert("Error", "Client did not register", "Aceptar");
                UserDialogs.Instance.HideLoading();
            }
        }

        #endregion

        #region Comandos

        public Command cmdInsertarCliente { get; }
        #endregion

        #region Constructor
        public vmClientes()
        {
            cmdInsertarCliente = new Command(async () => await InsertarCliente());
        }
        #endregion

    }
}
