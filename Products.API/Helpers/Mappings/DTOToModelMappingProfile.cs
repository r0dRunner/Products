using AutoMapper;
using Products.API.DTOs;
using Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.API.Helpers.Mappings
{
    public class DTOToModelMappingProfile : Profile
    {
        public DTOToModelMappingProfile()
        {
            CreateMap<ProductDTO, ProductModel>();
            CreateMap<ProductOptionDTO, ProductOptionModel>();
        }
    }
}