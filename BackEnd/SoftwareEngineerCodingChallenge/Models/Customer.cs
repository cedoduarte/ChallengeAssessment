namespace SoftwareEngineerCodingChallenge.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdatedDateTime { get; set; } = DateTime.Now;
    }
}
