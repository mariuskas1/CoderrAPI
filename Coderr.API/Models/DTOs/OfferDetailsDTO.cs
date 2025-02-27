using Coderr.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Coderr.API.Models.DTOs
{
    public class OfferDetailsDTO
    {
        public Guid Id { get; set; }

        [ForeignKey("Offer")]
        public Guid OfferId { get; set; }
        public Offer Offer { get; set; }

        [Required]
        public string Title { get; set; }
        public int Revisions { get; set; }
        public int? DeliveryTimeInDays { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string Features { get; set; } = "[]";
        public string? OfferType { get; set; }

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
