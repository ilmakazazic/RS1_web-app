using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Clanovi.ViewModels;
using RS1_WebApp.EntityModels;
using RS1_WebApp.ViewModels;
using RS1_WebApp.Web.Helper;


namespace RS1_WebApp.Areas.Clanovi.Controllers
{
    [Area("Clanovi")]
    public class ProfilController : Controller
    {
        //private readonly MyContext db;

        //public ProfilController(MyContext context)
        //{
        //    db = context;
        //}
        public IActionResult Prikaz()
        {
            MyContext db = new MyContext();
            var lk = HttpContext.GetLogiraniKorisnik(); 
            var clanID = db.Clan.Where(x => x.NalogID == lk.Id).FirstOrDefault().ClanID;
            ProfilVM vm = new ProfilVM()
            {
                ClanID = clanID,
                Naziv = db.Clan.Where(c => c.ClanID == clanID).Select(s => s.Ime + " " + s.Prezime).FirstOrDefault(),
                KorisnickoIme = db.Clan.Where(c => c.ClanID == clanID).Select(s => s.KorisnickiNalog.KorisnickoIme).FirstOrDefault(),
                Lozinka = db.Clan.Where(c => c.ClanID == clanID).Select(s => s.KorisnickiNalog.Lozinka).FirstOrDefault(),
Teretane =db.ClanTeretana.Where(c=>c.ClanID == clanID).Select(s=>new ProfilVM.Row
{
    TeretanaID=s.TeretanaID,
    Naziv=s.Teretana.Naziv,
    Komentar= db.KomentarTeretane.Where(c => c.ClanID == clanID && c.TeretanaID==s.TeretanaID).Select(k => k.Komentar).FirstOrDefault()
}).ToList(),
Treninzi=db.treninziDetalji.Where(c=>c.ClanID== clanID).Select(s=>new ProfilVM.Row2
{
  TreninziDetaljiID=s.TreninziDetaljiID  ,
Teretana=db.Treninzi.Where(w=>w.TreninziID==s.TreninziID).Select(s=>s.Teretana.Naziv).FirstOrDefault(),
Otkazan=s.Otkazan,
DatumVrijeme=s.Treninzi.DatumOdrzavanja.ToString("dd.MM.yyyy")+"  ("+s.Treninzi.PocetakTreninga+"-"+s.Treninzi.KrajTreninga+")"
}).ToList(),
                clanarine = db.PlacanjeClanarine.Where(w => w.ClanID == clanID).Select(s => new ProfilVM.Row3
                {
                    Teretana = s.Teretana.Naziv,
                    Datum=s.DatumUplate.ToString("dd.MM.yyyy"),
                    Popust=s.Popust,
                    TipClanarine=s.TipClanarine.Tip,
                    Ukupno=s.UkupanIznos

                }).ToList()

            };
            return View(vm);
        }
        public IActionResult UrediProfil(ProfilVM model)
        {
            MyContext db = new MyContext();
            UrediProfilVM vm = new UrediProfilVM()
            {
                ClanID=model.ClanID,
                Email=db.Clan.Where(w=>w.ClanID==model.ClanID).Select(s=>s.Email).FirstOrDefault(),
                KorisnickoIme=model.KorisnickoIme,
                Lozinka=model.Lozinka
            };
            return View(vm);
        }
        public IActionResult UrediSnimi(UrediProfilVM model)
        {
            MyContext db = new MyContext();
            if (!ModelState.IsValid)
            {

                return View("UrediProfil", model);
            }
            Clan uredi = db.Clan.Find(model.ClanID);
            KorisnickiNalog uredjivanje = db.KorisnickiNalog.Find(uredi.NalogID);
            uredjivanje.KorisnickoIme = model.KorisnickoIme;
            uredjivanje.Lozinka = model.Lozinka;
           uredi.Email = model.Email;
            db.SaveChanges();
            return RedirectToAction("Prikaz");

        }

        public int UrediSnimiTest(UrediProfilVM model)
        {
            MyContext db = new MyContext();
            Clan uredi = db.Clan.Find(model.ClanID);
            KorisnickiNalog uredjivanje = db.KorisnickiNalog.Find(uredi.NalogID);
            uredjivanje.Lozinka = model.Lozinka;
            uredi.Email = model.Email;
            db.SaveChanges();
            int clan = model.ClanID;
            return clan;

        }
        public IActionResult RezervisiTrening(int clanID,int teretanaID)
        {
            MyContext db = new MyContext();
            RezervacijaVM vm = new RezervacijaVM()
            {
                ClanID = clanID,
                TeretanaID = teretanaID,
                Teretana=db.Teretana.Where(w=>w.TeretanaID==teretanaID).Select(s=>s.Naziv).FirstOrDefault(),
                treninzi = db.Treninzi.Where(w => w.TeretanaID == teretanaID).Select(s => new SelectListItem
                {
                    Text = s.DatumOdrzavanja.ToString("dd.MM.yyyy")+"  ("+s.PocetakTreninga+"-" +s.KrajTreninga+")",
                    Value = s.TreninziID.ToString()
                }).ToList()
            };
            return View(vm);
        }
        public IActionResult RezervisiSnimi(RezervacijaVM model)
        {
            MyContext db = new MyContext();
            Treninzi provjeraDostupnosti = db.Treninzi.Where(c => c.TreninziID == model.TreningID).FirstOrDefault();
            var BrojTrenutnihRezrevacija = db.treninziDetalji.Where(c => c.TreninziID == model.TreningID && c.Otkazan == false).Count();
            if (BrojTrenutnihRezrevacija >=provjeraDostupnosti.BrojRezervacija)
            {
                TreningZahtjev noviZahtjev = new TreningZahtjev()
                {
                    ClanId = model.ClanID,
                    TreninziId = model.TreningID,
                    Odobren = false
                };
                db.TreningZahtjev.Add(noviZahtjev); 
                db.SaveChanges();
                return RedirectToAction("Prikaz");

            }
            TreninziDetalji novi = new TreninziDetalji
            {
                ClanID = model.ClanID,
                TreninziID = model.TreningID,
                Otkazan = false
            };
            db.treninziDetalji.Add(novi);
            db.SaveChanges();
            return RedirectToAction("Prikaz");
            
        }
        public IActionResult OtkaziTrening(int treningID)
        {
            MyContext db = new MyContext();
            TreninziDetalji trazi = db.treninziDetalji.Find(treningID);
            trazi.Otkazan = true;
            db.SaveChanges();

            return RedirectToAction("Prikaz");
        }
        public IActionResult DodajKomentar(int clanID,string Komentar,int teretanaID)
        {
            MyContext db = new MyContext();
            KomentarTeretane novi = new KomentarTeretane()
            {
                ClanID = clanID,
                TeretanaID = teretanaID,
                Komentar = Komentar
            };
            db.KomentarTeretane.Add(novi);
            db.SaveChanges();

            return RedirectToAction("Prikaz");
        }
        public IActionResult Ocijeni(int clanID, int ocjena, int teretanaID)
        {
            MyContext db = new MyContext();
            OcjenaTeretane nova = new OcjenaTeretane()
            {
                ClanID = clanID,
                TeretanaID = teretanaID,
                Ocjena = ocjena
            };
            db.OcjenaTeretane.Add(nova);
            db.SaveChanges();

            return RedirectToAction("Prikaz");
        }
        public int OcijeniTest(int clanID, int ocjena, int teretanaID)
        {
            MyContext db = new MyContext();
            OcjenaTeretane nova = new OcjenaTeretane()
            {
                ClanID = clanID,
                TeretanaID = teretanaID,
                Ocjena = ocjena
            };
            db.OcjenaTeretane.Add(nova);
            db.SaveChanges();

            int Ocjena = ocjena;
            return Ocjena;
        }

    }
}

