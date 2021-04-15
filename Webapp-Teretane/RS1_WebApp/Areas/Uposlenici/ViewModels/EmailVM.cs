using System.ComponentModel.DataAnnotations;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class EmailVM
    {
        [Required(ErrorMessage = "Ime je obavezno polje")]
        [StringLength(60, MinimumLength = 5)]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Email je obavezno polje")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Naslov je obavezno polje")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Poruka je obavezno polje")]
        public string Poruka { get; set; }
        public int TeretanaID { get; set; }
    }
}
