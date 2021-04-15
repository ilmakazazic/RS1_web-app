using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Clanovi.ViewModels;
using RS1_WebApp.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS1_WebApp.Web.Helper;

namespace RS1_WebApp.Areas.Clanovi.Controllers
{
    [Area("Clanovi")]
    public class ObavijestiController : Controller
    {
        //private readonly MyContext db;

        //public ObavijestiController(MyContext context)
        //{
        //    db = context;
        //}

        ////public ObavijestiController()
        ////{
        ////}

        public IActionResult PrikaziObavijesti()
        {
            MyContext db = new MyContext();
            var lk = HttpContext.GetLogiraniKorisnik();
            var clanID = db.Clan.Where(x => x.NalogID == lk.Id).FirstOrDefault().ClanID;
            ObavijestVM vm = new ObavijestVM()
            {
                rows = db.Obavijest.Select(s => new ObavijestVM.Row
                {
                    ObavijestID = s.ObavijestID,
                    Sadrzaj = s.Sadrzaj,
                    DatumObjave = s.DatumObjave,
                    Naziv = s.Naziv,
                    Teretana = s.Teretana.Naziv,
                    procitana = db.ClanObavijest.Where(o => o.ObavijestID == s.ObavijestID && o.ClanID == clanID).Select(p => p.Procitana).FirstOrDefault()
                }).ToList()
            };
            return View("Pregled", vm);
        }

        public IActionResult Oznaci(int obavijestId)
        {
            MyContext db = new MyContext();
            var lk = HttpContext.GetLogiraniKorisnik();
            var clanID = db.Clan.Where(x => x.NalogID == lk.Id).FirstOrDefault().ClanID;
            ClanObavijest nova = new ClanObavijest
            {
                ClanID = clanID,
                ObavijestID = obavijestId,
                Procitana = true
            };
            db.ClanObavijest.Add(nova);
            db.SaveChanges();


            return RedirectToAction("PrikaziObavijesti");
        }
        public int BrojObavijesti()
        {
            MyContext db = new MyContext();
            List<Obavijest> obavijesti = db.Obavijest.ToList();
            int broj = obavijesti.Count();
            return broj;
        }
      

    }
}
