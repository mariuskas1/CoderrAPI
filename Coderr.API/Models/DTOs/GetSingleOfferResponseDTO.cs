namespace Coderr.API.Models.DTOs
{
    public class GetSingleOfferResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<GetSingleOfferDetailResponseDTO> Details { get; set; } = new List<GetSingleOfferDetailResponseDTO>();

        public decimal MinPrice { get; set; }
        public int MinDeliveryTime { get; set; }

        public UserDetailsDTO UserDetails { get; set; }
    }
}
