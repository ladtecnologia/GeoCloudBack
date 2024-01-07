namespace GeoCloudAI.Domain.Classes
{
    public class Profile
    {
        public int      Id { get; set; }
        public Account? Account { get; set; }
        public string?  Name { get; set; }
    }
}