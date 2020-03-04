using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class PlacanjeClanarine
    {
        [Key]
        public int PlacanjeClanarineID { get; set; }
       
        public double Popust { get; set; }

        public int BrojRacuna{ get; set; }

        public double UkupanIznos { get; set; }

        public DateTime DatumUplate { get; set; }

        public int TipClanarineID { get; set; }
        [ForeignKey("TipClanarineID")]
        public TipClanarine TipClanarine { get; set; }

        public int ClanID { get; set; }
        [ForeignKey("ClanID")]
        public Clan Clan { get; set; }

        public int KorisnikID { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }
        public int? TeretanaID { get; set; }
        [ForeignKey("TeretanaID")]
        public Teretana Teretana { get; set; }


    }
}
