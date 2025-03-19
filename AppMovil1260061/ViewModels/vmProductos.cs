using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Models;
using AppMovil1260061.Data;
using AppMovil1260061.Connection;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Firebase.Auth;
using Xamarin.Forms;

namespace AppMovil1260061.ViewModels
{
    public class vmProductos : BaseViewModel
    {
        #region Variables
        public string txtnombre;
        public string txtfechavencimiento;
        public string txtcategoria;
        public string txtprecio;
        public string txticono;
        public string txtproveedor;
        public string txtstock;
        #endregion

        #region Propiedades
        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre, value); }
        }
        public string Txtfechavencimiento
        {
            get { return txtfechavencimiento; }
            set { SetValue(ref txtfechavencimiento, value); }
        }
        public string Txtcategoria
        {
            get { return txtcategoria; }
            set { SetValue(ref txtcategoria, value); }
        }
        public string Txtprecio
        {
            get { return txtprecio; }
            set { SetValue(ref txtprecio, value); }
        }
        public string Txticono
        {
            get { return txticono; }
            set { SetValue(ref txticono, value); }
        }
        public string Txtproveedor
        {
            get { return txtproveedor; }
            set { SetValue(ref txtproveedor, value); }
        }
        public string Txtstock
        {
            get { return txtstock; }
            set { SetValue(ref txtstock, value); }
        }
        #endregion

        #region Procesos

        // Declaración del evento para notificar la inserción del producto
        public event Action<mProductos> OnProductoInsertado;

        private async Task InsertarProducto()
        {
            var funcion = new dProductos();
            var parametro = new mProductos
            {
                nombre = Txtnombre,
                fechavencimiento = Txtfechavencimiento,
                categoria = Txtcategoria,
                precio = Txtprecio,
                icono = Txticono,
                proveedor = Txtproveedor,
                stock = Txtstock
            };

            var estadofuncion = await funcion.InsertarProducto(parametro);
            if (estadofuncion)
            {
                UserDialogs.Instance.ShowLoading("Registering Product");
                await Task.Delay(2000);
                await DisplayAlert("Success", "Registered Product", "Accept");
                UserDialogs.Instance.HideLoading();

                // Ejecuta el evento en el hilo principal para actualizar la vista
                Device.BeginInvokeOnMainThread(() =>
                {
                    MessagingCenter.Send(this, "ProductoInsertado", parametro);
                });
            }
            else
            {
                UserDialogs.Instance.ShowLoading("Registering Product");
                await Task.Delay(2000);
                await DisplayAlert("Error", "The product was not registered", "Close");
                UserDialogs.Instance.HideLoading();
            }
        }
        #endregion

        #region Comandos
        public Command cmdInsertarProducto { get; }
        #endregion

        #region Constructor
        public vmProductos()
        {
            // Inicialización del comando que ejecuta InsertarProducto
            cmdInsertarProducto = new Command(async () => await InsertarProducto());
        }
        #endregion
    }
}
