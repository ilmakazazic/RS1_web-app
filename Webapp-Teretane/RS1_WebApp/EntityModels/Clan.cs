using RS1_WebApp.EntityModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_Teretana.EntityModels
{
    public class Clan
    {

        [Key]
        public int ClanID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }

        public DateTime DatumUclanjivanja { get; set; }
        public bool Aktivan { get; set; }
        public int NalogID { get; set; }
        [ForeignKey("NalogID")]
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
