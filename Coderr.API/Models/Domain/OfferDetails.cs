using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Coderr.API.Models.Domain
{
    public class OfferDetails
    {
        public Guid id { get; set; }

        [ForeignKey("offer")]
        public Guid OfferId { get; set; }
        public Offer offer { get; set; }

        [Required]
        public string title { get; set; }
        public int revisions { get; set; }
        public int? delivery_time_in_days { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }
        public string features { get; set; } = "[]";
        public string? offer_type { get; set; }

        public void SetFeatures(List<string> features)
        {
            this.features = JsonSerializer.Serialize(features);
        }

        public List<string> GetFeatures()
        {
            return JsonSerializer.Deserialize<List<string>>(features) ?? new List<string>();
        }

    }
}
