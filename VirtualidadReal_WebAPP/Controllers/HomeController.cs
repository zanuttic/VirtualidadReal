using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualidadReal_WebAPP.Models;
using VirtualidadReal_WebAPP.Services;

namespace VirtualidadReal_WebAPP.Controllers
{
    public class HomeController : Controller
    {
        public IPaisesEnMomorias Repositorio { get; }
        public HomeController(IPaisesEnMomorias repositorio)
        {
            Repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
