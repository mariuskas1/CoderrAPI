using Coderr.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coderr.API.Models.DTOs
{
    public class ReviewDTO
    {
        public Guid id { get; set; }

        [ForeignKey("business_user")]
        public string business_user_id { get; set; }
        public UserProfile business_user { get; set; }

        [ForeignKey("reviewer")]
        public string reviewer_id { get; set; }
        public UserProfile reviewer { get; set; }
        public float rating { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
