using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.EntityModels
{
    public class Treninzi
    {
        [Key]
        public int TreninziID { get; set; }
        public int TrenerID { get; set; }
        [ForeignKey("TrenerID")]
        public Trener Trener { get; set; }
        public int TeretanaID { get; set; }
        [ForeignKey("TeretanaID")]
        public Teretana Teretana { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public TimeSpan PocetakTreninga { get; set; }
        public TimeSpan KrajTreninga { get; set; }
        public int BrojRezervacija { get; set; }
    }
}
