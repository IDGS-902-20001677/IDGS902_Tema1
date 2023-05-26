using IDGS902_Tema1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IDGS902_Tema1.Services
{
    public class GuardaService
    {
        public void GuardarArchivos(Maestros maestros)
        {
            var nombre = maestros.Nombre;
            var apaterno= maestros.Apaterno;
            var amaterno= maestros.Amaterno;
            var edad= maestros.Edad;
            var email= maestros.Email;
            var datos=nombre+", "+apaterno+","+amaterno+", "+edad+", "+email+Environment.NewLine;
            var archivo=HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            File.AppendAllText(archivo, datos);
        }
    }
}