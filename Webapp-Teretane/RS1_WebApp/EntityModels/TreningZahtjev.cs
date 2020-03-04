using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.EntityModels
{
    public class TreningZahtjev
    {
        public int TreningZahtjevId { get; set; }
        
        public int ClanId { get; set; }
        public Clan Clan { get; set; }

        public int TreninziId { get; set; }
        public Treninzi Treninzi { get; set; }

        public bool Odobren { get; set; }
 
    }
}
