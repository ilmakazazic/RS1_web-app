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
using Spire.Pdf;
using System.Drawing;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
using System.Threading;
using Spire.Pdf.HtmlConverter;


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