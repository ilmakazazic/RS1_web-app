using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.ViewModels
{
    public class RezervacijaVM
    {
        public int ClanID { get; set; }
        public int TeretanaID { get; set; }
        public string Teretana { get; set; }
        public List<SelectListItem> treninzi { get; set; }
        public int TreningID { get; set; }
        //public List<Row> rows { get; set; }
        //public class Row
        //{
        //    public int TreningID { get; set; }
        //    public DateTime Datum { get; set; }
        //    public TimeSpan
        //}
    }
}
