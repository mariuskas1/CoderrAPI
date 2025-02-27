using Coderr.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Coderr.API.Models.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        [ForeignKey("CustomerUser")]
        public string CustomerUserId { get; set; }
        public UserProfile CustomerUser { get; set; }


        [ForeignKey("BusinessUser")]
        public string BusinessUserId { get; set; }
        public UserProfile BusinessUser { get; set; }


        public Guid OfferDetailId { get; set; }
        public OfferDetails OfferDetails { get; set; }

        public string Title { get; set; }
        public int Revisions { get; set; }
        public int DeliveryTimeInDays { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string Features { get; set; } = "[]";
        public string OfferType { get; set; }
        public string Status { get; set; } = "in_progress";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public void SetFeatures(List<string> features)
        {
            Features = JsonSerializer.Serialize(features);
        }

        public List<string> GetFeatures()
        {
            return JsonSerializer.Deserialize<List<string>>(Features) ?? new List<string>();
        }
    }
}
