using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil1260061.Models
{
    public class mDetalleVenta
    {
        public string idDetalleVenta { get; set; }
        public string idventa { get; set; }
        public string idproducto { get; set; }
        public string cantidad { get; set; }

        public string descuento { get; set; }
        public string Fecha { get; set; }
        public string Total { get; set; }
        public string idcliente { get; set; }
        
        //agregar campos de otras tablas

        public string nombre { get; set; }
        public string icono { get; set; }
        public string apellidosnombre { get; set; }
        public string precio { get; set; }

    }
}
