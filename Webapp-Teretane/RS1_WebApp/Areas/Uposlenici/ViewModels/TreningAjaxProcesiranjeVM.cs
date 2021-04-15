using System.Collections.Generic;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TreningAjaxProcesiranjeVM
    {
        public int TreningID { get; set; }
        public List<Row> Zahtjevi { get; set; }
        public class Row
        {
            public int TreningZahtjevId { get; set; }
            public string Clan { get; set; }
            public string Teretana { get; set; }
            public string Termin { get; set; }
            public bool Odobren { get; set; }
            public int ClanId { get; set; }
        }

    }
}
