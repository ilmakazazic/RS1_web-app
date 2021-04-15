using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RS1_Teretana.EF;
using RS1_WebApp.Areas.Uposlenici.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace RS1_WebApp.Areas.Uposlenici.Controllers
{
    [Area("Uposlenici")]
    public class ClanController : Controller
    {
        private readonly MyContext db;
        public ClanController(MyContext context)
        {
            db = context;
        }

        public IActionResult Index(int TeretanaID)
        {
            var datum = db.PlacanjeClanarine.Where(c => c.TeretanaID == TeretanaID).OrderByDescending(p => p.PlacanjeClanarineID).FirstOrDefault();
            ClanTeretanaVM vm = new ClanTeretanaVM()
            {
                TeretanaID = TeretanaID,
                clanovi = db.ClanTeretana.Include(c => c.Clan)
                .Include(c => c.Teretana)
                .Include(c => c.Clan.KorisnickiNalog).Where(v => v.TeretanaID == TeretanaID).Select(x => new ClanTeretanaVM.Row()
                {
                    clanId = x.Clan.ClanID,
                    ImePrezime = x.Clan.Ime + " " + x.Clan.Prezime,
                    Email = x.Clan.Email,
                    KorisnickoIme = x.Clan.KorisnickiNalog.KorisnickoIme,
                    DatumZadnjeUplate = db.PlacanjeClanarine.Where(c => c.TeretanaID == TeretanaID && c.ClanID == x.ClanID).OrderByDescending(p => p.PlacanjeClanarineID).Select(b => b.DatumUplate.ToString("dd.MM.yyyy")).FirstOrDefault(),
                    PotrebnoUplatit = db.PlacanjeClanarine.Where(c => c.TeretanaID == TeretanaID && c.ClanID == x.ClanID &&
                            ( (c.TipClanarineID == 1 && c.DatumUplate.AddDays(30) <= DateTime.Today) ||
                             (c.TipClanarineID == 3 && c.DatumUplate.AddDays(365) <= DateTime.Today) ))
                            .OrderByDescending(x => x.PlacanjeClanarineID).FirstOrDefault() == null ? false : true
                }).ToList()
            };
            return View(vm);
        }
	}
}