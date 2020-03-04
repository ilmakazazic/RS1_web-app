using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class Obavijest
    {
        [Key]
        public int ObavijestID { get; set; }

        public string Naziv { get; set; }

        public string Sadrzaj { get; set; }

        public DateTime DatumObjave { get; set; }

        public int TeretanaID { get; set; }
        [ForeignKey("TeretanaID")]
        public Teretana Teretana { get; set; }

        public int KorisnikID { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }

     


    }
}
