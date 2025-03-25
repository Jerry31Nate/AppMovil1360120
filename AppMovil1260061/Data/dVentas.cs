using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMovil1260061.Connection;
using AppMovil1260061.Models;
using Firebase.Database.Query;

namespace AppMovil1260061.Data
{
    public class dVentas
    {
        public async Task InsertarVenta(mVentas venta)
        {
            await ConexionFirebase.clientefirebase.Child("Ventas")
                .PostAsync(new mVentas()
                {
                    idVenta = venta.idVenta,
                    idCliente = venta.idCliente,
                    TotalPago = venta.TotalPago,
                    Fecha = venta.Fecha,
                    TipoPago = venta.TipoPago,
                    idUsuario = venta.idUsuario
                });
        }

        public async Task<List<mVentas>>ListarVentas()
        {
            return (await ConexionFirebase.clientefirebase
                .Child("Ventas")
                .OnceAsync<mVentas>()).Select(item => new mVentas
                {
                    idVenta = item.Object.idVenta,
                    idCliente = item.Object.idCliente,
                    TotalPago = item.Object.TotalPago,
                    Fecha = item.Object.Fecha,
                    TipoPago = item.Object.TipoPago,
                    idUsuario = item.Object.idUsuario
                }).ToList();
        }
    }
}
