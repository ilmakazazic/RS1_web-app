using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_Teretana.EntityModels
{
    public class Grad
    {
        [Key]
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
        public int DrzavaID { get; set; }
        [ForeignKey("DrzavaID")]
        public Drzava Drzava { get; set; }
    }
}
