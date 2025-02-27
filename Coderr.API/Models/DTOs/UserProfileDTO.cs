using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Coderr.API.Models.DTOs
{
    public class UserProfileDTO : IdentityUser
    {
        public enum UserType
        {
            Business,
            Customer
        }

        [Required]
        public string Name { get; set; }
        public string? FilePath { get; set; }
        public string? Location { get; set; }
        public string? Tel { get; set; }
        public string? Description { get; set; }
        public string? WorkingHours { get; set; }

        [Required]
        public UserType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
