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
using Microsoft.EntityFrameworkCore;
using RS1_Teretana.Web.Helper;
using RS1_WebApp.EntityModels;

namespace RS1_WebApp.Areas.Uposlenici.Controllers
{
    [Area("Uposlenici")]
    public class ClanarinaController : Controller
    {
        private readonly MyContext db;
        public ClanarinaController(MyContext context)
        {
            db = context;
        }

        public IActionResult Index(int TeretanaID)
        {
            KuponVM vm = new KuponVM()
            {
                TeretanaId = TeretanaID,
                Kuponi = db.PopustKupon.Where(c => c.TeretanaId == TeretanaID).Select(x => new KuponVM.Row()
                {
                    Aktivan = x.Aktivan,
                    Postotak=x.Postotak,
                    Brojac_Koristenja = x.Brojac_Koristenja,
                    Broj_Koristenja = x.Broj_Koristenja,
                    KrajDatum = x.KrajDatum.ToString("dd.MM.yyyy"),
                    KuponKod = x.KuponKod,
                    PocetakDatum = x.PocetakDatum.ToString("dd.MM.yyyy"),
                    PopustKuponId = x.PopustKuponId
                }).ToList()
            };
                                
            return View(vm);
        }

        [HttpGet]
        public IActionResult Dodaj(int TeretanaID)
        {
            KuponDodajVM vm = new KuponDodajVM()
            {
                PocetakDatum = DateTime.Now,
                Postotak = 10,
                KrajDatum = DateTime.Today.AddDays(3),
                KuponKod = Generator.KodPopusta(),
                Broj_Koristenja=1
            };

            return PartialView(vm);
        }


        [HttpPost]
        public IActionResult Dodaj(KuponDodajVM vm)
        {
            PopustKupon noviKupon = new PopustKupon()
            {
                KuponKod = vm.KuponKod,
                PocetakDatum = vm.PocetakDatum,
                KrajDatum = vm.KrajDatum,
                Aktivan = true,
                Brojac_Koristenja = 0,
                Broj_Koristenja = vm.Broj_Koristenja,
                Postotak = vm.Postotak,
                TeretanaId = vm.TeretanaID


            };

            db.PopustKupon.Add(noviKupon);
            db.SaveChanges();
            TempData["Poruka-kupon"] = "Uspjesno ste dodali novi kupon ";

            return Redirect("/Uposlenici/Clanarina?TeretanaID="+vm.TeretanaID);
        }
        public IActionResult OtkaziKupon(int PopustKuponID, int TeretanaID)
        {
            PopustKupon p = db.PopustKupon.Find(PopustKuponID);
            p.Aktivan = false;


            db.PopustKupon.Update(p);
            db.SaveChanges();

            return Redirect("/Uposlenici/Clanarina?TeretanaID=" + TeretanaID);
        }

        public int ModelTest(KuponDodajVM model)
        {
            int broj = model.Broj_Koristenja;
            return broj;

        }

        public string DodajKupon(KuponDodajVM vm)
        {
            PopustKupon noviKupon = new PopustKupon()
            {
                KuponKod = vm.KuponKod,
                PocetakDatum = vm.PocetakDatum,
                KrajDatum = vm.KrajDatum,
                Aktivan = vm.Aktivan,
                Brojac_Koristenja = 0,
                Broj_Koristenja = vm.Broj_Koristenja,
                Postotak = vm.Postotak,
                TeretanaId = vm.TeretanaID

            };

            return noviKupon.KuponKod;
        }

    }
}