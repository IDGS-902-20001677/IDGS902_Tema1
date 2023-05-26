using IDGS902_Tema1.Models;
using IDGS902_Tema1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS902_Tema1.Controllers
{
    public class TriangulosController : Controller
    {
        // GET: Triangulos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Triangulo t)
        {
            var triangulosService = new TriangulosService();
            triangulosService.Calcular(t);
            return View(t);
        }
    }
}