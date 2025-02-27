using System.ComponentModel.DataAnnotations;


namespace Coderr.API.Models.Domain
{
    public class UserProfile 
    {
        public enum UserType
        {
            Business,
            Customer
        }

        public Guid id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }

        public string? file { get; set; }
        public string? location { get; set; }
        public string? tel {  get; set; }
        public string? description { get; set; }
        public string? working_hours { get; set; }

        [Required]
        public UserType type { get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
