using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
