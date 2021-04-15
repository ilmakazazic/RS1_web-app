using System.Collections.Generic;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class KuponVM
    {
        public int TeretanaId { get; set; }
        public List<Row> Kuponi { get; set; }
        public class Row
        {
            public int PopustKuponId { get; set; }
            public int Postotak { get; set; }
            public string KuponKod { get; set; }
            public string PocetakDatum { get; set; }
            public string KrajDatum { get; set; }
            public int Broj_Koristenja { get; set; }
            public int Brojac_Koristenja { get; set; }
            public bool Aktivan { get; set; }

        }
    }
}
