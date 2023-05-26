using IDGS902_Tema1.Models;
using IDGS902_Tema1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace IDGS902_Tema1.Controllers
{
    public class TraductorController : Controller
    {
        // GET: Traductor
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Diccionario d)
        {
            var opel = new TraductorService();
            opel.GuardarArchivos(d);
            return View();
        }
        public ActionResult Tabla()
        {
            var arch = new TraductorService();
            TempData["Palabras"] = arch.LeerArchivo();

            return RedirectToAction("Index");
        }

        public ActionResult Buscar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buscar(DiccionarioBusqueda d, string Palabra, string Idioma)
        {
            var opel = new TraductorService();
            string palabraEncontrada = opel.BuscarArchivo(Palabra.ToLower(), Idioma);

            ViewBag.PalabraEncontrada = palabraEncontrada;


            return View(d);
        }

    }
}