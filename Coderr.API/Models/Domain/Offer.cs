using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coderr.API.Models.Domain
{
    public class Offer
    {
        public Guid id { get; set; }

        [ForeignKey("user")]
        public Guid UserId { get; set; }
        public UserProfile user {  get; set; }

        [Required]
        public string title { get; set; }
        public string? image { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.UtcNow;

        public ICollection<OfferDetails> details { get; set; } = new List<OfferDetails>();
    }
}
