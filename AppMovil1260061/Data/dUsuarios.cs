using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Connection;
using AppMovil1260061.Models;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace AppMovil1260061.Data
{
    public class dUsuarios
    {
        public async Task<bool> RegistrarUsuario(mUsuarios usuario)
        {
            
                await ConexionFirebase.clientefirebase
                    .Child("Usuarios")
                    .PostAsync(new mUsuarios()
                    {
                        FullName = usuario.FullName,
                        Email = usuario.Email,
                        Phone = usuario.Phone,
                        UserName = usuario.UserName,
                        Image = usuario.Image
                    });
                return true;         
        }
        public async Task<List<mUsuarios>> MostrarDatosUsuario(mUsuarios parametrospedir)
        {
            return (await ConexionFirebase.clientefirebase
                .Child("Usuarios").OnceAsync<mUsuarios>()).
                Where(a => a.Object.Email == parametrospedir.Email).Select(item => new mUsuarios
                {
                    FullName=item.Object.FullName,
                    Email=item.Object.Email,
                    Phone = item.Object.Phone,
                    UserName = item.Object.UserName,
                    Image = item.Object.Image,
                    idusuario = item.Key
                }).ToList();
        }
    }
}
