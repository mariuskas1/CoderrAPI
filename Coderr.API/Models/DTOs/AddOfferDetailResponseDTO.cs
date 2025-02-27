namespace Coderr.API.Models.DTOs
{
    public class AddOfferDetailResponseDTO
    {
        public Guid id { get; set; } 
        public string title { get; set; }
        public int revisions { get; set; }
        public int? delivery_time_in_days { get; set; }
        public decimal price { get; set; }
        public List<string> features { get; set; } = new List<string>();
        public string offer_type{ get; set; }
    }
}
