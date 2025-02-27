using System.Text.Json;
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

            CreateMap<AddOfferRequestDTO, Offer>()
            .ForMember(dest => dest.OfferDetails, opt => opt.MapFrom(src => src.Details));

            CreateMap<AddOfferDetailRequestDTO, OfferDetails>()
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => string.Join(",", src.Features)));

            CreateMap<Offer, AddOfferResponseDTO>()
             .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.OfferDetails));

            CreateMap<OfferDetails, AddOfferDetailResponseDTO>()
            .ForMember(dest => dest.Features, opt => opt.MapFrom<FeaturesStringToListResolver>());


            CreateMap<Offer, GetAllOffersResponseDTO>()
            .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.OfferDetails.Select(d => new OfferDetailDTO
            {
                Id = d.Id,
                Url = $"/offerdetails/{d.Id}/"
            }).ToList()))
            .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.OfferDetails.Any() ? src.OfferDetails.Min(d => d.Price) : 0))
            .ForMember(dest => dest.MinDeliveryTime, opt => opt.MapFrom(src => src.OfferDetails.Any() ? src.OfferDetails.Min(d => d.DeliveryTimeInDays ?? 0) : 0))
            .ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => new UserDetailsDTO
            {
                FirstName = src.User.FirstName,
                LastName = src.User.LastName,
                Username = src.User.Username
            }));
        }
    }
}
