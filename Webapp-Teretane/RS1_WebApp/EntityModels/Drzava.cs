using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Teretana.EntityModels
{
    public class Drzava
    {
        [Key]
        public int DrzavaID { get; set; }
        public string Naziv { get; set; }
    }
}
