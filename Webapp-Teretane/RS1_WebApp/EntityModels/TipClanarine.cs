using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class TipClanarine
    {
        [Key]
        public int TipClanarineID { get; set; }

        public string Tip { get; set; }

        public double Cijena { get; set; }

    }
}
