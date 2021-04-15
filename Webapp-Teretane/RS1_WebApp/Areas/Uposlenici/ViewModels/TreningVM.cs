using System;
using System.ComponentModel.DataAnnotations;

namespace RS1_WebApp.Areas.Uposlenici.ViewModels
{
    public class TreningVM
    {
        public int TreningId { get; set; }
        public int TeretanaId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DatumString { get; set; }
    }
}
