using Microsoft.AspNetCore.Mvc;
using RS1_Teretana.EF;
using RS1_WebApp.Areas.Clanovi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;
using RS1_Teretana.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_WebApp.Web.Helper;

namespace RS1_WebApp.Areas.Clanovi.Controllers
{
    [Area("Clanovi")]

    public class ClanarinaController : Controller
    {
        
        public IActionResult Index()
        {
            MyContext db = new MyContext();
            var lk = HttpContext.GetLogiraniKorisnik(); 
            var clanID = db.Clan.Where(x => x.NalogID == lk.Id).FirstOrDefault().ClanID;
            PlatiClanarinuVM vm = new PlatiClanarinuVM()
            {
                ClanID=clanID,
                ImeP=db.Clan.Where(w=>w.ClanID==clanID).Select(s=>s.Ime+" "+s.Prezime).FirstOrDefault(),
                email= db.Clan.Where(w => w.ClanID == clanID).Select(s => s.Email).FirstOrDefault(),
                Clanarine=db.TipClanarine.Select(s=>new SelectListItem { 
                Text=s.Tip,
                Value=s.TipClanarineID.ToString()
                }).ToList(),
                teretane=db.ClanTeretana.Where(c=>c.ClanID==clanID).Select(s=>new SelectListItem
                {
                    Text=s.Teretana.Naziv,
                    Value=s.TeretanaID.ToString()
                }).ToList()
            };
            ViewData["tipoviclanarine-kljuc"] = db.TipClanarine.ToList();
            return View("Plati",vm);
        }
        public void Proba()
        {
            
        }
        public IActionResult PlatiSnimi(PlatiClanarinuVM model)
        {
            MyContext db = new MyContext();

            if (!ModelState.IsValid)
            {
                model.Clanarine = db.TipClanarine.Select(s => new SelectListItem
                {
                    Text = s.Tip,
                    Value = s.TipClanarineID.ToString()
                }).ToList();
                model.teretane = db.ClanTeretana.Where(c => c.ClanID == model.ClanID).Select(s => new SelectListItem
                {
                    Text = s.Teretana.Naziv,
                    Value = s.TeretanaID.ToString()
                }).ToList();
                return View("Plati", model);
            }


          
            PlacanjeClanarine uplata = new PlacanjeClanarine
            {
                ClanID=model.ClanID,
                TipClanarineID=model.TipClanarineID,
               
                KorisnikID=db.Clan.Where(w=>w.ClanID==model.ClanID).Select(s=>s.NalogID).FirstOrDefault(),
                DatumUplate=DateTime.Now,
                BrojRacuna=model.BrojKartice,
                Popust=0,
                UkupanIznos=db.TipClanarine.Where(t=>t.TipClanarineID==model.TipClanarineID).Select(s=>s.Cijena).FirstOrDefault(),
                TeretanaID=model.TeretanaID
            };
            db.PlacanjeClanarine.Add(uplata);
            db.SaveChanges();

            Clan nadji = db.Clan.Find(model.ClanID);
            nadji.Aktivan = true;
            db.SaveChanges();
            return RedirectToAction("Prikaz", "Profil");
        }
        public int BrojTipova()
        {
            MyContext db = new MyContext();
            List<TipClanarine> tipovi = db.TipClanarine.ToList();
            int broj = tipovi.Count();
            return broj;
        }

    }
}





   