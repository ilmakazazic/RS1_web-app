using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class RegistracijaVM
    {
        [Required(ErrorMessage = "Ime je obavezno polje")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje")]
        public string Prezime { get; set; }
        [EmailAddress(ErrorMessage = "Email je obavezno polje")]
        public string Email { get; set; }
     
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Korisničko ime je obavezno polje")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        public string Lozinka { get; set; }
        public int TipID { get; set; }
        public List<SelectListItem> tip { get; set; }
    }
}
