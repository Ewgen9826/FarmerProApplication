namespace FarmerProApplication.Common
{
    public class AppSettings
    {
        public string Host { get; set; }
        public string DatabaseName { get; set; }
        public string buildConnectionString()
        {
            return $"Data Source={Host};Initial Catalog={DatabaseName};Integrated Security=True;MultipleActiveResultSets=true;";
        }
    }
}
