﻿using System.Text.Json;
using AutoMapper;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs;
using Coderr.API.Models.DTOs.Offer;
using Coderr.API.Models.DTOs.Order;

namespace Coderr.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OfferDetails, OfferDetailsDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();

            CreateMap<AddOfferRequestDTO, Offer>()
            .ForMember(dest => dest.details, opt => opt.MapFrom(src => src.details));

            CreateMap<AddOfferDetailRequestDTO, OfferDetails>()
            .ForMember(dest => dest.features, opt => opt.MapFrom(src => string.Join(",", src.features)));

            CreateMap<Offer, AddOfferResponseDTO>()
             .ForMember(dest => dest.details, opt => opt.MapFrom(src => src.details));

            CreateMap<OfferDetails, AddOfferDetailResponseDTO>()
            .ForMember(dest => dest.features, opt => opt.MapFrom<FeaturesStringToListResolver>());


            CreateMap<Offer, GetAllOffersResponseDTO>()
            .ForMember(dest => dest.details, opt => opt.MapFrom(src => src.details.Select(d => new OfferDetailDTO
            {
                id = d.id,
                url = $"/offerdetails/{d.id}/"
            }).ToList()))
            .ForMember(dest => dest.min_price, opt => opt.MapFrom(src => src.details.Any() ? src.details.Min(d => d.price) : 0))
            .ForMember(dest => dest.min_delivery_time, opt => opt.MapFrom(src => src.details.Any() ? src.details.Min(d => d.delivery_time_in_days ?? 0) : 0))
            .ForMember(dest => dest.user_details, opt => opt.MapFrom(src => new UserDetailsDTO
            {
                first_name = src.user.first_name,
                last_name = src.user.last_name,
                username = src.user.username
            }));

            CreateMap<Offer, GetSingleOfferResponseDTO>()
           .ForMember(dest => dest.details, opt => opt.MapFrom(src => src.details))
           .ForMember(dest => dest.min_price, opt => opt.MapFrom(src => src.details.Any() ? src.details.Min(d => d.price) : 0))
           .ForMember(dest => dest.min_delivery_time, opt => opt.MapFrom(src => src.details.Any() ? src.details.Min(d => d.delivery_time_in_days ?? 0) : 0))
           .ForMember(dest => dest.user_details, opt => opt.MapFrom(src => new UserDetailsDTO
           {
               first_name = src.user.first_name,
               last_name= src.user.last_name,
               username = src.user.username
           }));

           CreateMap<OfferDetails, GetSingleOfferDetailResponseDTO>()
            .ForMember(dest => dest.features, opt => opt.MapFrom(src => src.features.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()));


           CreateMap<UpdateOfferRequestDTO, Offer>();
           CreateMap<Offer, UpdateOfferResponseDTO>();
           CreateMap<OfferDetails, GetOfferDetailsResponseDTO>();


           CreateMap<Order, GetAllOrdersResponseDTO>()
               .ForMember(dest => dest.features, opt => opt.MapFrom(src =>
                   string.IsNullOrEmpty(src.features)
                       ? new List<string>()
                       : src.features.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()));

           CreateMap<Order, AddOrderResponseDTO>()
                .ForMember(dest => dest.features, opt => opt.MapFrom(src =>
                   string.IsNullOrEmpty(src.features)
                       ? new List<string>()
                       : src.features.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()));

            CreateMap<UpdateOrderRequestDTO, Order>();




        }
    }
}
