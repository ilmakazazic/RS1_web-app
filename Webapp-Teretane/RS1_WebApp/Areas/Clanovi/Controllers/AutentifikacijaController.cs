using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using eUniverzitet.Web.ViewModels;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Clanovi.ViewModels;
using RS1_WebApp.EntityModels;

namespace eUniverzitet.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly MyContext db;

        public AutentifikacijaController(MyContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var logiraniKorisnik = new LoginVM()
            {
                usersList = db.KorisnickiNalog.Select(x => new SelectListItem
                {
                    Text = x.KorisnickoIme,
                    Value = x.KorisnickoIme
                }).ToList()
            };
            return View();
        }

        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = db.KorisnickiNalog
                .SingleOrDefault(x => x.KorisnickoIme == input.username);
            string ispravnasifra = db.KorisnickiNalog.Where(w => w.KorisnickoIme == input.username).Select(s => s.Lozinka).FirstOrDefault();

            if (korisnik == null || ispravnasifra!=input.lozinka )
            {
                TempData["error_poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnik);

            if(korisnik.TipNalogaID == 2)
            {
                return Redirect("/Uposlenici/Home/Index");

            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        public IActionResult Logout()
        {
          
            return View();
        
        }
        public IActionResult Registracija()
        {
            RegistracijaVM vm = new RegistracijaVM()
            {
                tip = db.TipNaloga.Select(s=>new SelectListItem
                {
                    Text=s.Tip,
                    Value=s.TipNalogaID.ToString()
                }).ToList()
            };
            return View(vm);
        }
        public IActionResult RegistrujSnimi(RegistracijaVM model)
        {

            if (!ModelState.IsValid)
            {
               
                model.tip = db.TipNaloga.Select(s => new SelectListItem
                {
                    Text = s.Tip,
                    Value = s.TipNalogaID.ToString()
                }).ToList();
                return View("Registracija", model);
            }

            KorisnickiNalog nalog = new KorisnickiNalog
            {
                KorisnickoIme = model.KorisnickoIme,
                Lozinka = model.Lozinka,
                TipNalogaID = model.TipID
            };
            db.KorisnickiNalog.Add(nalog);
            db.SaveChanges();
            if (model.TipID == 2)
            {

            }
            else
            {
                Clan noviClan = new Clan()
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Adresa = model.Adresa,
                    Email = model.Email,
                    NalogID = nalog.Id,
                    DatumUclanjivanja=DateTime.Now,
                    Aktivan=true

                };
                db.Clan.Add(noviClan);

                Korisnik noviKorisnik = new Korisnik()
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Adresa = model.Adresa,
                    Email = model.Email,
                    DatumRodjenja = DateTime.Parse("2.5.1998"),
                    KorisnickiNalogID = nalog.Id,
                    UlogaID = 2

                };

                db.Korisnik.Add(noviKorisnik);

                db.SaveChanges();

                KorisnickiNalog korisnik = db.KorisnickiNalog.SingleOrDefault(x => x.KorisnickoIme == model.KorisnickoIme);

                HttpContext.SetLogiraniKorisnik(korisnik);
                //return RedirectToAction("Index", "Home");
                //return RedirectToAction("HomePocetna", "Home");
                //var lk = HttpContext.GetLogiraniKorisnik();


                //return RedirectToAction("Index", "Home");
                //return View("Clanovi","Home");
                return Redirect("/Autentifikacija/Logout");


            }
            //return RedirectToAction("HomePocetna", "Home");
            //return RedirectToAction("Index", "Home");

            //return View("Clanovi","Home");
            //return View("HomePocetna");
            return RedirectToAction("Index", "Home");


        }
    
    }
}