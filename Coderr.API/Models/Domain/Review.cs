using System.ComponentModel.DataAnnotations.Schema;

namespace Coderr.API.Models.Domain
{
    public class Review
    {
        public Guid id { get; set; }

        [ForeignKey("business_user")]
        public Guid BusinessUserId { get; set; }
        public UserProfile business_user { get; set; }

        [ForeignKey("reviewer")]
        public Guid ReviewerId { get; set; }
        public UserProfile reviewer { get; set; }
        public float rating { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
