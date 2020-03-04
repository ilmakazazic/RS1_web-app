using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class ProfilVM
    {
        public int ClanID { get; set; }
        public string Naziv { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public List<Row> Teretane { get; set; }
        public List<Row3> clanarine { get; set; }
        public class Row3
        {
            public string TipClanarine { get; set; }
            public string Teretana { get; set; }
            public double Ukupno { get; set; }
            public string Datum { get; set; }
            public double Popust { get; set; }
        }
        public class Row
        {
            public int TeretanaID { get; set; }
            public string Naziv { get; set; }
            public string Komentar { get; set; }
        }
        public List<Row2> Treninzi { get; set; }
        public class Row2
        {
            public int TreninziDetaljiID { get; set; }
            public string Teretana { get; set; }
            public string DatumVrijeme { get; set; }
            public bool Otkazan { get; set; }
        }
    }
}
