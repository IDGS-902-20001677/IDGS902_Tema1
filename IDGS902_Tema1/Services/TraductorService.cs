using IDGS902_Tema1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IDGS902_Tema1.Services
{
    public class TraductorService
    {
        public void GuardarArchivos(Diccionario d)
        {
            var p_espaniol = d.PalabraEspaniol;
            var p_ingles = d.PalabraIngles;
            var datos = p_espaniol + "," + p_ingles + Environment.NewLine;
            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/diccionario.txt");
            File.AppendAllText(archivo, datos);
        }
        public Array LeerArchivo()
        {
            Array palabras = null;
            var datos = HttpContext.Current.Server.MapPath("~/App_Data/diccionario.txt");
            if (File.Exists(datos))
            {
                palabras = File.ReadAllLines(datos);
            }
            return palabras;
        }

        public string BuscarArchivo(string Palabra, string Idioma)
        {
            var datos = HttpContext.Current.Server.MapPath("~/App_Data/diccionario.txt");
            if (System.IO.File.Exists(datos))
            {
                var lineas = System.IO.File.ReadAllLines(datos);
                string palabraEncontrada = "";

                foreach (var linea in lineas)
                {
                    var palabras = linea.Split(',');

                    if (Idioma == "Ingles" && Palabra.ToLower().Equals(palabras[1]))
                    {
                        palabraEncontrada = palabras[0];

                    }
                    else if (Idioma == "Espanol" && Palabra.ToLower().Equals(palabras[0]))
                    {
                        palabraEncontrada = palabras[1];

                    }
                }
                if (palabraEncontrada == "")
                {
                    palabraEncontrada = "La palabra no existe en el diccionario";
                }

                return palabraEncontrada;

            }

            return "no existe esta palabra en el diccionario"; 
        }
    }
}