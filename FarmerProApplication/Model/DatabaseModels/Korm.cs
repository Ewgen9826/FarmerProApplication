namespace FarmerProApplication.Model.DatabaseModels
{
    public class Korm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RawMaterial { get; set; }
        public double Energy { get; set; }
        public double Protein { get; set; }
        public decimal Cost { get; set; }
    }
}
