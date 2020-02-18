namespace FarmerProApplication.Dtos.Korm
{
    public class CreateKormDto
    {
        public string Name { get; set; }
        public double RawMaterial { get; set; }
        public double Energy { get; set; }
        public double Protein { get; set; }
        public decimal Cost { get; set; }
    }
}
