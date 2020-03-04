using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Uposlenici.ViewModels;
using RS1_WebApp.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace RS1_WebApp.Areas.Uposlenici.Controllers
{
    [Area("Uposlenici")]
    public class TreningController : Controller
    {
        private readonly MyContext db;
        public TreningController(MyContext context)
        {
            db = context;
        }

        public IActionResult Index(int TeretanaID)
        {
            TreningVM vm = new TreningVM()
            {
                DatumString=DateTime.Now,
                TeretanaId=TeretanaID
                
            };
            
            return View(vm);
        }

    }
}