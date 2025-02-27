using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Coderr.API.Models.Domain
{
    public class Order
    {
        public Guid id { get; set; }

        [ForeignKey("customer_user")]
        public Guid CustomerUserId { get; set; }
        public UserProfile customer_user { get; set; }


        [ForeignKey("business_user")]
        public Guid BusinessUserId { get; set; }
        public UserProfile business_user { get; set; }

        
        public Guid OfferDetailId { get; set; }
        public OfferDetails details { get; set; }

        public string title { get; set; }
        public int revisions { get; set; }
        public int delivery_time_in_days { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }

        public string features { get; set; } = "[]";
        public string offer_type { get; set; }
        public string status { get; set; } = "in_progress";
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public DateTime updated_at { get; set; } = DateTime.UtcNow;
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
