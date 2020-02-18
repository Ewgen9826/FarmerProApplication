namespace FarmerProApplication.Dtos.Korm
{
    public class KormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RawMaterial { get; set; }
        public double Energy { get; set; }
        public double Protein { get; set; }
        public decimal Cost { get; set; }
    }
}
