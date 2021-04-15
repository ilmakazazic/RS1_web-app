using System.ComponentModel.DataAnnotations;

namespace RS1_Teretana.EntityModels
{
    public class Uloga
    {
        [Key]
        public int UlogaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
