using RS1_Teretana.EntityModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_WebApp.EntityModels
{
    public class TrenerLicenca
    {
        public int TrenerLicencaId { get; set; }
        public int TrenerId { get; set; }
        [ForeignKey("TrenerId")]
        public Trener Trener { get; set; }
        public int LicencaId { get; set; }
        [ForeignKey("LicencaId")]
        public Licenca Licenca { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public DateTime DatumIsteka { get; set; }
    }
}
