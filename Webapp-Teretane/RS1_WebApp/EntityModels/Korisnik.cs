using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RS1_WebApp.EntityModels;

namespace RS1_Teretana.EntityModels
{
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string Adresa { get; set; }

        public string Telefon { get; set; }

        public DateTime DatumRodjenja { get; set; }


        public int UlogaID { get; set; }
        [ForeignKey("UlogaID")]
        public Uloga Uloga { get; set; }

        public int? TeretanaID { get; set; }
        [ForeignKey("TeretanaID")]
        public Teretana Teretana { get; set; }


       
        public int? KorisnickiNalogID { get; set; }
        [ForeignKey("KorisnickiNalogID")]
        public KorisnickiNalog KorisnickiNalog { get; set; }

    }
}
