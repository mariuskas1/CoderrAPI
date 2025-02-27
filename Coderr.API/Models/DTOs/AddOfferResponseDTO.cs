namespace Coderr.API.Models.DTOs
{
    public class AddOfferResponseDTO
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string? image { get; set; }
        public string description { get; set; }
        public List<AddOfferDetailResponseDTO> details { get; set; } = new List<AddOfferDetailResponseDTO>();
    }
}
