using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TrenerLicencaVM
    {
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        public string Naziv { get; set; }
    }
}
