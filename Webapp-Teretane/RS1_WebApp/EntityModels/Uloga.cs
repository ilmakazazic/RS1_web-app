using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class Uloga
    {
        [Key]
        public int UlogaID { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }


    }
}
