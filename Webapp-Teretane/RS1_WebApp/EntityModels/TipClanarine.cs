using System.ComponentModel.DataAnnotations;

namespace RS1_Teretana.EntityModels
{
    public class TipClanarine
    {
        [Key]
        public int TipClanarineID { get; set; }
        public string Tip { get; set; }
        public double Cijena { get; set; }
    }
}
