using System.ComponentModel.DataAnnotations;

namespace FarmerProApplication.Dtos.Cow
{
    public class CreateCowDto
    {
        [Required]
        public string GroupName { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Productivity { get; set; }
        [Required]
        public int NormId { get; set; }
    }
}
