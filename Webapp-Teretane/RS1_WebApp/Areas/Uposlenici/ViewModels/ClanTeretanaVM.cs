using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class ClanTeretanaVM
    {
        public int TeretanaID { get; set; }
        public List<Row> clanovi { get; set; }
        public class Row
        {
            public int clanId { get; set; }
            public string ImePrezime { get; set; }

            public string KorisnickoIme { get; set; }

            public string Email { get; set; }

            public string DatumZadnjeUplate { get; set; }

            public bool PotrebnoUplatit { get; set; }

        }
    }
}
