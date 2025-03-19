using AppMovil1260061.Connection;
using AppMovil1260061.Data;
using AppMovil1260061.Models;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppMovil1260061.ViewModels
{
    public class vmMenuPrincipal : BaseViewModel
    {
        #region Variables
        string lblNombreCompleto;
        string lblEmail;
        string lblTelefono;
        string lblUserName;
        string lblImagen;
        #endregion

        #region Propiedades

        private ObservableCollection<mProductos> _listaproductos;
        public ObservableCollection<mProductos> Listaproductos
        {
            get { return _listaproductos; }
            set { SetValue(ref _listaproductos, value); }
        }

        public string LblImagen
        {
            get { return lblImagen; }
            set { SetValue(ref lblImagen, value); }
        }
        public string LblNombreCompleto
        {
            get { return lblNombreCompleto; }
            set { SetValue(ref lblNombreCompleto, value); }
        }
        public string LblEmail
        {
            get { return lblEmail; }
            set { SetValue(ref lblEmail, value); }
        }
        public string LblTelefono
        {
            get { return lblTelefono; }
            set { SetValue(ref lblTelefono, value); }
        }
        public string LblUserName
        {
            get { return lblUserName; }
            set { SetValue(ref lblUserName, value); }
        }
        #endregion

        #region Procesos

        private async Task ListarProductos()
        {
            var funcion = new dProductos();
            var lista = await funcion.MostrarProductos();

            // Filtrar productos válidos (excluyendo el nodo "modelo")
            var productosFiltrados = lista.Where(p => p.nombre != "-" && p.nombre != null).ToList();

            // Actualizar la colección en el hilo principal para que se refleje en la UI
            Device.BeginInvokeOnMainThread(() =>
            {
                Listaproductos = new ObservableCollection<mProductos>(productosFiltrados);
            });
        }

        public async Task verDatosUsuario()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConexionFirebase.Apykey));
            var guardardatosuser = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("token", ""));
            var refreshContent = await authProvider.RefreshAuthAsync(guardardatosuser);
            Preferences.Set("token", JsonConvert.SerializeObject(refreshContent));
            string email = guardardatosuser.User.Email;

            var funcion = new dUsuarios();
            var datos = new mUsuarios { Email = email };

            var lista = await funcion.MostrarDatosUsuario(datos);
            foreach (var item in lista)
            {
                LblNombreCompleto = item.FullName;
                LblEmail = item.Email;
                LblTelefono = item.Phone;
                LblUserName = item.UserName;
                LblImagen = item.Image;
                break;
            }
        }
        #endregion

        #region Constructor
        public vmMenuPrincipal()
        {
            Listaproductos = new ObservableCollection<mProductos>();
            verDatosUsuario();
            ListarProductos(); // Carga la lista inicial

            // Suscribirse al mensaje de inserción de producto
            MessagingCenter.Subscribe<vmProductos, mProductos>(this, "ProductoInsertado", async (sender, producto) =>
            {
                // Recargar la lista completa o agregar directamente el nuevo producto
                await ListarProductos();
                // O también se puede usar:
                // Device.BeginInvokeOnMainThread(() => Listaproductos.Add(producto));
            });
        }
        #endregion
    }
}
