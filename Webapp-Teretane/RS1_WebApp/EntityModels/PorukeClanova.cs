﻿using RS1_Teretana.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_WebApp.EntityModels
{
    public class PorukeClanova
    {
        [Key]
        public int PorukeID { get; set; }
        public int ClanID { get; set; }
        [ForeignKey("ClanID")]
        public Clan Clan { get; set; }
        public string Sadrzaj { get; set; }
        public string Odgovor { get; set; }
    }
}
