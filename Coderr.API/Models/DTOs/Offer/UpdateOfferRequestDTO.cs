namespace Coderr.API.Models.DTOs.Offer
{
    public class UpdateOfferRequestDTO
    {
        public string title { get; set; }
        public List<AddOfferDetailRequestDTO> details { get; set; } = new List<AddOfferDetailRequestDTO>();
    }
}
