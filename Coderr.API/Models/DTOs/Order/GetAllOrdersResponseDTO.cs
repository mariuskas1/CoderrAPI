using System.ComponentModel.DataAnnotations.Schema;

namespace Coderr.API.Models.DTOs.Order
{
    public class GetAllOrdersResponseDTO
    {
        public Guid id { get; set; }
        public Guid customer_user { get; set; }
        public Guid business_user { get; set; }
        public string title { get; set; }
        public int revisions { get; set; }
        public int delivery_time_in_days { get; set; }
        public decimal price { get; set; }
        public List<string> features { get; set; } = new List<string>();
        public string offer_type { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; } 
        public DateTime updated_at { get; set; }
    }
}
