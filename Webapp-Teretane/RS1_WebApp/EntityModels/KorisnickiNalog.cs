using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.EntityModels
{
    public class KorisnickiNalog
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int? TipNalogaID { get; set; }
        [ForeignKey("TipNalogaID")]
        public TipNaloga TipNaloga { get; set; }
    }
}
