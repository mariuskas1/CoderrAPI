using Coderr.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coderr.API.Models.DTOs
{
    public class OfferDTO
    {
        public Guid Id { get; set; }

        [ForeignKey("UserProfile")]
        public string UserId { get; set; }
        public UserProfile User { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OfferDetails> OfferDetails { get; set; } = new List<OfferDetails>();
    }
}
