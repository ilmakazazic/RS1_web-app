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
using RS1_WebApp.EntityModels;

namespace RS1_WebApp.Areas.Uposlenici.Controllers
{
    [Area("Uposlenici")]
    public class TreningAjaxController : Controller
    {
        private readonly MyContext db;
        public TreningAjaxController(MyContext context)
        {
            db = context;
        }

        public IActionResult Index(TreningVM input)
        {

            TreningAjaxVM vm = new TreningAjaxVM()
            {
                TeretanaID = input.TeretanaId,
                DatumString = input.DatumString.ToString(""),
                termini = db.Treninzi.Where(v => v.DatumOdrzavanja == input.DatumString && v.TeretanaID==input.TeretanaId).
                Include(b => b.Trener).Select(x => new TreningAjaxVM.Row()
                {
                    TreningID = x.TreninziID,
                    PočetakTreninga = x.PocetakTreninga,
                    KrajTreninga = x.KrajTreninga,
                    Trener = x.Trener.Ime + " " + x.Trener.Prezime,
                    BrojRezrevacija = x.BrojRezervacija,
                    BrojTrenutnihRezrevacija = db.treninziDetalji.Where(c => c.TreninziID == x.TreninziID && c.Otkazan==false).Count(),
                    BrojZahtjeva = db.TreningZahtjev.Where(c=>c.TreninziId==x.TreninziID && c.Odobren==false).Count()

                }).ToList()

                //termini = db.Treninzi.Where(v => v.DatumOdrzavanja.ToString() == input.DatumString).
                //Include(b=>b.Trener).Select(x => new TreningAjaxVM.Row()
                //{
                //    PočetakTreninga = x.PocetakTreninga,
                //    KrajTreninga = x.KrajTreninga,
                //    Trener = x.Trener.Ime + " " + x.Trener.Prezime



                //}).ToList()
            };
            return PartialView(vm);
        }

        [HttpGet]
        public IActionResult Dodaj(int TeretanaID, DateTime DatumString)
        {
            TreningAjaxDodajVM vm = new TreningAjaxDodajVM()
            {
                Datum=DatumString,
                //Datum = DatumString.Remove(DatumString.Length - 17),
                TeretanaId = TeretanaID,
                Teretana = db.Teretana.Where(c => c.TeretanaID == TeretanaID).Select(x => x.Naziv).FirstOrDefault(),
                RadnoVrijeme = db.Teretana.Where(c => c.TeretanaID == TeretanaID).Select(x => x.PocetakRadnoVrijeme.ToString("hh\\:mm")).FirstOrDefault()
                                    + "-" + db.Teretana.Where(c => c.TeretanaID == TeretanaID).Select(x => x.KrajRadnoVrijeme.ToString("hh\\:mm")).FirstOrDefault(),
                Trener = db.Trener.Select(x => new SelectListItem()
                {
                    Text = x.Ime + " " + x.Prezime,
                    Value = x.TrenerID.ToString()
                }).ToList(),
                //BrojDozvoljenihClanova= db.Teretana.Where(c => c.TeretanaID == TeretanaID).Select(x => x.BrojDozvoljenihClanova).FirstOrDefault()
            };

            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(TreningAjaxDodajVM vm)
        {
            //DateTime pretvoriDatum = Convert.ToDateTime(vm.Datum);
            Treninzi noviTrening = new Treninzi()
            {
                TrenerID = vm.TrenerId,
                TeretanaID = vm.TeretanaId,
                PocetakTreninga = vm.Pocetak,
                KrajTreninga = vm.Kraj,
                DatumOdrzavanja = vm.Datum,
                BrojRezervacija=vm.BrojRezrevacija


            };
            db.Treninzi.Add(noviTrening);
            db.SaveChanges();
            return Redirect("/Uposlenici/Trening?TeretanaID="+vm.TeretanaId);
        }

        [HttpGet]
        public IActionResult Uredi(int TreningID)
        {
            Treninzi t = db.Treninzi.Where(c=>c.TreninziID==TreningID).Include(v=>v.Teretana).FirstOrDefault();
            if (t == null)
            {
                return Content("Teretana ne postoji!");
            }

            TreningAjaxDodajVM vm = new TreningAjaxDodajVM()
            {
                TreningId=t.TreninziID,
                Datum = t.DatumOdrzavanja,
                Kraj = t.KrajTreninga,
                Pocetak = t.PocetakTreninga,
                Teretana = t.Teretana.Naziv,
                TeretanaId = t.TeretanaID,
                BrojRezrevacija=t.BrojRezervacija,
                Trener = db.Trener.Select(x => new SelectListItem()
                {
                    Text = x.Ime + " " + x.Prezime,
                    Value = x.TrenerID.ToString()
                }).ToList(),
                RadnoVrijeme = db.Teretana.Where(c => c.TeretanaID == t.TeretanaID).Select(x => x.PocetakRadnoVrijeme.ToString("hh\\:mm")).FirstOrDefault()
                                    + "-" + db.Teretana.Where(c => c.TeretanaID == t.TeretanaID).Select(x => x.KrajRadnoVrijeme.ToString("hh\\:mm")).FirstOrDefault(),


            };


            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Uredi(TreningAjaxDodajVM vm)
        {
            Treninzi t = db.Treninzi.Where(c => c.TreninziID == vm.TreningId).Include(v => v.Teretana).FirstOrDefault();
            if (t == null)
            {
                return Content("Teretana ne postoji!");
            }

            t.PocetakTreninga = vm.Pocetak;
            t.KrajTreninga = vm.Kraj;
            t.TrenerID = vm.TrenerId;
            t.BrojRezervacija = vm.BrojRezrevacija;

            db.Treninzi.Update(t);
            db.SaveChanges();
            return Redirect("/Uposlenici/Trening?TeretanaID="+vm.TeretanaId);
        }

        public IActionResult Obrisi(int TreningId)
        {
            Treninzi t = db.Treninzi.Find(TreningId);
            if (t == null)
            {
                return Content("Teretana ne postoji!");
            }
            db.Remove(t);
            db.SaveChanges();
            return Redirect("/Uposlenici/Trening?TeretanaID=" + t.TeretanaID);
        }


        public IActionResult Procesiranje(int TreningID)
        {

            TreningAjaxProcesiranjeVM vm = new TreningAjaxProcesiranjeVM
            {
                TreningID = TreningID,
                Zahtjevi = db.TreningZahtjev.Where(c => c.TreninziId == TreningID && c.Odobren==false).Select(x => new TreningAjaxProcesiranjeVM.Row()
                {
                    Clan = x.Clan.Ime + " " + x.Clan.Prezime,
                    Termin = x.Treninzi.PocetakTreninga.ToString("hh\\:mm") + "-" + x.Treninzi.KrajTreninga.ToString("hh\\:mm"),
                    Teretana = x.Treninzi.Teretana.Naziv,
                    Odobren = x.Odobren,
                    ClanId = x.ClanId,
                    TreningZahtjevId=x.TreningZahtjevId
                }).ToList()
            };

            return PartialView(vm);
        }

        public IActionResult ProcesiranjeSnimi(int TreningZahtjevID)
        {
            TreningZahtjev t = db.TreningZahtjev.Include(b=>b.Treninzi).Include(b => b.Treninzi.Teretana)
                .Where(c => c.TreningZahtjevId == TreningZahtjevID).FirstOrDefault();

            t.Odobren = true;
            db.TreningZahtjev.Update(t);

            TreninziDetalji dodajClana = new TreninziDetalji()
            {
                ClanID = t.ClanId,
                TreninziID = t.TreninziId,
                Otkazan = false

            };
            db.treninziDetalji.Add(dodajClana);

            Treninzi rezervacije = db.Treninzi.Where(v => v.TreninziID == t.TreninziId).FirstOrDefault();
            rezervacije.BrojRezervacija += 1;
            db.Treninzi.Update(rezervacije);
            db.SaveChanges();

            return Redirect("/Uposlenici/Trening?TeretanaID=" + t.Treninzi.Teretana.TeretanaID);
        }

        public IActionResult ProcesiranjeSvihZahtjeva(int TreningID, int TeretanaID)
        {
            var zahtjevi = db.TreningZahtjev.Where(c => c.TreninziId == TreningID && c.Odobren == false).ToList();

            foreach(var x in zahtjevi)
            {
                x.Odobren = true;
                TreninziDetalji dodajClana = new TreninziDetalji()
                {
                    ClanID = x.ClanId,
                    TreninziID = x.TreninziId,
                    Otkazan = false
                };
                db.TreningZahtjev.Update(x);
                db.treninziDetalji.Add(dodajClana);
                db.SaveChanges();

            }

            Treninzi rezervacije = db.Treninzi.Where(v => v.TreninziID == TreningID).FirstOrDefault();
            rezervacije.BrojRezervacija += zahtjevi.Count();
            db.Treninzi.Update(rezervacije);
            db.SaveChanges();


            return Redirect("/Uposlenici/Trening?TeretanaID=" + TeretanaID);
        }

        public int BrojTreninga()
        {
            MyContext db = new MyContext();

            List<TreninziDetalji> treninzi = db.treninziDetalji.Where(v=>v.TreninziID==4).ToList();
            int broj = treninzi.Count();
            return broj;
        }




        }
    }