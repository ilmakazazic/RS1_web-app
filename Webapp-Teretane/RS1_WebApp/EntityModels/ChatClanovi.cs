using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
