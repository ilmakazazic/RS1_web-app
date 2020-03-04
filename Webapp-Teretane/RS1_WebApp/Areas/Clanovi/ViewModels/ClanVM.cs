
using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class ClanVM
    {
        public int ClanID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public string Email { get; set; }

        public Teretana Teretana { get; set; }

        public TipClanarine TipClanarine { get; set; }
    }
}

