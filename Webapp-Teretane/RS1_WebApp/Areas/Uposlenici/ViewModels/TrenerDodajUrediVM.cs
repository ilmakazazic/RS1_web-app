using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TrenerDodajUrediVM
    {
        public int TrenerId { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        public string Prezime { get; set; }

        public DateTime datumRodjenja { get; set; }
        [EmailAddress(ErrorMessage = "Email je obavezno polje")]
        public string Email { get; set; }
        public string Spol { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public DateTime DatumIsteka { get; set; }

        [Required(ErrorMessage = "Korisnicko ime je obavezno polje")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        public string Password { get; set; }

        public int LicencaId { get; set; }
        public List<SelectListItem> Licenca { get; set; }
    }
}
