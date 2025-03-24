using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Models;
using Firebase.Database.Query;
using AppMovil1260061.Connection;
using System.Linq;
using System.Threading.Tasks;

namespace AppMovil1260061.Data
{
    public class dClientes
    {

        public async Task<bool> InsertarCliente(mClientes client)
        {
            await ConexionFirebase.clientefirebase
                .Child("Clientes").PostAsync(new mClientes()
                {
                    apellidosnombre = client.apellidosnombre,
                    ciudad = client.ciudad,
                    correo = client.correo,
                    direccion = client.direccion,
                    dni = client.dni,
                    fotocasa = client.fotocasa,
                    ocupacion = client.ocupacion,
                    telefono = client.telefono,
                });
            return true;
        }

        public async Task<List<mClientes>> MostrarClientes()
        {
            return(await ConexionFirebase.clientefirebase
                .Child("Clientes").OnceAsync<mClientes>())
                .Select(item => new mClientes
                {
                    apellidosnombre = item.Object.apellidosnombre,
                    ciudad=item.Object.ciudad,
                    correo = item.Object.correo,
                    direccion=item.Object.direccion,
                    dni=item.Object.dni,
                    fotocasa=item.Object.fotocasa,
                    ocupacion=item.Object.ocupacion,
                    telefono=item.Object.telefono,
                    idCliente=item.Key
                }).ToList();
        }

        public async Task<List<mClientes>> BuscarClientes(string nombre)
        {
            return(await ConexionFirebase .clientefirebase
                .Child("Clientes").OnceAsync<mClientes>())
                .Select(item => new mClientes
                {
                    apellidosnombre = item.Object.apellidosnombre,
                    ciudad = item.Object.ciudad,
                    correo = item.Object.correo,
                    direccion = item.Object.direccion,
                    dni=item.Object.dni,
                    fotocasa = item.Object.fotocasa,
                    ocupacion = item.Object.ocupacion,
                    telefono = item.Object.telefono,
                    idCliente=item.Key
                }).Where(x => x.apellidosnombre.ToLower().Contains(nombre.ToLower())).ToList();
        }

    }
}
