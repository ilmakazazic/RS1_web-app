using System.ComponentModel.DataAnnotations;

namespace RS1_Teretana.EntityModels
{
    public class Drzava
    {
        [Key]
        public int DrzavaID { get; set; }
        public string Naziv { get; set; }
    }
}
