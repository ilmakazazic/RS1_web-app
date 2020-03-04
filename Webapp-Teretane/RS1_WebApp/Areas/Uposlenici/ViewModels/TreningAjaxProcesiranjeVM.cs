using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
