namespace Coderr.API.Models.DTOs
{
    public class GetSingleOfferDetailResponseDTO
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public int Revisions { get; set; }
        public int? DeliveryTimeInDays { get; set; }
        public decimal Price { get; set; }
        public List<string> Features { get; set; } = new List<string>();
        public string OfferType { get; set; }
    }
}
