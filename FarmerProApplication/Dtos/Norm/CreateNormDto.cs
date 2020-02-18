namespace FarmerProApplication.Dtos.Norm
{
    public class CreateNormDto
    {
        public string Name { get; set; }
        public double RawMaterial { get; set; }
        public double Energy { get; set; }
        public double Protein { get; set; }
    }
}
