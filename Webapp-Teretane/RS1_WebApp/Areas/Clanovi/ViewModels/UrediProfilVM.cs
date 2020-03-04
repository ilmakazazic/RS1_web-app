using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class UrediProfilVM
    {
        public int ClanID { get; set; }
        [Required(ErrorMessage = "korisničko ime je obavezno polje")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        public string Lozinka { get; set; }
        [Required(ErrorMessage = "E-mail je obavezno polje")]
        [EmailAddress(ErrorMessage = "E-mail nije u ispravnom formatu")]
        public string Email { get; set; }
    }
}
