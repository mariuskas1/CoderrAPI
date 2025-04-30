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

        public string name { get; set; }
        public string? file_path { get; set; }
        public string? location { get; set; }
        public string? tel { get; set; }
        public string? description { get; set; }
        public string? working_hours{ get; set; }
        public UserType type { get; set; }
        public DateTime created_at { get; set; } 
    }
}
