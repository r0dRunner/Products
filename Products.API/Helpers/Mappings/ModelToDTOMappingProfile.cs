using AutoMapper;
using Products.API.DTOs;
using Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.API.Helpers.Mappings
{
    public class ModelToDTOMappingProfile : Profile
    {
        public ModelToDTOMappingProfile()
        {
            CreateMap<ProductModel, ProductDTO>();
            CreateMap<ProductOptionModel, ProductOptionDTO>();
            CreateMap<IEnumerable<ProductModel>, CollectionDTO<ProductDTO>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
            CreateMap<IEnumerable<ProductOptionModel>, CollectionDTO<ProductOptionDTO>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        }
    }
}