using RS1_WebApp.EntityModels;
using System.Collections.Generic;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TrenerVM
    {
        public List<Row> treneri { get; set; }
        public class Row
        {
            public int TrenerId { get; set; }
            public string ImePrezime { get; set; }
            public string datumRodjenja { get; set; }
            public string Email { get; set; }
            public List<TrenerLicenca> Licenca { get; set; }
            public string DatumPolaganja { get; set; }
            public string DatumIsteka { get; set; }
        }
    }
}
