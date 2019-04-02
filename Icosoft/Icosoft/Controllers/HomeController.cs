using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Icosoft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Kartun es una empresa que cuenta con un equipo de sólidos profesionales, con amplios conocimientos técnicos en arquitectura de interiores. Somos capaces de dar respuesta a tus más exigentes necesidades e inquietudes, en la rehabilitación y decoración de tu vivienda, oficina o local";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}