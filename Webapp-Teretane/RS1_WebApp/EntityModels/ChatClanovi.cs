using System;
using System.ComponentModel.DataAnnotations;

namespace RS1_WebApp.EntityModels
{
    public class ChatClanovi
    {
        [Key]
        public int ChatID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Poruka { get; set; }
        public DateTime DatumVrijeme { get; set; }
    }
}
