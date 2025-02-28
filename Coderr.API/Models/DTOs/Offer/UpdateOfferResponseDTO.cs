namespace Coderr.API.Models.DTOs.Offer
{
    public class UpdateOfferResponseDTO
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public List<AddOfferDetailResponseDTO> details { get; set; } = new List<AddOfferDetailResponseDTO>();
    }
}
