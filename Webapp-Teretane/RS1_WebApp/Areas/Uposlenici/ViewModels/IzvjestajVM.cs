using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class IzvjestajVM
    {
        public int TeretanaId { get; set; }
        public List<SelectListItem> Teretane { get; set; }
        public int TipClanarineId { get; set; }
        public List<SelectListItem> TipClanarine { get; set; }
    }
}
