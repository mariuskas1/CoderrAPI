namespace Coderr.API.Models.DTOs
{
    public class GetSingleOfferResponseDTO
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string? image { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public List<GetSingleOfferDetailResponseDTO> details { get; set; } = new List<GetSingleOfferDetailResponseDTO>();

        public decimal min_price { get; set; }
        public int min_delivery_time { get; set; }

        public UserDetailsDTO user_details { get; set; }
    }
}
