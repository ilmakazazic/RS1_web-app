using RS1_Teretana.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_WebApp.EntityModels
{
    public class TreninziDetalji
    {
        [Key]
        public int TreninziDetaljiID { get; set; }
        public int TreninziID { get; set; }
        [ForeignKey("TreninziID")]
        public Treninzi Treninzi { get; set; }
        public int ClanID { get; set; }
        [ForeignKey("ClanID")]
        public Clan Clan { get; set; }
        public bool Otkazan { get; set; }
    }
}
