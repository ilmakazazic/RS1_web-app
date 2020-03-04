using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.EntityModels
{
    public class ClanObavijest
    {
        [Key]
        public int ClanObavijestID { get; set; }
        public int ClanID { get; set; }
        [ForeignKey("ClanID")]
        public Clan Clan { get; set; }
        public int ObavijestID { get; set; }
        [ForeignKey("ObavijestID")]
        public Obavijest Obavijest { get; set; }
        public bool Procitana { get; set; }
    }
}
