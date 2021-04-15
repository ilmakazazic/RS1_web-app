using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class GradVM
    {
        [Required(ErrorMessage = "Grad je obavezno polje")]
        public string Grad { get; set; }
        [Required(ErrorMessage = "Poštanski broj je obavezno polje")]
        public string PostanskiBroj { get; set; }
        public int DrzavaId { get; set; }
        public List<SelectListItem> Drzava { get; set; }
    }
}
