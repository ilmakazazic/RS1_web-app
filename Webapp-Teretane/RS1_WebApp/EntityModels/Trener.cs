using RS1_WebApp.EntityModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_Teretana.EntityModels
{
    public class Trener
    {
        [Key]
        public int TrenerID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public int NalogID { get; set; }
        [ForeignKey("NalogID")]
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
