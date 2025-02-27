namespace Coderr.API.Models.DTOs
{
    public class AddOfferResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public List<AddOfferDetailResponseDTO> Details { get; set; } = new List<AddOfferDetailResponseDTO>();
    }
}
