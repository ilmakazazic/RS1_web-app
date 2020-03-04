using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.EntityModels
{
    public class PopustKupon
    {
        public int PopustKuponId { get; set; }

        public string KuponKod { get; set; }
        public int Postotak { get; set; }
        public DateTime PocetakDatum { get; set; }
        public DateTime KrajDatum { get; set; }
        public int Broj_Koristenja { get; set; }
        public int Brojac_Koristenja { get; set; }
        public bool Aktivan { get; set; }
        public int TeretanaId { get; set; }
        public Teretana Teretana { get; set; }

    }
}
