namespace FarmerProApplication.Model.DatabaseModels
{
    public class Cow
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public double Weight { get; set; }
        public double Productivity { get; set; }

        public int NormId { get; set; }
        public Norm Norm { get; set; }
    }
}
