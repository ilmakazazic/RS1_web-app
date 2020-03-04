using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class GymVM
    {
        public int TeretanaID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public TimeSpan PocetakRadnoVrijeme { get; set; }
        public TimeSpan KrajRadnoVrijeme { get; set; }
        public Grad Grad { get; set; }
    }
}
