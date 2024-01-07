namespace GeoCloudAI.Domain.Classes
{
    public class User
    {
        public int       Id { get; set; }
        public Profile?  Profile { get; set; }
        public string?   FirstName { get; set; }
        public string?   LastName { get; set; }
        public string?   Phone { get; set; }
        public string?   Email { get; set; }
        public string?   Password { get; set; }
        public Country?  Country { get; set; }
        public string?   State { get; set; }
        public string?   City { get; set; }
        public DateTime? Access { get; set; }
        public int?      Attempts { get; set; }
        public bool?     Blocked { get; set; }
        public DateTime? Register { get; set; }
    }
}