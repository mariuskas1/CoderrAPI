using System.ComponentModel.DataAnnotations.Schema;

namespace Coderr.API.Models.Domain
{
    public class Review
    {
        public Guid Id { get; set; }

        [ForeignKey("BusinessUser")]
        public string BusinessUserId { get; set; }
        public UserProfile BusinessUser { get; set; }

        [ForeignKey("Reviewer")]
        public string ReviewerId { get; set; }
        public UserProfile Reviewer { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
