using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class KomentarVM
    {
        public int ClanID { get; set; }
        public int TeretanaID { get; set; }
        public string Teretana { get; set; }
        public string Komentar { get; set; }

    }
}
