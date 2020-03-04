using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class TeretanePRikazVM
    {
        public int ClanID { get; set; }
        public List<Row2> mojeTeretane { get; set; }
        public List<Row> teretane { get; set; }
        public class Row2
        {
            public int teretanaID { get; set; }
        }
        public class Row
        {
            public int TeretanaID { get; set; }
            public string Naziv { get; set; }
            public string Adresa { get; set; }
            public string RadnoVrijeme { get; set; }
            public bool Disabled { get; set; }
            public string Grad { get; set; }
        }
    }
}
