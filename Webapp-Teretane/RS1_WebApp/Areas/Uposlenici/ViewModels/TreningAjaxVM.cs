using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TreningAjaxVM
    {
        public int TeretanaID { get; set; }
        public string DatumString { get; set; }
        public List<Row> termini { get; set; }
        public class Row
        {
            public int TreningID { get; set; }
            public TimeSpan PočetakTreninga { get; set; }
            public TimeSpan KrajTreninga { get; set; }
            public string Trener { get; set; }
            public int BrojTrenutnihRezrevacija { get; set; }
            public int BrojRezrevacija { get; set; }
            public int BrojZahtjeva { get; set; }

        }
    }
}
