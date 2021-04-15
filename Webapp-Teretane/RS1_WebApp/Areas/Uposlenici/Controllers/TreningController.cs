using System;
using Microsoft.AspNetCore.Mvc;
using RS1_Teretana.EF;
using RS1_WebApp.Areas.Uposlenici.ViewModels;

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