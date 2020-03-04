using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class KomentarTeretane
    {
        [Key]
        public int KomentarID { get; set; }

        public string Komentar{ get; set; }

        public int ClanID { get; set; }
        [ForeignKey("ClanID")]
        public Clan Clan { get; set; }

        public int TeretanaID { get; set; }
        [ForeignKey("TeretanaID")]
        public Teretana Teretana { get; set; }

    }
}
