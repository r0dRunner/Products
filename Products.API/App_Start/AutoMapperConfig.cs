using AutoMapper;
using Products.API.Controllers.v1_0;
using Products.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Products.API.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x => {
                x.AddProfiles(new[] {
                    typeof(ProductsController),
                    typeof(ProductService)
                });
            });
        }
    }
}