using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Connection;
using AppMovil1260061.Models;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace AppMovil1260061.Data
{
    public class dDetalleVenta
    {
        public async Task InsertarDetalleVenta(mDetalleVenta detalleVenta)
        {
            await ConexionFirebase.clientefirebase.Child("DetalleVenta")
                .PostAsync(new mDetalleVenta()
                {
                    idDetalleVenta = detalleVenta.idDetalleVenta,
                    idventa = detalleVenta.idventa,
                    idproducto = detalleVenta.idproducto,
                    cantidad = detalleVenta.cantidad,
                    descuento = detalleVenta.descuento,
                    idcliente = detalleVenta.idcliente,
                    Fecha = detalleVenta.Fecha,
                    Total = detalleVenta.Total
                });
        }
    }
}
