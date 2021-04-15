using System.Collections.Generic;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class GradPrikazVM
    {
        public List<Row> gradovi { get; set; }
        public class Row
        {
            public int GradId { get; set; }
            public string Grad { get; set; }
            public string PostanskiBroj { get; set; }
            public string Drzava { get; set; }
            public int DrzavaId { get; set; }
        }
    }
}
