using System.ComponentModel.DataAnnotations;

namespace FarmerProApplication.Dtos.Norm
{
    public class CreateNormDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double RawMaterial { get; set; }
        [Required]
        public double Energy { get; set; }
        [Required]
        public double Protein { get; set; }
    }
}
