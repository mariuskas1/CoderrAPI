using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coderr.API.Models.Domain
{
    public class Offer
    {
        public Guid Id { get; set; }

        [ForeignKey("UserProfile")]
        public string UserId { get; set; }
        public UserProfile User {  get; set; }

        [Required]
        public string Title { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OfferDetails> OfferDetails { get; set; } = new List<OfferDetails>();
    }
}
