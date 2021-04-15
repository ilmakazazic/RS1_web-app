using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Uposlenici.ViewModels;

namespace RS1_WebApp.Controllers
{
    [Area("Uposlenici")]
    public class GradController : Controller
    {
        private readonly MyContext db;

        public GradController(MyContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            GradPrikazVM vm = new GradPrikazVM()
            {
                gradovi = db.Grad.Include(b => b.Drzava).Select(x => new GradPrikazVM.Row()
                {
                    GradId = x.GradID,
                    Grad = x.Naziv,
                    Drzava = x.Drzava.Naziv,
                    PostanskiBroj = x.PostanskiBroj
                }).ToList()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Dodaj()
        {
            GradVM vm = new GradVM()
            {
                Drzava = db.Drzava.Select(x => new SelectListItem()
                {
                     Text=x.Naziv,
                     Value=x.DrzavaID.ToString()
                }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(GradVM vm)
        {
            Grad x = new Grad()
            {
                Naziv = vm.Grad,
                PostanskiBroj = vm.PostanskiBroj,
                DrzavaID = vm.DrzavaId,
            };
            db.Grad.Add(x);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Obrisi(int GradID)
        {
            Grad k = db.Grad.Find(GradID);
            if (k == null)
            {
                return Content("Grad ne postoji!");
            }
            db.Remove(k);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public int BrojDrzava()
        {
            MyContext db = new MyContext();
            List<Drzava> drzave = db.Drzava.ToList();
            int broj = drzave.Count();
            return broj;
        }
    }
}