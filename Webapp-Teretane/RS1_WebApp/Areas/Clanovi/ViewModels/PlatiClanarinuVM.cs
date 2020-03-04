using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class PlatiClanarinuVM
    {
        public int ClanID { get; set; }
        [Required(ErrorMessage = "Ime i prezime je obavezno polje")]
        public string ImeP { get; set; }
        public int TipClanarineID { get; set; }
        public List<SelectListItem> Clanarine { get; set; }
        public double Popust { get; set; }
        public double UkupanIznos { get; set; }
        [Required(ErrorMessage = "Broj kartice je obavezno polje")]
        public int BrojKartice { get; set; }
        [EmailAddress(ErrorMessage = "E-mail je obavezno polje")]
        public string email { get; set; }
        [Required(ErrorMessage = "CVV je obavezno polje")]
        public string CVV { get; set; }
        public int TeretanaID { get; set; }
        public List<SelectListItem> teretane { get; set; }
    }
}
