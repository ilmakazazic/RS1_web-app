using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class TipoviClanarineVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int TipID { get; set; }
            public string Naziv { get; set; }
            public double cijena { get; set; }
        }
    }
}
