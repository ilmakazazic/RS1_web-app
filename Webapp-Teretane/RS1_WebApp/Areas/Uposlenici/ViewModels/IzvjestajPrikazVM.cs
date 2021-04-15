using System.Collections.Generic;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class IzvjestajPrikazVM
    {
        public int TeretanaID { get; set; }
        public int TipClanarineID { get; set; }

        public List<Row> izvjestaj { get; set; }
        public class Row
        {
            public int ClanId { get; set; }
            public string ImePrezime { get; set; }
            public double Iznos { get; set; }
            public string DatumUplate { get; set; }
        }
    }
}
