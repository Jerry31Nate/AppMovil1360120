using AppMovil1260061.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using AppMovil1260061.Connection;
using System.Linq;

namespace AppMovil1260061.Data
{
    public class dProductos
    {
        public async Task<bool> InsertarProducto(mProductos product) 
        {
            await ConexionFirebase.clientefirebase
                .Child("Productos").PostAsync(new mProductos()
                {
                    categoria = product.categoria,
                    fechavencimiento = product.fechavencimiento,
                    icono = product.icono,
                    nombre = product.nombre,
                    precio = product.precio,
                    proveedor = product.proveedor,
                    stock = product.stock
                });
            return true;

        }

        public async Task<List<mProductos>> MostrarProductos()
        {
            return (await ConexionFirebase.clientefirebase
                .Child("Productos").OnceAsync<mProductos>())
                .Select(item => new mProductos
                {
                    categoria = item.Object.categoria,
                    fechavencimiento = item.Object.fechavencimiento,
                    icono = item.Object.icono,
                    nombre = item.Object.nombre,
                    precio = item.Object.precio,
                    proveedor = item.Object.proveedor,
                    stock = item.Object.stock,
                    idproducto = item.Key
                }).ToList();
        }
    }
}
