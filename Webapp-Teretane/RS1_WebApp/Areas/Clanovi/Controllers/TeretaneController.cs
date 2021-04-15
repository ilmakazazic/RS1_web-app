using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Clanovi.ViewModels;
using RS1_WebApp.EntityModels;
using RS1_WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS1_WebApp.Web.Helper;

namespace RS1_WebApp.Areas.Clanovi.Controllers
{
    [Area("Clanovi")]
    public class TeretaneController : Controller
    {
        private readonly MyContext db;

        public TeretaneController(MyContext context)
        {
            db = context;
        }

        public IActionResult PrikaziTeretane()
        {
            var lk = HttpContext.GetLogiraniKorisnik(); 
            var clanID = db.Clan.Where(x => x.NalogID == lk.Id).FirstOrDefault().ClanID;
            TeretanePRikazVM vm = new TeretanePRikazVM();

            vm.ClanID = clanID;
            vm.mojeTeretane = db.ClanTeretana.Where(c => c.ClanID == clanID).Select(s => new TeretanePRikazVM.Row2
            {
                teretanaID = s.TeretanaID
            }).ToList();
            vm.teretane = db.Teretana.Select(s => new TeretanePRikazVM.Row
            {
                TeretanaID = s.TeretanaID,
                Naziv = s.Naziv,
                Adresa = s.Adresa,
                Grad = s.Grad.Naziv,
                RadnoVrijeme = s.PocetakRadnoVrijeme.ToString("hh\\:mm") + " - " + s.KrajRadnoVrijeme.ToString("hh\\:mm")
            }).ToList();

            foreach (var r in vm.teretane) {
                foreach (var t in vm.mojeTeretane)
                    {
                    if (t.teretanaID == r.TeretanaID)
                        {
                            r.Disabled = true;
                        }
                    }
            }
             
            
            return View(vm);
           
        }
        public IActionResult Komentar(int teretanaId,int clanID)
        {
            KomentarVM vm = new KomentarVM()
            {

                TeretanaID = teretanaId,
                Teretana = db.Teretana.Where(t => t.TeretanaID == teretanaId).Select(s => s.Naziv).FirstOrDefault(),
                ClanID = clanID
            };
            return View(vm);
        }
        public IActionResult Uclani(int clanID, int teretanaID)
        {
            UclanjivanjeVM vm = new UclanjivanjeVM()
            {
                ClanID = clanID,
                TeretanaID = teretanaID,
                Teretana = db.Teretana.Where(w => w.TeretanaID == teretanaID).Select(s => s.Naziv).FirstOrDefault(),
                ImePrezime = db.Clan.Where(w => w.ClanID == clanID).Select(s => s.Ime + " " + s.Prezime).FirstOrDefault(),
                Adresa = db.Clan.Where(w => w.ClanID == clanID).Select(s => s.Adresa).FirstOrDefault(),
                email = db.Clan.Where(w => w.ClanID == clanID).Select(s => s.Email).FirstOrDefault(),
                clanarine=db.TipClanarine.Select(s=>new SelectListItem
                {
                    Text=s.Tip,
                    Value=s.TipClanarineID.ToString()
                }).ToList()

            };
            
            return View(vm);

           
        }
        public IActionResult UclaniSnimi(UclanjivanjeVM model)
        {
            if (!ModelState.IsValid)
            {
                model.clanarine = db.TipClanarine.Select(s => new SelectListItem
                {
                    Text = s.Tip,
                    Value = s.TipClanarineID.ToString()
                }).ToList();
                return View("Uclani", model);

                //return View("Uclani", new { clanID = model.ClanID, teretanaID = model.TeretanaID });
            }


            ClanTeretana novi = new ClanTeretana()
            {
                ClanID = model.ClanID,
                TeretanaID = model.TeretanaID,
                DatumUclanjivanja = DateTime.Now,
                
            };
            db.ClanTeretana.Add(novi);

            db.SaveChanges();
            PlacanjeClanarine uplata = new PlacanjeClanarine()
            {
                ClanID = model.ClanID,
                TipClanarineID = model.TipClanarineID,
                Popust = 0.15,
                DatumUplate = DateTime.Now,
                BrojRacuna = model.BrojKartice,
                TeretanaID=model.TeretanaID,
                KorisnikID = db.Korisnik.Where(w=>w.TeretanaID==model.TeretanaID).Select(s=>s.KorisnikID).FirstOrDefault(),
                UkupanIznos=db.TipClanarine.Where(w=>w.TipClanarineID==model.TipClanarineID).Select(s=>s.Cijena-0.15*s.Cijena).FirstOrDefault()
            };
            db.PlacanjeClanarine.Add(uplata);
            db.SaveChanges();
            return RedirectToAction("Prikaz", "Profil");
      
        }
    
    }
}

