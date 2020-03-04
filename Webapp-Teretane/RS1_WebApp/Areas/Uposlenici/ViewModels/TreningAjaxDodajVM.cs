using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TreningAjaxDodajVM
    {
        public int TeretanaId { get; set; }
        public string Teretana { get; set; }
        public string RadnoVrijeme { get; set; }
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Kraj { get; set; }
        public DateTime Datum { get; set; }
        public int BrojRezrevacija { get; set; }
        public int TreningId { get; set; }

        public int TrenerId { get; set; }
        public List<SelectListItem> Trener { get; set; }

    }
}
