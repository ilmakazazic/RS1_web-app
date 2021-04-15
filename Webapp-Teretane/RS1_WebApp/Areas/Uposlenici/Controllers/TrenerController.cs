using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Uposlenici.ViewModels;
using RS1_WebApp.EntityModels;

namespace RS1_WebApp.Controllers
{
    [Area("Uposlenici")]
    public class TrenerController : Controller
    {
        private readonly MyContext db;
        public TrenerController(MyContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            TrenerVM vm = new TrenerVM()
            {
                treneri = db.Trener.Select(x => new TrenerVM.Row()
                {
                    datumRodjenja = x.DatumRodjenja.ToString("dd.MM.yyyy"),
                    ImePrezime = x.Ime + " " + x.Prezime,
                    TrenerId = x.TrenerID,
                    Email = x.Email,
                    Licenca = db.TrenerLicenca.Where(e => e.TrenerId == x.TrenerID).Include(b=>b.Licenca).ToList(),
                    DatumPolaganja = db.TrenerLicenca.Where(e => e.TrenerId == x.TrenerID).Select(v => v.DatumPolaganja.ToString("dd.MM.yyyy")).FirstOrDefault(),
                    DatumIsteka = db.TrenerLicenca.Where(e => e.TrenerId == x.TrenerID).Select(v => v.DatumIsteka.ToString("dd.MM.yyyy")).FirstOrDefault(),
                }).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Dodaj()
        {
            TrenerDodajUrediVM vm = new TrenerDodajUrediVM()
            {
                Licenca = db.Licenca.Select(x => new SelectListItem()
                {
                    Text = x.Tip,
                    Value = x.LicencaID.ToString()
                }).ToList()
            };
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(TrenerDodajUrediVM vm)
        {
            List<KorisnickiNalog> k = db.KorisnickiNalog.ToList();
            foreach(var c in k)
            {
                if(c.KorisnickoIme==vm.KorisnickoIme)
                {
                    TempData["poruka-error"] = "Korisnicko ime već postoji";
                    return Redirect("/Uposlenici/Trener");
                }
            }

            KorisnickiNalog noviKorisnik = new KorisnickiNalog()
            {
                KorisnickoIme = vm.KorisnickoIme,
                Lozinka = vm.Password,
                TipNalogaID = 2
            };

            db.KorisnickiNalog.Add(noviKorisnik);
            db.SaveChanges();

            Trener noviTrener = new Trener()
            {
                Email = vm.Email,
                Spol = vm.Spol,
                Ime = vm.Ime,
                Prezime = vm.Prezime,
                DatumRodjenja = vm.datumRodjenja,
                 NalogID=noviKorisnik.Id
            };

            db.Trener.Add(noviTrener);
            db.SaveChanges();

            if(vm.LicencaId!=0)
            {
                TrenerLicenca novaLicencaTrenera = new TrenerLicenca()
                {
                    LicencaId = vm.LicencaId,
                    DatumIsteka = vm.DatumIsteka,
                    DatumPolaganja = vm.DatumPolaganja,
                    TrenerId = noviTrener.TrenerID

                };
                db.TrenerLicenca.Add(novaLicencaTrenera);
                db.SaveChanges();

            }
            return Redirect("/Uposlenici/Trener");
        }

        [HttpGet]
        public IActionResult Uredi(int TrenerID)
        {
            Trener t = db.Trener.Find(TrenerID);
            TrenerDodajUrediVM vm = new TrenerDodajUrediVM()
            {
                datumRodjenja = t.DatumRodjenja,
                Email = t.Email,
                Ime = t.Ime,
                Prezime = t.Prezime,
                Spol = t.Spol,
                TrenerId=t.TrenerID

            };
            return PartialView(vm);
        }

        [HttpGet]
        public IActionResult UrediLicencu(int TrenerLicencaID)
        {
            TrenerLicenca l = db.TrenerLicenca.Where(n => n.TrenerLicencaId == TrenerLicencaID).FirstOrDefault();
            TrenerDodajUrediVM vm = new TrenerDodajUrediVM()
            {
                Licenca = db.Licenca.Select(x => new SelectListItem()
                {
                    Text = x.Tip,
                    Value = x.LicencaID.ToString()
                }).ToList(),
                LicencaId = l.LicencaId,
                DatumIsteka = l.DatumIsteka,
                DatumPolaganja = l.DatumPolaganja,
                TrenerId=l.TrenerId
            };
            return PartialView(vm);
        }

        [HttpGet]
        public IActionResult DodajLicencuTrener(int TrenerID)
        {
            TrenerDodajLicencuTrenerVM vm = new TrenerDodajLicencuTrenerVM()
            {
                Licenca = db.Licenca.Select(x => new SelectListItem()
                {
                    Value = x.LicencaID.ToString(),
                    Text=x.Tip
                }).ToList(),
                 TrenerId=TrenerID
            };
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult DodajLicencuTrener(TrenerDodajLicencuTrenerVM vm)
        {
            List<TrenerLicenca> l = db.TrenerLicenca.Where(n => n.TrenerId == vm.TrenerId).ToList();

            foreach (var x in l)
            {
                if (x.LicencaId == vm.LicencaId)
                {
                    x.DatumPolaganja = vm.DatumPolaganja;
                    x.DatumIsteka = vm.DatumIsteka;
                    db.TrenerLicenca.Update(x);
                    db.SaveChanges();
                    return Redirect("/Uposlenici/Trener");
                }

            }
            TrenerLicenca novaLicencaTrenera = new TrenerLicenca()
            {
                LicencaId = vm.LicencaId,
                DatumIsteka = vm.DatumIsteka,
                DatumPolaganja = vm.DatumPolaganja,
                TrenerId = vm.TrenerId

            };
            db.TrenerLicenca.Add(novaLicencaTrenera);
            db.SaveChanges();
            return Redirect("/Uposlenici/Trener");
        }




        [HttpPost]
        public IActionResult Uredi(TrenerDodajUrediVM vm)
        {
            Trener t = db.Trener.Find(vm.TrenerId);
            var l = db.TrenerLicenca.Where(n => n.TrenerId == vm.TrenerId).FirstOrDefault();

            t.Email = vm.Email;
            t.Spol = vm.Spol;
            t.Ime = vm.Ime;
            t.Prezime = vm.Prezime;
            t.DatumRodjenja = vm.datumRodjenja;

            db.Trener.Update(t);
            db.SaveChanges();
            return Redirect("/Uposlenici/Trener");
        }

        [HttpPost]
        public IActionResult UrediLicencu(TrenerDodajUrediVM vm)
        {
            List<TrenerLicenca> l = db.TrenerLicenca.Where(n => n.TrenerId == vm.TrenerId).ToList();

            foreach(var x in l)
            {
                if (x.LicencaId == vm.LicencaId)
                {
                    x.DatumPolaganja = vm.DatumPolaganja;
                    x.DatumIsteka = vm.DatumIsteka;
                    db.TrenerLicenca.Update(x);
                    db.SaveChanges();
                    return Redirect("/Uposlenici/Trener");
                }
            }
            TrenerLicenca novaLicencaTrenera = new TrenerLicenca()
            {
                LicencaId = vm.LicencaId,
                DatumIsteka = vm.DatumIsteka,
                DatumPolaganja = vm.DatumPolaganja,
                TrenerId = vm.TrenerId

            };
            db.TrenerLicenca.Add(novaLicencaTrenera);
            db.SaveChanges();
            return Redirect("/Uposlenici/Trener");
        }

        [HttpGet]
        public IActionResult DodajLicencu()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult DodajLicencu(TrenerLicencaVM vm)
        {
            List<Licenca> c = db.Licenca.Where(l => l.Tip == vm.Naziv).ToList();
            if(c.Count()==0)
            {
                Licenca novaLicenca = new Licenca() { Tip = vm.Naziv };
                db.Licenca.Add(novaLicenca);
                db.SaveChanges();
            }
            return Redirect("/Uposlenici/Trener");
        }

        public IActionResult ObrisiLicencu(int TrenerLicencaID)
        {
            TrenerLicenca l = db.TrenerLicenca.Find(TrenerLicencaID);

            if (l == null)
            {
                TempData["poruka-error"] = "Trener ne postoji!";
                return Redirect("/Uposlenici/Trener");
            }
            db.TrenerLicenca.Remove(l);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Obrisi(int TrenerID)
        {
            Trener t = db.Trener.Find(TrenerID);
            KorisnickiNalog k = db.KorisnickiNalog.Find(t.NalogID);
            var l = db.TrenerLicenca.Where(n => n.TrenerId == TrenerID).ToList();

            foreach (var x in l)
            {
                if (x != null)
                {
                    db.TrenerLicenca.Remove(x);
                }
            }
            if (k != null)
            {
                db.KorisnickiNalog.Remove(k);
            }

            db.Trener.Remove(t);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}