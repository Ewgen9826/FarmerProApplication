namespace FarmerProApplication.Dtos.Cow
{
    public class CreateCowDto
    {
        public string GroupName { get; set; }
        public double Weight { get; set; }
        public double Productivity { get; set; }
        public int NormId { get; set; }
    }
}
