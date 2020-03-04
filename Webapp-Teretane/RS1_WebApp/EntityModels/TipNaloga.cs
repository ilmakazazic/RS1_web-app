using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.EntityModels
{
    public class TipNaloga
    {
        [Key]
        public int TipNalogaID { get; set; }
        public string Tip { get; set; }
    }
}
