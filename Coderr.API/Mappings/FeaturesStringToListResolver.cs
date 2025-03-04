﻿using AutoMapper;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs.Offer;
using System.Text.Json;

namespace Coderr.API.Mappings
{
    public class FeaturesStringToListResolver : IValueResolver<OfferDetails, AddOfferDetailResponseDTO, List<string>>
    {
        public List<string> Resolve(OfferDetails source, AddOfferDetailResponseDTO destination, List<string> destMember, ResolutionContext context)
        {
            return string.IsNullOrEmpty(source.features)
            ? new List<string>()
            : source.features.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
