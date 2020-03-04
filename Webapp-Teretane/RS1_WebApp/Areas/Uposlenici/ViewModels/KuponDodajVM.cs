using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class KuponDodajVM
    {
        [Required(ErrorMessage = "Postotak je obavezno polje")]
        public int Postotak { get; set; }
        public string KuponKod { get; set; }
        public DateTime PocetakDatum { get; set; }
        public DateTime KrajDatum { get; set; }
        public int Broj_Koristenja { get; set; }
        public int Brojac_Koristenja { get; set; }
        public bool Aktivan { get; set; }
        public int TeretanaID { get; set; }

    }
}
