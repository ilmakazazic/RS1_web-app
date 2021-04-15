using RS1_Teretana.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_WebApp.EntityModels
{
    public class Uclanjivanje
    {
        [Key]
        public int UclanjivanjeID { get; set; }
        public int TeretanaID { get; set; }
        [ForeignKey("TeretanaID")]
        public Teretana Teretana { get; set; }
        public int ClanID { get; set; }
        [ForeignKey("ClanID")]
        public Clan Clan { get; set; }
    }
}
