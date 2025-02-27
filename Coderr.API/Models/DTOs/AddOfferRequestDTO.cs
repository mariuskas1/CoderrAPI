namespace Coderr.API.Models.DTOs
{
    public class AddOfferRequestDTO
    {
        public string Title { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public List<AddOfferDetailRequestDTO> Details { get; set; } = new List<AddOfferDetailRequestDTO>();
    }
}
