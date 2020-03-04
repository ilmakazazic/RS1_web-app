using RS1_WebApp.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class Teretana
    {
        [Key]
        public int TeretanaID { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public TimeSpan PocetakRadnoVrijeme { get; set; }
        public TimeSpan KrajRadnoVrijeme { get; set; }
        public int GradID { get; set; }
        [ForeignKey("GradID")]
        public Grad Grad { get; set; }
        //public int? TreninziID { get; set; }
        //[ForeignKey("TreninziID")]
        //public Treninzi Treninzi { get; set; }

        public string PhotoPath { get; set; }

    }
}
