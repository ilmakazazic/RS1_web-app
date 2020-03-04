using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class ObavijestVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int ObavijestID { get; set; }

            public string Naziv { get; set; }

            public string Sadrzaj { get; set; }

            public DateTime DatumObjave { get; set; }
            public string Teretana { get; set; }
            public bool procitana { get; set; }
        }

    }
}
