using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using RS1_WebApp.Models;
using RS1_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Teretana.EF;

namespace RS1_WebApp.Areas.Clanovi.Controllers
{
    [Area("Clanovi")]
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult HomePocetna()
        {
           
            return View();
        }


    }
}