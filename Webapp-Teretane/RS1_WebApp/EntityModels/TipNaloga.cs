using System.ComponentModel.DataAnnotations;

namespace RS1_WebApp.EntityModels
{
    public class TipNaloga
    {
        [Key]
        public int TipNalogaID { get; set; }
        public string Tip { get; set; }
    }
}
