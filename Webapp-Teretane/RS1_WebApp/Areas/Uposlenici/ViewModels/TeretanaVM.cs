using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TeretanaVM
    {

        public List<Row> teretane { get; set; }
        public class Row
        {
            public int TeretanaId { get; set; }
            public string Naziv { get; set; }
            public string Adresa { get; set; }
            public TimeSpan PocetakRadnoVrijeme { get; set; }
            public TimeSpan KrajRadnoVrijeme { get; set; }
            public string Slika { get; set; }
            public string Grad { get; set; }

        }

    }
}
