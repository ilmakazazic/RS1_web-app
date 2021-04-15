using System.ComponentModel.DataAnnotations;

namespace RS1_Teretana.EntityModels
{
    public class Licenca
    {
        [Key]
        public int LicencaID { get; set; }
        public string Tip { get; set; }
    }
}
