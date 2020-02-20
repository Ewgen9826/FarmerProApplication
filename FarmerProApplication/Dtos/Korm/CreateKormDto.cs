using System.ComponentModel.DataAnnotations;

namespace FarmerProApplication.Dtos.Korm
{
    public class CreateKormDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double RawMaterial { get; set; }
        [Required]
        public double Energy { get; set; }
        [Required]
        public double Protein { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
