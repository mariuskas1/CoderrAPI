namespace Coderr.API.Models.DTOs
{
    public class AddOfferRequestDTO
    {
        public string title { get; set; }
        public string? image { get; set; }
        public string description { get; set; }
        public List<AddOfferDetailRequestDTO> details { get; set; } = new List<AddOfferDetailRequestDTO>();
    }
}
