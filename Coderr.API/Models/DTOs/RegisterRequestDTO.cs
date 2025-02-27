using System.ComponentModel.DataAnnotations;

namespace Coderr.API.Models.DTOs
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public string[] roles { get; set; }
    }
}
