using AutoMapper;
using Products.Entity;
using Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Helpers.Mappings
{
    public class EntityToModelMappingProfile : Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductOptionEntity, ProductOptionModel>();
        }
    }
}
