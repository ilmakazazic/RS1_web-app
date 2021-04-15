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
using System.Drawing;
using System.Threading;


namespace RS1_WebApp.Areas.Uposlenici.Controllers
{
    [Area("Uposlenici")]
    public class IzvjestajController : Controller
    {
        private readonly MyContext db;
        public IzvjestajController(MyContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            IzvjestajVM vm = new IzvjestajVM()
            {
                Teretane = db.Teretana.Select(x => new SelectListItem()
                {
                    Text = x.Naziv,
                    Value = x.TeretanaID.ToString()
                }).ToList(),
                TipClanarine = db.TipClanarine.Select(x => new SelectListItem()
                {
                    Value = x.TipClanarineID.ToString(),
                    Text = x.Tip
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult Prikazi(IzvjestajVM input)
        {
            IzvjestajPrikazVM vm = new IzvjestajPrikazVM()
            {
                TeretanaID = input.TeretanaId,
                TipClanarineID = input.TipClanarineId,
                izvjestaj = db.PlacanjeClanarine.Where(c => c.TipClanarineID == input.TipClanarineId && c.TeretanaID == input.TeretanaId)
                   .Select(x => new IzvjestajPrikazVM.Row()
                   {
                       ImePrezime = x.Clan.Ime + " " + x.Clan.Prezime,
                       DatumUplate = x.DatumUplate.ToString("dd.MM.yyyy"),
                       Iznos=x.UkupanIznos,
                       ClanId=x.ClanID
                   }).ToList()

            };


            return View(vm);
        }

    }
}