using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RS1_Teretana.EF;
//using RS1_WebApp.Models;
using RS1_WebApp.ViewModels;

namespace RS1_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext db;
        private readonly ILogger<HomeController> _logger;

        //public HomeController()
        //{
        //}

        public HomeController(MyContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var lk = HttpContext.GetLogiraniKorisnik();

            if (lk != null && lk.TipNalogaID == 3)
            {
                //return View("Clanovi","Home");
                return View("HomePocetna");
            }
            else if (lk != null && lk.TipNalogaID == 2)
            {
                return Redirect("/Uposlenici/Home/Index");
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
