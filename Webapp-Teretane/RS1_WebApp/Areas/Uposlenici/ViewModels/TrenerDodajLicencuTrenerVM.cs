using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TrenerDodajLicencuTrenerVM
    {

        public DateTime DatumPolaganja { get; set; }
        public DateTime DatumIsteka { get; set; }

        public int LicencaId { get; set; }
        public List<SelectListItem> Licenca { get; set; }

        public int TrenerId { get; set; }

    }
}
