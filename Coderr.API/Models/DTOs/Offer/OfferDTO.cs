using Coderr.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coderr.API.Models.DTOs.Offer
{
    public class OfferDTO
    {
        public Guid id { get; set; }
        public string UserId { get; set; }
        public UserProfile user { get; set; }
        public string title { get; set; }
        public string? image { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public ICollection<OfferDetails> details { get; set; } = new List<OfferDetails>();
    }
}
