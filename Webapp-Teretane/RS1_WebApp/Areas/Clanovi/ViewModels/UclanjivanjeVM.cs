using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class UclanjivanjeVM
    {
        public int TeretanaID { get; set; }
        public string Teretana { get; set; }
        public int ClanID { get; set; }
        public List<SelectListItem> clanarine { get; set; }
        public int TipClanarineID { get; set; }
        [Required(ErrorMessage = "Ime i prezime je obavezno polje")]

        public string ImePrezime { get; set; }
        [EmailAddress(ErrorMessage = "E-mail je obavezno polje")]
        public string email { get; set; }
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Broj kartice je obavezno polje")]
        public int BrojKartice { get; set; }
    }
}
