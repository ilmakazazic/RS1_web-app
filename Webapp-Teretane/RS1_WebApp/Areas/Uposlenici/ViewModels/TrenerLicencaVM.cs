using System.ComponentModel.DataAnnotations;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TrenerLicencaVM
    {
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        public string Naziv { get; set; }
    }
}
