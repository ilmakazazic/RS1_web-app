using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class Izvjestaj
    {
        [Key]
        public int IzvjestajID { get; set; }

        public string Naziv { get; set; }

        public string Sadrzaj { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public int KorisnikID { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }
    }
}
