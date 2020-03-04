using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class DodajTeretanaVM
    {
        public int TeretanaId { get; set; }
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Adresa je obavezno polje")]
        public string Adresa { get; set; }
        public TimeSpan PocetakRadnoVrijeme { get; set; }
        public TimeSpan KrajRadnoVrijeme { get; set; }

        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }

        public int GradId { get; set; }
        public List<SelectListItem> Grad { get; set; }

    }
}
