namespace GeoCloudAI.Domain.Classes
{
    public class Account
    {
        public int     Id { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public int?    AcessMaxAttempts { get; set; }
        public int?    ValidityUserPassword { get; set; }
        public int?    ValidInviteUser { get; set; }
        public int?    ValidInviteProject { get; set; }
    }
}