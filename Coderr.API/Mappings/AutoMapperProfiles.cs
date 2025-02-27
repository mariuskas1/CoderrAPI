using AutoMapper;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs;

namespace Coderr.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        protected AutoMapperProfiles()
        {
            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OfferDetails, OfferDetailsDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();
        }
    }
}
