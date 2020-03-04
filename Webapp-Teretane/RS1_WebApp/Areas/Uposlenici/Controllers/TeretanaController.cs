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

namespace RS1_WebApp.Areas.Uposlenici.Controllers
{
    [Area("Uposlenici")]
    public class TeretanaController : Controller
    {
        private readonly MyContext db;
        private IHostingEnvironment hostingEnvironment;
        public TeretanaController(MyContext context, IHostingEnvironment h)
        {
            db = context;
            hostingEnvironment = h;
        }

        public IActionResult Index()
        {
            TeretanaVM vm = new TeretanaVM()
            {
                teretane = db.Teretana.Select(x => new TeretanaVM.Row()
                {
                    Adresa = x.Adresa,
                    Grad = x.Grad.Naziv,
                    Naziv = x.Naziv,
                    KrajRadnoVrijeme = x.KrajRadnoVrijeme,
                    PocetakRadnoVrijeme = x.PocetakRadnoVrijeme,
                    TeretanaId = x.TeretanaID,
                    Slika=x.PhotoPath
                }).ToList()
            };
            
            return View(vm);
        }

        [HttpGet]
        public IActionResult Dodaj()
        {
            DodajTeretanaVM vm = new DodajTeretanaVM()
            {
                Grad = db.Grad.Select(x => new SelectListItem()
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(DodajTeretanaVM vm)
        {
            var t = db.Teretana.Where(c=>c.Naziv==vm.Naziv && c.Adresa==vm.Adresa).Count();

            if(t!=0)
            {
                TempData["poruka-key"] = "Teretana već postoji!";
                return RedirectToAction(nameof(Dodaj));
            }
            else
            {
                Teretana novaTeretana = new Teretana()
                {
                    Adresa = vm.Adresa,
                    GradID = vm.GradId,
                    KrajRadnoVrijeme = vm.KrajRadnoVrijeme,
                    PocetakRadnoVrijeme = vm.PocetakRadnoVrijeme,
                    Naziv = vm.Naziv

                };
                if(vm.Photo != null)
                {
                    novaTeretana.PhotoPath = vm.PhotoPath;
                }

                string uniqueFileName = null;
                IFormFile slika = vm.Photo;

                if(slika != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + vm.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    vm.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    novaTeretana.PhotoPath = uniqueFileName;
                }
                db.Teretana.Add(novaTeretana);
                db.SaveChanges();
                TempData["poruka-key"] = "Uspjesno ste dodali Teretanu";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Uredi(int TeretanaID)
        {
            Teretana t = db.Teretana.Find(TeretanaID);
            if (t==null)
            {
                return Content("Teretana ne postoji!");
            }

            DodajTeretanaVM vm = new DodajTeretanaVM()
            {
                TeretanaId=t.TeretanaID,
                Adresa = t.Adresa,
                KrajRadnoVrijeme = t.KrajRadnoVrijeme,
                Naziv = t.Naziv,
                PocetakRadnoVrijeme = t.PocetakRadnoVrijeme,
                Grad = db.Grad.Select(x => new SelectListItem()
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                PhotoPath=t.PhotoPath
                
                
            };


            return View(vm);
        }

        [HttpPost]
        public IActionResult Uredi(DodajTeretanaVM vm)
        {
            Teretana t = db.Teretana.Find(vm.TeretanaId);
            if (t == null)
            {
                return Content("Teretana ne postoji!");
            }
            t.Adresa = vm.Adresa;
            t.GradID = vm.GradId;
            t.KrajRadnoVrijeme = vm.KrajRadnoVrijeme;
            t.PocetakRadnoVrijeme = vm.PocetakRadnoVrijeme;
            t.Naziv = vm.Naziv;

            if (vm.Photo != null)
            {
                t.PhotoPath = vm.PhotoPath;
            }

            string uniqueFileName = null;
            IFormFile slika = vm.Photo;

            if (slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + vm.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                vm.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                t.PhotoPath = uniqueFileName;
            }

            db.Teretana.Update(t);
            db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Obrisi(int TeretanaID)
        {
         
            Teretana t = db.Teretana.Find(TeretanaID);

            if (t == null)
            {
                return Content("Teretana ne postoji!");
            }
            db.Remove(t);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}